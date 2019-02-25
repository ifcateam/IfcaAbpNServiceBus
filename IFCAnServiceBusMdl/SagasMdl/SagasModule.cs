using System;
using IFCAnServiceBusMdl;
using Volo.Abp.Modularity;
using Xunit;

namespace SagasMdl
{
    public class SagasModule : AbpModule
    {
        public override void ConfigureServices(
            ServiceConfigurationContext context)
        {
            Configure<IFCAnServiceBusOptions>(option =>
            {
                option.CurrentServiceName = "PayForMeterSagas";
            });
        }
    }
}
