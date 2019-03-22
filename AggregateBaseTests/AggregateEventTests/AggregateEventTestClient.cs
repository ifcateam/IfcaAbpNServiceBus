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
using PayForMeterEventData.SagaEvent;
using Shouldly;
using UsersDomain;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace AggregateEventTests
{
    public class
        AggregateEventTestClient : NServiceBusTestBase<AggregateEventTestModule>
    {
        public static AutoResetEvent ThreadEvent;
        public static AutoResetEvent ThreadEventFailed;
        private readonly IIFCAEndpoint _ifcaEndpoint;
        private readonly IRepository<UserAggretgate, Guid> _userAggretgates;

        public AggregateEventTestClient()
        {
            IfcaIocContainerProvider.Build(this.RootServiceProvider);
            _ifcaEndpoint = GetRequiredService<IIFCAEndpoint>();
            _userAggretgates =
                GetRequiredService<IRepository<UserAggretgate, Guid>>();

        }

        [Fact]
        public void AddEvents_Test()
        {
            ThreadEvent = new AutoResetEvent(false);

            var user = new UserAggretgate();
            var id = user.Id;
            user.TodoAddTestEvent();
            _userAggretgates.Insert(user, true);
            var b = ThreadEvent.WaitOne(8000);
            b.ShouldBeTrue();
            Debug.Print("complete All");

        }
    }


    public class ClientAutoRestEvent :
        IHandleMessages<AddUserEventData>,
        IHandleMessages<FaultEventData>
    {
        /// <summary>
        /// 5.meter客户端收到成功
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Handle(AddUserEventData message,
            IMessageHandlerContext context)
        {
            AggregateEventTestClient.ThreadEvent.Set();
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
            AggregateEventTestClient.ThreadEventFailed.Set();

            message.ShouldNotBe(null);
            return Task.CompletedTask;
        }
    }
}
