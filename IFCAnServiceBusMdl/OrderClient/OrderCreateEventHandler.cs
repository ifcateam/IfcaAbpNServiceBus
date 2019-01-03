using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using ServiceBusTestDatas;

namespace OrderClient
{
    public class OrderCreateEventHandler
        : IHandleMessages<OrderCreateEventData>
    {
        public Task Handle(OrderCreateEventData message,
            IMessageHandlerContext context)
        {
            Debug.Print("自己订阅下单事件");
            Console.WriteLine("自己订阅下单事件");
            return Task.CompletedTask;
        }
    }
}
