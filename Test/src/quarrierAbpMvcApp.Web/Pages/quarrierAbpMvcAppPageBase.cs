using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using quarrierAbpMvcApp.Localization.quarrierAbpMvcApp;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace quarrierAbpMvcApp.Pages
{
    public abstract class quarrierAbpMvcAppPageBase : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<quarrierAbpMvcAppResource> L { get; set; }
    }
}
