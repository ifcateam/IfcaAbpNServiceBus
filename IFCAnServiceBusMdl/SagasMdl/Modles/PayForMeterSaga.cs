using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using PayForMeterEventData.Meter;
using PayForMeterEventData.Payment;
using PayForMeterEventData.SagaEvent;

namespace SagasMdl.Modles
{
    public class PayForMeterSaga : Saga<PayForMeterSagaData>,
        IAmStartedByMessages<ChargeEventData>,
        IHandleMessages<PaymentConfirmEventData>,
        IHandleMessages<PaymentCancelEventData>

    {
        /// <summary>
        /// 1.计费记录成功事件订阅
        /// </summary>
        /// <param name="message">计费的事件</param>
        /// <param name="context">订阅的上下文</param>
        /// <returns></returns>
        public Task Handle(ChargeEventData message,
            IMessageHandlerContext context)
        {
            var cmd = new PaymentCmd()
            {
                BillingId = message.BillingId,
                BillingStandardId = message.BillingStandardId,
                ActualUsage = message.ActualUsage,
                ClientName = message.ClientName,
                CurrentReadingDate = message.CurrentReadingDate,
                LastReadingCount = message.LastReadingCount,
                LastReadingDate = message.LastReadingDate,
                Dosage = message.Dosage,
                TotalAmo = message.TotalAmo,
                AssociatedMeterUsage = message.AssociatedMeterUsage,
                MeterIdentityNo = message.MeterIdentityNo,
                MeterPerson = message.MeterPerson,
                MeterTypeElementCode = message.MeterTypeElementCode,
                CurrentReadingCount = message.CurrentReadingCount,
                SourceContent = message.SourceContent,
                SourceTypeElementCode = message.SourceTypeElementCode
            };
            return context.SendLocal(cmd);
        }
        /// <summary>
        /// 3.付款成功确定
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Handle(PaymentConfirmEventData message,
            IMessageHandlerContext context)
        {
            //此状态在此demo是可以不需要，只是说明有多个聚合根时候可以按照此扩展
            Data.PaymentIsCommited = true;
            return ProcessPayComplete(context);
        }
        /// <summary>
        /// 4.付款取消
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Handle(PaymentCancelEventData message,
            IMessageHandlerContext context)
        {
            var eventdata = new FaultEventData()
            {
            };
            MarkAsComplete();
            return context.Publish(eventdata);
        }

        protected override void ConfigureHowToFindSaga(
            SagaPropertyMapper<PayForMeterSagaData> mapper)
        {
            //如果是混合多关键字判断，官网推荐的方法，是拼接关键字，尽量让saga是一个关键字查找
            //            mapper.ConfigureMapping<ChargeEventData>(message =>
            //                    $"{message.BillingStandardId}_{message.BillingId}")
            //                .ToSaga(sagaData => sagaData.complexID);

            mapper.ConfigureMapping<ChargeEventData>(e => e.BillingStandardId)
                .ToSaga(sagadata => sagadata.BillingStandardId);

            mapper.ConfigureMapping<PaymentConfirmEventData>(e =>
                    e.BillingStandardId)
                .ToSaga(sagadata => sagadata.BillingStandardId);
            mapper.ConfigureMapping<PaymentCancelEventData>(e =>
                    e.BillingStandardId)
                .ToSaga(sagadata => sagadata.BillingStandardId);
        }

        /// <summary>
        /// 内部判断是否saga成功方式
        /// <para>demo简单可以不需要，这里目的说明，
        /// 当扩展多个聚合根互相之间的操作，可以在此扩展状态</para>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task ProcessPayComplete(IMessageHandlerContext context)
        {
            //如果多个聚合根共同saga，可以在此用&&相与进行判断状态执行完成
            if (Data.PaymentIsCommited)
            {
                var eventData = new SuccessConfirmEventData()
                {

                };

                await context.Publish(eventData);

                MarkAsComplete();
            }
        }
    }
}
