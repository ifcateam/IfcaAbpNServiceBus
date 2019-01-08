using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventCmdAllData;
using NServiceBus;
using Volo.Abp.DependencyInjection;

namespace OrderAggregate.subscription
{
    public class PlaceOrderCmdHandler : IHandleMessages<PlaceOrderCmd>,ITransientDependency
    {
        public Task Handle(PlaceOrderCmd message, IMessageHandlerContext context)
        {
            Console.WriteLine("收到下单的PlaceOrderCmd的命令 orderid:" +
                              message.OrderID);

            Console.WriteLine("执行本地订单写入");
            Console.WriteLine("2.发布OrderCreate事件");

            var vEventData = new OrderCreateEventData()
            {
                OrderId = message.OrderID,
                Descript = message.Descript,
                OrderCreateUserName = "quarrier"
            };

            return context.Publish(vEventData);
        }
    }
}
