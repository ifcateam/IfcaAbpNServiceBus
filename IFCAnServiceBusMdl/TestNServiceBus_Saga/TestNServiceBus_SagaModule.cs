using System;
using IfcaAbpIocHelper;
using IFCAnServiceBusMdl;
using NServiceBusTestBase;
using PaymentForMeterEFCoreTest;
using SagasMdl;
using Volo.Abp;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Xunit;

namespace TestNServiceBus_Saga
{
    [DependsOn(typeof(PaymentForMeterEFCoreTestModule),
        typeof(SagasModule),
        typeof(AbpDddDomainModule),
        typeof(IFCAnServiceBusModule),
        typeof(IfcaAbpIocHelperModule),
        typeof(TestBaseModule))]
    public class TestNServiceBus_SagaModule : AbpModule
    {
        public override void OnApplicationInitialization(
            ApplicationInitializationContext context)
        {
            context.UseNServiceBus();
        }
    }
}
