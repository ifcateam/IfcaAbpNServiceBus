using System;
using System.Collections.Generic;
using System.Text;
using IFCAnServiceBusMdl;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace SagaService
{
    [DependsOn(typeof(
        IFCAnServiceBusModule))]
    public class SagaServiceModule : AbpModule
    {
        public override void ConfigureServices(
              ServiceConfigurationContext context)
        {
            Configure<IFCAnServiceBusOptions>(options =>
            {
                options.CurrentServiceName = "SagaService";
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.UseNServiceBus();
        }
    }
}
