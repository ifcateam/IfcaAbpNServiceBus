using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.EventBus.Distributed;

namespace XUnitAbpEventBus.DistributionTest
{
    public class LocalDistributedEventBusTestBase: AbpIntegratedTest<EventBusTestModule>
    {
        protected IDistributedEventBus DistributedEventBus;

        protected LocalDistributedEventBusTestBase()
        {
            DistributedEventBus = GetRequiredService<LocalDistributedEventBus>();
        }

        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
