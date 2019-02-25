using System;
using IFCAnServiceBusMdl;
using Volo.Abp.Modularity;
using Xunit;

namespace PaymentDomain
{
    public class PaymentDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<IFCAnServiceBusOptions>(options =>
                {
                    options.CurrentServiceName = "PaymentDomain";
                });
        }
    }
}
