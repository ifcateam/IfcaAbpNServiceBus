using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IfcaAbpIocHelper;
using IFCAnServiceBusMdl.EndPoint;
using NServiceBus;
using NServiceBusTestBase;
using PayForMeterEventData.Meter;
using PayForMeterEventData.SagaEvent;
using Xunit;

namespace TestNServiceBus_Saga
{
    public class MeterClient : NServiceBusTestBase<TestNServiceBus_SagaModule>
    {
        public static AutoResetEvent ThreadEvent;

        private readonly IIFCAEndpoint _ifcaEndpoint;

        public MeterClient()
        {

            IfcaIocContainerProvider.Build(this.RootServiceProvider);
            _ifcaEndpoint = GetRequiredService<IIFCAEndpoint>();

        }

        /// <summary>
        /// 单元测试计费，并事件驱动，saga到付款的过程
        /// </summary>
        [Fact]
        public void Test_MeterCalculateAmount()
        {
            ThreadEvent = new AutoResetEvent(false);
            Debug.Print("假设完成计费");
            var eventdata = new ChargeEventData()
            {
                BillingId = TestData.BillingId,
                BillingStandardId = TestData.BillingStandardId,
                TotalAmo = TestData.TotalAmo
            };
            _ifcaEndpoint.Publish(eventdata).ConfigureAwait(false);


            ThreadEvent.WaitOne();
            Debug.Print("complete All");

        }
    }

    public class MeterClientAutoRestEvent : IHandleMessages<SuccessConfirmEventData>,
        IHandleMessages<FaultEventData>
    {
        /// <summary>
        /// 5.meter客户端收到成功
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Handle(SuccessConfirmEventData message, IMessageHandlerContext context)
        {
            MeterClient.ThreadEvent.Set();

            return Task.CompletedTask;
        }
        /// <summary>
        /// 6.meter客户端 收到付款不成功
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Handle(FaultEventData message, IMessageHandlerContext context)
        {
            MeterClient.ThreadEvent.Set();

            return Task.CompletedTask;
        }
    }
}
