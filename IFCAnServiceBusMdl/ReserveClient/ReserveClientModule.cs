using System;
using System.Collections.Generic;
using System.Text;
using IFCAnServiceBusMdl;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace ReserveClient
{
    [DependsOn(typeof(IFCAnServiceBusModule))]
    public class ReserveClientModule : AbpModule
    {
        public override void ConfigureServices(
              ServiceConfigurationContext context)
        {
            Configure<IFCAnServiceBusOptions>(options =>
            {
                options.CurrentServiceName = "ReserveClient";
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.UseNServiceBus();
        }
    }
}
