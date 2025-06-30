using DeviceTracker.Core.DomainModels;
using DeviceTracker.Core.DomainModels.Mertrics;
using Microsoft.EntityFrameworkCore;

namespace DeviceTracker.Core.Repository;

public interface IAppDbContext
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
    #endregion

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
