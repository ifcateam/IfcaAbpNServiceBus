using Microsoft.Extensions.DependencyInjection;
using quarrierAbpMvcApp.Localization.quarrierAbpMvcApp;
using quarrierAbpMvcApp.Settings;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.Resources.AbpValidation;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;
using Volo.Abp.VirtualFileSystem;

namespace quarrierAbpMvcApp
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(AbpAuditingModule),
        typeof(BackgroundJobsDomainModule),
        typeof(AbpAuditLoggingDomainModule)
        )]
    public class quarrierAbpMvcAppDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<quarrierAbpMvcAppDomainModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<quarrierAbpMvcAppResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/quarrierAbpMvcApp");
            });

            Configure<SettingOptions>(options =>
            {
                options.DefinitionProviders.Add<quarrierAbpMvcAppSettingDefinitionProvider>();
            });
        }
    }
}
