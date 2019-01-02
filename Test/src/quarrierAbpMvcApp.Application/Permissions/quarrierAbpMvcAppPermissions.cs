using System;

namespace quarrierAbpMvcApp.Permissions
{
    public static class quarrierAbpMvcAppPermissions
    {
        public const string GroupName = "quarrierAbpMvcApp";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public static string[] GetAll()
        {
            //Return an array of all permissions
            return Array.Empty<string>();
        }
    }
}