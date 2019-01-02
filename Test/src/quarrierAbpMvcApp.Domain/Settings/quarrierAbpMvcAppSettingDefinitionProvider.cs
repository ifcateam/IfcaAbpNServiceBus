using Volo.Abp.Settings;

namespace quarrierAbpMvcApp.Settings
{
    public class quarrierAbpMvcAppSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(quarrierAbpMvcAppSettings.MySetting1));
        }
    }
}
