using System;
using System.Collections.Generic;
using System.Text;
using IFCAnServiceBusMdl;
using IFCAnServiceBusMdl.EndPoint;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace OrderClient
{
    [DependsOn(typeof(IFCAnServiceBusModule))]
    public class OrderClientModule : AbpModule
    {
        public override void ConfigureServices(
            ServiceConfigurationContext context)
        {
            Configure<IFCAnServiceBusOptions>(options =>
            {
                options.CurrentServiceName = "OrderClient";
            });
//            context.Services.GetSingletonInstance<IIFCAEndpoint>();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.UseNServiceBus();
        }
    }
}
