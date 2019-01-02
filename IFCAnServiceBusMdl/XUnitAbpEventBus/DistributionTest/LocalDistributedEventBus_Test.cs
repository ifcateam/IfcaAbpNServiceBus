using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitAbpEventBus.EventData;
using XUnitAbpEventBus.SubscribeHandler;

namespace XUnitAbpEventBus.DistributionTest
{
    public class LocalDistributedEventBus_Test : LocalDistributedEventBusTestBase
    {
        [Fact]
        public async Task TestDistributedSubscribteHandler()
        {
            //也可以和本地发布订阅订阅的三种方式都可以使用，这里订阅成功有两个地方：
            //QuarrierTransientEventDataHandler 和 QuarriersignalEventDataHandler
            DistributedEventBus
                .Subscribe<MySimpleEventData, QuarrierTransientEventDataHandler
                >();

            await DistributedEventBus.PublishAsync(new MySimpleEventData(1));
            await DistributedEventBus.PublishAsync(new MySimpleEventData(2));
            await DistributedEventBus.PublishAsync(new MySimpleEventData(3));

        }
    }
}
