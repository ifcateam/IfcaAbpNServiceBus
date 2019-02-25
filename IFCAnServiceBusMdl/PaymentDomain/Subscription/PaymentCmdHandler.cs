using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using IfcaAbpIocHelper;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using PayForMeterEventData.Payment;
using PaymentDomain.Modules;
using Volo.Abp.Domain.Repositories;

namespace PaymentDomain.Subscription
{
    /// <summary>
    /// 2. 付款成功，接收到saga发的付款命令
    /// </summary>
    public class PaymentCmdHandler : IHandleMessages<PaymentCmd>
    {
        public Task Handle(PaymentCmd message, IMessageHandlerContext context)
        {

            //付款操作
            var paymentAggregates = IfcaIocContainerProvider.Instance
                .RootServiceProvider
                .GetService<IRepository<PaymentAggregate, Guid>>();
            var payment = paymentAggregates.Insert(new PaymentAggregate()
            {
                BillingStandardId = message.BillingStandardId,
                BillingId = message.BillingId,
                ClientName = message.ClientName,
                TitleName = "付款单",
                TotalAmo = message.TotalAmo
            });

            if (!payment.CreatePaymentWaitForPaying())
            {
                Debug.Print("付款单失败了");
            }

            payment.UpdatePayForIt(message.TotalAmo);
            return Task.CompletedTask;

        }
    }
}
