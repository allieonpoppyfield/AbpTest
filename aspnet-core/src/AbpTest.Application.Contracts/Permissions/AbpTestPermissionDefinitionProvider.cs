using AbpTest.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpTest.Permissions;

public class AbpTestPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var abpTestGroup = context.AddGroup(AbpTestPermissions.GroupName, L("Permission:AbpTest"));

        var hotelsPermission = abpTestGroup.AddPermission(AbpTestPermissions.Hotels.Default, L("Permission:Hotels"));
        hotelsPermission.AddChild(AbpTestPermissions.Hotels.Create, L("Permission:Hotels.Create"));
        hotelsPermission.AddChild(AbpTestPermissions.Hotels.Edit, L("Permission:Hotels.Edit"));
        hotelsPermission.AddChild(AbpTestPermissions.Hotels.Delete, L("Permission:Hotels.Delete"));

        var roomCategoriesPermission = abpTestGroup.AddPermission(AbpTestPermissions.RoomCategories.Default, L("Permission:RoomCategories"));
        roomCategoriesPermission.AddChild(AbpTestPermissions.RoomCategories.Create, L("Permission:RoomCategories.Create"));
        roomCategoriesPermission.AddChild(AbpTestPermissions.RoomCategories.Edit, L("Permission:RoomCategories.Edit"));
        roomCategoriesPermission.AddChild(AbpTestPermissions.RoomCategories.Delete, L("Permission:RoomCategories.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpTestResource>(name);
    }
}
