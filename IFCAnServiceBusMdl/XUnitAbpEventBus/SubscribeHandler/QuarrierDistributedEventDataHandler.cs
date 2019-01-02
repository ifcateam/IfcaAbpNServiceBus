using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using XUnitAbpEventBus.EventData;

namespace XUnitAbpEventBus.SubscribeHandler
{
    public class
        QuarrierDistributedEventDataHandler :
            IDistributedEventHandler<MySimpleEventData>, IDisposable
    {
        public static int HandleCount { get; set; }

        public static int DisposeCount { get; set; }

        public Task HandleEventAsync(MySimpleEventData eventData)
        {
            ++HandleCount;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            ++DisposeCount;
        }
    }
}
