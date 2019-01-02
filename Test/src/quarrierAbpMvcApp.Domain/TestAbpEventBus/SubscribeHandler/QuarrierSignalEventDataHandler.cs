using System.Threading.Tasks;
using quarrierAbpMvcApp.TestAbpEventBus.EventData;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace quarrierAbpMvcApp.TestAbpEventBus.SubscribeHandler
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
