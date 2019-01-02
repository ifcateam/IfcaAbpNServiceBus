using quarrierAbpMvcApp.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace quarrierAbpMvcApp
{
    [DependsOn(
        typeof(quarrierAbpMvcAppDomainModule),
        typeof(AbpIdentityApplicationModule))]
    public class quarrierAbpMvcAppApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<PermissionOptions>(options =>
            {
                options.DefinitionProviders.Add<quarrierAbpMvcAppPermissionDefinitionProvider>();
            });

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<quarrierAbpMvcAppApplicationAutoMapperProfile>();
            });
        }
    }
}
