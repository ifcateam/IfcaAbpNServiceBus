using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Xunit;

namespace NServiceBusTestBase
{
    [DependsOn(typeof(AbpAutofacModule),
        typeof(AbpTestBaseModule))]
    public class TestBaseModule : AbpModule
    {
        public override void OnApplicationInitialization(
            ApplicationInitializationContext context)
        {
            SeedTestData(context);
        }

        private static void SeedTestData(
            ApplicationInitializationContext context)
        {
            using (var scope = context.ServiceProvider.CreateScope())
            {
                scope.ServiceProvider
                    .GetRequiredService<MyTestDataBuild>()
                    .Build();
            }
        }
    }
}
