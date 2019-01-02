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
            //这里一般是用分布式的订阅handler方法，这里订阅成功有三个地方：
            //QuarrierTransientEventDataHandler 和 QuarriersignalEventDataHandler
            DistributedEventBus
                .Subscribe<MySimpleEventData, QuarrierTransientEventDataHandler
                >();
            DistributedEventBus
                .Subscribe<MySimpleEventData, QuarrierDistributedEventDataHandler
                >();

            await DistributedEventBus.PublishAsync(new MySimpleEventData(1));
            await DistributedEventBus.PublishAsync(new MySimpleEventData(2));
            await DistributedEventBus.PublishAsync(new MySimpleEventData(3));

        }
    }
}
