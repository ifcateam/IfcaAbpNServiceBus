using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using ServiceBusTestDatas;

namespace OrderClient
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrderCmd>
    {
        public Task Handle(PlaceOrderCmd message, IMessageHandlerContext context)
        {
            Debug.Print("收到命令 下单");
            return context.Publish(new OrderCreateEventData()
                {Name = "quarrier", OrderId = message.OrderId});
        }
    }
}
