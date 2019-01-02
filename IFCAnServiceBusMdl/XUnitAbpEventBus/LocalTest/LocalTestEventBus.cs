using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitAbpEventBus.EventData;
using XUnitAbpEventBus.SubscribeHandler;

namespace XUnitAbpEventBus.LocalTest
{
    public class LocalTestEventBus : EventBusTestBase
    {
        /// <summary>
        /// 测试普通订阅，有三个地方订阅成功
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task NormalTestLocalPublishAndSubscribe()
        {
            var totalData = 0;

            //lampda 订阅定义
            LocalEventBus.Subscribe<MySimpleEventData>(
                eventData =>
                {
                    totalData += eventData.Value;
                    return Task.CompletedTask;
                });

            //订阅定义 Transient
            LocalEventBus.Subscribe<MySimpleEventData, QuarrierTransientEventDataHandler>();

            //测试中，一共三个地方订阅成功，lampda订阅成功，QuarrierTransientEventDataHandler订阅成功
            //QuarrierSignalEventDataHandler订阅成功 

            await LocalEventBus.PublishAsync(new MySimpleEventData(1)); //Should handle directly registered class
            await LocalEventBus.PublishAsync(new MySimpleEventData(2)); //Should handle directly registered class
            await LocalEventBus.PublishAsync(new MyInheritEventData(3)); //Should handle derived class too
            await LocalEventBus.PublishAsync(new MyInheritEventData(4)); //Should handle derived class too

            Assert.Equal(10, totalData);
        }

        /// <summary>
        /// 测试订阅的EventData的数据类型继承的时候
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestMyInheritEventDataHandler()
        {
            var totalData = 0;

            LocalEventBus.Subscribe<MyInheritEventData>(
                eventData =>
                {
                    totalData += eventData.Value;
                    return Task.CompletedTask;
                });

            await LocalEventBus.PublishAsync(new MySimpleEventData(1)); //Should not handle
            await LocalEventBus.PublishAsync(new MySimpleEventData(2)); //Should not handle
            await LocalEventBus.PublishAsync(new MyInheritEventData(3)); //Should handle
            await LocalEventBus.PublishAsync(new MyInheritEventData(4)); //Should handle

            Assert.Equal(7, totalData);
        }
    }
}
