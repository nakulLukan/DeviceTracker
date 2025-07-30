using DeviceTracker.Core.DomainModels;
using DeviceTracker.Core.DomainModels.Device;
using DeviceTracker.Core.DomainModels.Mertrics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DeviceTracker.Core.Repository;

public interface IAppDbContext
{
    public DbSet<Group> Groups { get; set; }

    #region Device
    public DbSet<IotDevice> Devices { get; set; }
    public DbSet<IotDeviceDetails> DeviceDetails { get; set; }
    #endregion

    #region Metrics
    public DbSet<ExternalInterruptMetric> ExternalInterrupts { get; set; }
    public DbSet<VoltageMetric> VoltageMetrics { get; set; }
    public DbSet<CurrentMetric> CurrentMetrics { get; set; }
    public DbSet<PowerMetric> PowerMetrics { get; set; }
    public DbSet<RelayMetric> RelayMetrics { get; set; }
    public DbSet<LocationMetric> LocationData { get; set; }
    public DbSet<UptimeMetric> UptimeData { get; set; }
    public DbSet<BatteryMetric> BatteryMetrics { get; set; }
    #endregion

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    public ChangeTracker ChangeTracker { get; }
}
