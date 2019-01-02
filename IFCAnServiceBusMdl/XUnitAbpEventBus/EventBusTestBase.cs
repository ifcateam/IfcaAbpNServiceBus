using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.EventBus.Local;

namespace XUnitAbpEventBus
{
    public class EventBusTestBase : AbpIntegratedTest<EventBusTestModule>
    {
        protected ILocalEventBus LocalEventBus;

        protected EventBusTestBase()
        {
            LocalEventBus = GetRequiredService<ILocalEventBus>();
        }

        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
