using System;
using System.Collections.Generic;
using System.Text;
using IFCAnServiceBusMdl;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace waitListClient
{
    [DependsOn(typeof(IFCAnServiceBusModule))]
    public class waitListClientModule : AbpModule
    {
        public override void ConfigureServices(
              ServiceConfigurationContext context)
        {
            Configure<IFCAnServiceBusOptions>(options =>
            {
                options.CurrentServiceName = "waitListClient";
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.UseNServiceBus();
        }
    }
}
