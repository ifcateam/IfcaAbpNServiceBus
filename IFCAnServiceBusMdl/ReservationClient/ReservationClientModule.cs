using System;
using System.Collections.Generic;
using System.Text;
using IFCAnServiceBusMdl;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace ReservationClient
{
    [DependsOn(typeof(IFCAnServiceBusModule))]
    public class ReservationClientModule : AbpModule
    {
        public override void ConfigureServices(
            ServiceConfigurationContext context)
        {
            Configure<IFCAnServiceBusOptions>(options =>
            {
                options.CurrentServiceName = "ReservationClient";
            });
        }

        public override void OnApplicationInitialization(
            ApplicationInitializationContext context)
        {
            context.UseNServiceBus();
        }
    }
}
