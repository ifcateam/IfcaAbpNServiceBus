using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventCmdAllData;
using NServiceBus;

namespace ReserveClient.Subscription
{
    public class MakeReservationCmdHandler : IHandleMessages<MakeReservationCmd>
    {
        public Task Handle(MakeReservationCmd message,
            IMessageHandlerContext context)
        {
            var IsEnoughSeats = true;  //是否足够位置
            Console.WriteLine("收到订座位的命令");

            Console.WriteLine("写订位的数据");

            var v = new SeatsReservedEventData()
            {
                OrderId = message.OrderId,
                ReservationId = "R001",
                SeatsNum = "2"
            };

            if (!IsEnoughSeats)
            {
                var eventDataNotEnough = new SeatsNotReservationEventData()
                {
                    OrderId = message.OrderId,
                    SeatsNum = "10"
                };
                return context.Publish(eventDataNotEnough);
            }
//            return Task.CompletedTask;
//            return context.Reply(message);
            return context.Publish(v);
        }
    }
}
