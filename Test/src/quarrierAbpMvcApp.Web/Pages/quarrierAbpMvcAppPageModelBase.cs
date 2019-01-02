using quarrierAbpMvcApp.Localization.quarrierAbpMvcApp;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace quarrierAbpMvcApp.Pages
{
    public abstract class quarrierAbpMvcAppPageModelBase : AbpPageModel
    {
        protected quarrierAbpMvcAppPageModelBase()
        {
            LocalizationResourceType = typeof(quarrierAbpMvcAppResource);
        }
    }
}