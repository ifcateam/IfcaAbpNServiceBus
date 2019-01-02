using quarrierAbpMvcApp.Localization.quarrierAbpMvcApp;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace quarrierAbpMvcApp.Permissions
{
    public class quarrierAbpMvcAppPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(quarrierAbpMvcAppPermissions.GroupName);

            //Define your own permissions here. Examaple:
            //myGroup.AddPermission(quarrierAbpMvcAppPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<quarrierAbpMvcAppResource>(name);
        }
    }
}
