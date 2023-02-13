using AbpTest.HotelImages;
using AbpTest.Hotels;
using AbpTest.Images;
using AbpTest.RoomCategories;
using AbpTest.RoomCategoryImages;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace AbpTest.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class AbpTestDbContext :
    AbpDbContext<AbpTestDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<RoomCategory> RoomCategories { get; set; }
    public DbSet<HotelImage> HotelImages { get; set; }
    public DbSet<RoomCategoryImage> RoomCategoryImages { get; set; }

    public AbpTestDbContext(DbContextOptions<AbpTestDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        builder.Entity<Hotel>(b =>
        {
            b.ToTable(AbpTestConsts.DbTablePrefix + "Hotels", AbpTestConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(HotelConsts.MaxNameLength);
            b.Property(x => x.PriceFrom).IsRequired();
        });

        builder.Entity<RoomCategory>(b =>
        {
            b.ToTable(AbpTestConsts.DbTablePrefix + "RoomCategories", AbpTestConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            b.Property(x => x.AreaFrom).IsRequired();
            b.Property(x => x.PriceForDoublePlacement).IsRequired();
            b.Property(x => x.PriceForDoublePlacement).IsRequired();
        });

        builder.Entity<HotelImage>(b =>
        {
            b.ToTable(AbpTestConsts.DbTablePrefix + "HotelImages", AbpTestConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(ImageConsts.MaxNameLength);
            b.Property(x => x.Content).IsRequired();
            b.Property(x => x.Extension).IsRequired().HasMaxLength(ImageConsts.MaxExtensionLength);
        });

        builder.Entity<RoomCategoryImage>(b =>
        {
            b.ToTable(AbpTestConsts.DbTablePrefix + "RoomCategoryImages", AbpTestConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(ImageConsts.MaxNameLength);
            b.Property(x => x.Content).IsRequired();
            b.Property(x => x.Extension).IsRequired().HasMaxLength(ImageConsts.MaxExtensionLength);
        });

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(AbpTestConsts.DbTablePrefix + "YourEntities", AbpTestConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
