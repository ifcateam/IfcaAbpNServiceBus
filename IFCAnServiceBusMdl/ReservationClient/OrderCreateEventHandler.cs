using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using ServiceBusTestDatas;

namespace ReservationClient
{
    public class OrderCreateEventHandler : IHandleMessages<OrderCreateEventData>
    {
        public Task Handle(OrderCreateEventData message,
            IMessageHandlerContext context)
        {
            Debug.Print("订阅下单事件。。。");
            Console.WriteLine("订阅下单事件。。。");
            return Task.CompletedTask;
        }
    }
}
