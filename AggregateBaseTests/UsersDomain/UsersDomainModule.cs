using System;
using IFCAnServiceBusMdl;
using Volo.Abp.Modularity;
using Xunit;

namespace UsersDomain
{
    public class UsersDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
//            Configure<IFCAnServiceBusOptions>(options =>
//                {
//                    options.CurrentServiceName = "PaymentDomain";
//                });
        }
    }
}
