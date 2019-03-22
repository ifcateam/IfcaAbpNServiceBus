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
                op.TestorProduct = ENUM_SERVICBUS_TESTORPRODUCT.Product;
                var per =
                    op.UsePersistenceSetting(ENUM_StoragePersistence.Mysql);
                per.Connections =
                    $"server=192.168.137.51;user=root;database=new_schema_Test;" +
                    $"port=3306;password=123456;AllowUserVariables=True;AutoEnlist=false";
                var tp = op.UseTransportSetting(ENUM_TRANSPORT.Rabbitmq);
                tp.Connections = "host=192.168.137.51;" +
                                 "username=admin;" +
                                 "password=admin";

            });
        }
    }


  
}
