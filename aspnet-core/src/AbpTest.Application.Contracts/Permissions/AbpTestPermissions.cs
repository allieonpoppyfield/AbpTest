namespace AbpTest.Permissions;

public static class AbpTestPermissions
{
    public const string GroupName = "AbpTest";

    public static class Hotels
    {
        public const string Default = GroupName + ".Hotels";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class RoomCategories
    {
        public const string Default = GroupName + ".RoomCategories";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
