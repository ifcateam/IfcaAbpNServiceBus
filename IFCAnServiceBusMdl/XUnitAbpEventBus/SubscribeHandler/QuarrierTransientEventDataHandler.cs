using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EventBus;
using XUnitAbpEventBus.EventData;

namespace XUnitAbpEventBus.SubscribeHandler
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
