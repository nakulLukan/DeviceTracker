using DeviceTracker.Core.Constants;
using DeviceTracker.Core.DomainModels;
using DeviceTracker.Core.DomainModels.Mertrics;
using DeviceTracker.Core.Repository;
using DeviceTracker.Web.Data.Persistance.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace DeviceTracker.Web.Data.Persistance;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IAppDbContext
{
    public DbSet<Group> Groups { get; set; }
    public DbSet<IotDevice> Devices { get; set; }

    #region Metrics
    public DbSet<VoltageMetric> VoltageMetrics { get; set; }
    public DbSet<CurrentMetric> CurrentMetrics { get; set; }
    public DbSet<PowerMetric> PowerMetrics { get; set; }
    public DbSet<RelayMetric> RelayMetrics { get; set; }
    public DbSet<LocationMetric> LocationData { get; set; }
    public DbSet<UptimeMetric> UptimeData { get; set; }
    public DbSet<BatteryMetric> BatteryMetrics { get; set; }
    #endregion
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseAsyncSeeding(async (context, _, cancellationToken)  =>
        {
            var record = await context.Set<Group>().FirstOrDefaultAsync(x => x.Id == GroupConstants.DefaultGroup.Id, cancellationToken);
            if (record == null)
            {
                context.Set<Group>().Add(GroupConstants.DefaultGroup);
                context.SaveChanges();
            }
        });
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly(), t => t.GetInterfaces().Any(i =>
                i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)
            )
        );
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    public override ChangeTracker ChangeTracker => base.ChangeTracker;
}
