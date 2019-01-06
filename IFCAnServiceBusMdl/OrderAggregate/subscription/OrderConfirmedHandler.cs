using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventCmdAllData;
using NServiceBus;

namespace OrderAggregate.subscription
{
    public class OrderConfirmedHandler : IHandleMessages<OrderConfirmedEventData>
    {
        public Task Handle(OrderConfirmedEventData message,
            IMessageHandlerContext context)
        {
            Console.WriteLine("Customer 收到订单成功通知");
            Console.WriteLine("9. OrderConfirm收到");
            return Task.CompletedTask;
        }
    }
}
