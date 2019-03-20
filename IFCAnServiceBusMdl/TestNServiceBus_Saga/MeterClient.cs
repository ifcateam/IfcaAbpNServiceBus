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
using Shouldly;
using Xunit;
using Xunit.Sdk;

namespace TestNServiceBus_Saga
{
    public class MeterClient : NServiceBusTestBase<TestNServiceBus_SagaModule>
    {
        public static AutoResetEvent ThreadEvent;
        public static AutoResetEvent ThreadEventFailed;

        private readonly IIFCAEndpoint _ifcaEndpoint;

        public MeterClient()
        {

            IfcaIocContainerProvider.Build(this.RootServiceProvider);
            _ifcaEndpoint = GetRequiredService<IIFCAEndpoint>();

        }

        /// <summary>
        /// 单元测试计费，并事件驱动，saga到付款的过程
        /// 【成功过程】
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


            var b = ThreadEvent.WaitOne(8000);
            b.ShouldBeTrue();
            Debug.Print("complete All");

        }

        /// <summary>
        /// 失败事务测试
        /// </summary>
        public void Test_MeterFaild()
        {
            ThreadEventFailed = new AutoResetEvent(false);
            var b = ThreadEventFailed.WaitOne(8000);
            b.ShouldBeTrue();
            Debug.Print("failed测试完成");

        }
    }

    public class MeterClientAutoRestEvent :
        IHandleMessages<SuccessConfirmEventData>,
        IHandleMessages<FaultEventData>
    {
        /// <summary>
        /// 5.meter客户端收到成功
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Handle(SuccessConfirmEventData message,
            IMessageHandlerContext context)
        {
            MeterClient.ThreadEvent.Set();
            message.ShouldNotBe(null);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 6.meter客户端 收到付款不成功
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Handle(FaultEventData message,
            IMessageHandlerContext context)
        {
            MeterClient.ThreadEventFailed.Set();

            message.ShouldNotBe(null);
            return Task.CompletedTask;
        }
    }
}
