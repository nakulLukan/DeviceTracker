using DeviceTracker.Core.DomainModels;
using DeviceTracker.Core.DomainModels.Mertrics;
using Microsoft.EntityFrameworkCore;

namespace DeviceTracker.Core.Repository;

public interface IAppDbContext
{
    public DbSet<Group> Groups { get; set; }
    public DbSet<IotDevice> Devices { get; set; }
    public DbSet<VoltageMetric> VoltageMetrics { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
