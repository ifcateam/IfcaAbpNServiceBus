using System;
using System.Collections.Generic;
using System.Text;
using IfcaAbpIocHelper;
using IFCAnServiceBusMdl.EndPoint;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using PayForMeterEventData.Meter;
using PayForMeterEventData.Payment;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace PaymentDomain.Modules
{
    public class PaymentAggregate : AggregateRoot<Guid>
    {
        //聚合根 按道理记过仓储查出，不会注入。
        //        public PaymentAggregate(IIFCAEndpoint ifcaEndpoint)
        //        {
        //            _ifcaEndpoint = ifcaEndpoint;
        //        }

        /// <summary>
        /// 此字段是【关键字】，抄表计划明细ID，
        /// <para>抄表计划明细对应抄表档案，再对应抄表标准，明细通过标准算出金额</para>
        /// </summary>
        public Guid BillingStandardId { get; set; }
        /// <summary>
        /// 抄表计划单ID
        /// </summary>
        public Guid BillingId { get; set; }
        /// <summary>
        /// 单据名称
        /// </summary>
        public string TitleName { get; set; }
        /// <summary>
        /// 客户名称，付款人
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// 明细计费金额
        /// </summary>
        public decimal TotalAmo { get; set; }
        /// <summary>
        /// 实际付款金额
        /// </summary>
        public decimal RealPayAmo { get; set; }

        public PAY_STATE PayState { get; set; }

        public PaymentAggregate()
        {
            Id = Guid.NewGuid();
            PayState = PAY_STATE.Init;
        }

        /// <summary>
        /// 创建付款单的一些动作等，目前demo就不做任何事情即可，等待付款人员在界面付款
        /// </summary>
        /// <returns></returns>
        public bool CreatePaymentWaitForPaying()
        {

            return true;
        }
        /// <summary>
        /// 3.更新付款的金额，demo默认是付款完成,
        /// 4.付款不成功demo
        /// </summary>
        /// <param name="totalAmo">当次付款金额</param>
        public void UpdatePayForIt(decimal totalAmo)
        {
            var endpoint = IfcaIocContainerProvider.Instance.RootServiceProvider
                .GetService<IIFCAEndpoint>();
            RealPayAmo += totalAmo;
            //判断付款成功
            if (RealPayAmo >= TotalAmo)
            {
                PayState = PAY_STATE.Complete;

                endpoint.Publish<PaymentConfirmEventData>(e =>
                    {
                        SetEventData(e);
                    }).ConfigureAwait(false);
            }
            else
            {
                PayState = PAY_STATE.Hanging;
                //这里需要改造的，需要将事件嵌入聚合根中            
                endpoint.Publish<PaymentCancelEventData>(e =>
                    {
                        SetEventData(e);
                    }).ConfigureAwait(false);
                throw new UserFriendlyException("付款不够，取消操作");
            }

        }

        private void SetEventData(BaseForPaymentEventData eventData)
        {
            eventData.BillingStandardId = this.BillingStandardId;
            eventData.BillingId = this.BillingId;
            eventData.PaymentId = this.Id;
        }



    }
}
