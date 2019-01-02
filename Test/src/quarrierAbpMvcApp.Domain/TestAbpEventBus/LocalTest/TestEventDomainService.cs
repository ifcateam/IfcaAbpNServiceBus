using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using quarrierAbpMvcApp.TestAbpEventBus.EventData;
using quarrierAbpMvcApp.TestAbpEventBus.SubscribeHandler;
using Volo.Abp.Domain.Services;
using Volo.Abp.EventBus.Local;
using Volo.Abp.Threading;

namespace quarrierAbpMvcApp.TestAbpEventBus.LocalTest
{
    public class TestEventDomainService : DomainService
    {
        private readonly ILocalEventBus _localEventBus;

        public TestEventDomainService(ILocalEventBus localEventBus)
        {
            _localEventBus = localEventBus;

            _localEventBus.Subscribe<MySimpleEventData>(
                eventData =>
                {
                    return Task.CompletedTask; 

                });

            _localEventBus.Subscribe<MySimpleEventData,
                QuarrierTransientEventDataHandler>();
        }

        public async Task TodoEventTestAsyncTask()
        {

            await _localEventBus.PublishAsync(new MySimpleEventData(10));

        }
    }
}
