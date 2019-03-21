using System;
using IfcaAbpIocHelper;
using IFCAnServiceBusMdl;
using NServiceBusTestBase;
using UsersEFCoreTest;
using Volo.Abp;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Xunit;

namespace AggregateEventTests
{
    [DependsOn(typeof(UsersEFCoreTestModule),
        //        typeof(SagasModule),
        typeof(AbpDddDomainModule),
        typeof(IFCAnServiceBusModule),
        typeof(IfcaAbpIocHelperModule),
        typeof(TestBaseModule))]
    public class AggregateEventTestModule : AbpModule
    {
        public override void OnApplicationInitialization(
            ApplicationInitializationContext context)
        {
            context.UseNServiceBus();
        }
    }


  
}
