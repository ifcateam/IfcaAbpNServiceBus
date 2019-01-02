using System.Threading.Tasks;
using quarrierAbpMvcApp.TestAbpEventBus.EventData;
using Volo.Abp.EventBus;

namespace quarrierAbpMvcApp.TestAbpEventBus.SubscribeHandler
{
    /// <summary>
    /// 生命周期Transient
    /// </summary>
    public class QuarrierTransientEventDataHandler : ILocalEventHandler<MySimpleEventData>

    {
        public int HandleCount { get; set; }

        //        public int DisposeCount { get; set; }

        public Task HandleEventAsync(MySimpleEventData eventData)
        {
            ++HandleCount;
            return Task.CompletedTask;
        }

        //        public void Dispose()
        //        {
        //            ++DisposeCount;
        //        }
    }
}
