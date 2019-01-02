using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using quarrierAbpMvcApp.Localization.quarrierAbpMvcApp;
using Volo.Abp.UI.Navigation;

namespace quarrierAbpMvcApp.Menus
{
    public class quarrierAbpMvcAppMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<quarrierAbpMvcAppResource>>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem("quarrierAbpMvcApp.Home", l["Menu:Home"], "/"));
        }
    }
}
