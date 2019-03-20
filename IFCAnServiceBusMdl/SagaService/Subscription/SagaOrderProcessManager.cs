using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using EventCmdAllData;
using NServiceBus;
using NServiceBus.Sagas;

namespace SagaService.Subscription
{
    public class SagaOrderProcessManager : Saga<OrderSagaData>,
        IAmStartedByMessages<OrderCreateEventData>,
        IHandleMessages<SeatsReservedEventData>,
        IHandleMessages<PaymentAcceptedEventData>,
        IHandleMessages<SeatsNotReservationEventData>
        ,IHandleTimeouts<TimeOutEventData>



    {
        protected override void ConfigureHowToFindSaga(
            SagaPropertyMapper<OrderSagaData> mapper)
        {
            mapper.ConfigureMapping<OrderCreateEventData>(e => e.OrderId)
                .ToSaga(sagadata => sagadata.OrderId);
            mapper.ConfigureMapping<SeatsReservedEventData>(e => e.OrderId)
                .ToSaga(sagadata => sagadata.OrderId);
            mapper.ConfigureMapping<PaymentAcceptedEventData>(e => e.OrderId)
                .ToSaga(sagadata => sagadata.OrderId);
            mapper.ConfigureMapping<SeatsNotReservationEventData>(e => e.OrderId)
                .ToSaga(sagadata => sagadata.OrderId);
        }

        public Task Handle(OrderCreateEventData message,
            IMessageHandlerContext context)
        {
            Data.OrderAggregateIsCommit = true;
            var cmd = new MakeReservationCmd()
            {
                OrderId = message.OrderId
            };

            var eventTest = new OrderConfirmedEventData()
            {
                OrderId = message.OrderId
            };
            Console.WriteLine("saga订阅到OrderCreate事件");
            Console.WriteLine("3.MakeReservation命令发出");

            var sendOptions = new SendOptions();
            sendOptions.DelayDeliveryWith(TimeSpan.FromSeconds(0));
            sendOptions.SetDestination("ReserveClient");

//            context.Publish(eventTest).ConfigureAwait(false);
            context.Send(cmd, sendOptions).ConfigureAwait(false);
            var timeout = DateTime.UtcNow.AddSeconds(3);
            RequestTimeout<TimeOutEventData>(context, timeout)
            .ConfigureAwait(false);
            //            context.Send("ReserveClient", cmd).ConfigureAwait(false);
            return ProcessOrderComplete(context);
        }

        public Task Handle(SeatsReservedEventData message,
            IMessageHandlerContext context)
        {
            Data.ReservationIsCommit = true;
            var cmd = new MakePeymentCmd()
            {
                OrderId = message.OrderId
            };
            Console.WriteLine("saga订阅到SeatsReserved事件");
            Console.WriteLine("7.MakePayMent命令发出");
            context.Send("PayMentClient", cmd).ConfigureAwait(false);
            return ProcessOrderComplete(context);
        }

        public Task Handle(PaymentAcceptedEventData message, IMessageHandlerContext context)
        {
            Data.PayMentIsCommit = true;
            
            Console.WriteLine("saga订阅到Payment事件");

            return ProcessOrderComplete(context);

        }

        private async Task ProcessOrderComplete(IMessageHandlerContext context)
        {
            if (Data.PayMentIsCommit && Data.OrderAggregateIsCommit &&
                Data.ReservationIsCommit)
            {
                var cmd = new OrderConfirmedEventData()
                {
                    OrderId = Data.OrderId
                };
                Console.WriteLine("9.OrderConfirmed事件发出");

                await context.Publish(cmd);

                MarkAsComplete();
            }
        }

        public Task Handle(SeatsNotReservationEventData message,
            IMessageHandlerContext context)
        {
            Console.WriteLine("收到不够位置，SeatsNotReservation 命令");
            var cmd= new AddSeatesToWaitListCmd()
            {
                OrderId = message.OrderId
            };
            context.Send("waitListClient", cmd).ConfigureAwait(false);
//            如果这里要求取消了，就不做后面订单了，必须完成saga
            MarkAsComplete();
            return context.Send("waitListClient", cmd);
        }

        public Task Timeout(TimeOutEventData state, IMessageHandlerContext context)
        {
            Debug.Print("timeout");
            return Task.CompletedTask;
        }
    }
}
