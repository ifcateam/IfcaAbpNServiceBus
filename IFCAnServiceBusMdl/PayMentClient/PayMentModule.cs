using System;
using System.Collections.Generic;
using System.Text;
using IFCAnServiceBusMdl;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace PayMentClient
{
    [DependsOn(typeof(IFCAnServiceBusModule))]
    public class PayMentModule : AbpModule
    {
        public override void ConfigureServices(
              ServiceConfigurationContext context)
        {
            Configure<IFCAnServiceBusOptions>(options =>
            {
                options.CurrentServiceName = "PayMentClient";
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.UseNServiceBus();
        }
    }
}
