using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace quarrierAbpMvcApp.Branding
{
    [Dependency(ReplaceServices = true)]
    public class quarrierAbpMvcAppBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "quarrierAbpMvcApp";
    }
}
