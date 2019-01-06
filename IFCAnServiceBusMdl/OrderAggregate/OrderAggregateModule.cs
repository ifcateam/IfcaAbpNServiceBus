using System;
using System.Collections.Generic;
using System.Text;
using IFCAnServiceBusMdl;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace OrderAggregate
{
    [DependsOn(typeof(IFCAnServiceBusModule))]
    public class OrderAggregateModule : AbpModule
    {
        public override void ConfigureServices(
              ServiceConfigurationContext context)
        {
            Configure<IFCAnServiceBusOptions>(options =>
            {
                options.CurrentServiceName = "OrderAggregate";
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.UseNServiceBus();
        }
    }
}
