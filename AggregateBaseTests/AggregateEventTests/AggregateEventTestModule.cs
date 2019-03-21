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

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            
            Configure<IFCAnServiceBusOptions>(op =>
                {
                    op.CurrentServiceName = "AggregateTest";
                    op.TestorProduct = ENUM_SERVICBUS_TESTORPRODUCT.Test;
                    op.LocaLorDistribution = ENUM_LOCALorDISTRIBUTION.Local;
                    op.TransportType = ENUM_TRANSPORT.Rabbitmq;

                });
        }
    }


  
}
