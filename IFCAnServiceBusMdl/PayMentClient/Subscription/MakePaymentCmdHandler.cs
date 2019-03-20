using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventCmdAllData;
using NServiceBus;

namespace PayMentClient.Subscription
{
    public class MakePaymentCmdHandler : IHandleMessages<MakePeymentCmd>
    {
        public Task Handle(MakePeymentCmd message, IMessageHandlerContext context)
        {
            Console.WriteLine("收到付款的命令");
            Console.WriteLine("执行付款的动作");
            var vEventData = new PaymentAcceptedEventData()
            {
                OrderId = message.OrderId,
                PayAmount = "100",
                PayMentId = "Pay001"
            };
//            return Task.CompletedTask;
//            return context.Reply(vEventData);
            return context.Publish(vEventData);
        }
    }
}
