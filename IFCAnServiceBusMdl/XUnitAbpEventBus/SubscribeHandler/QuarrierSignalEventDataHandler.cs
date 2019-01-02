using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using XUnitAbpEventBus.EventData;

namespace XUnitAbpEventBus.SubscribeHandler
{
    public class
        QuarrierSignalEventDataHandler : ILocalEventHandler<MySimpleEventData>,
            ISingletonDependency
    {
        public int TotalData { get; private set; }

        public Task HandleEventAsync(MySimpleEventData eventData)
        {
            TotalData += eventData.Value;
            return Task.CompletedTask;
        }
    }
}
