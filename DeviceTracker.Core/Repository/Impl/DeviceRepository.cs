using DeviceTracker.Core.DomainModels;
using DeviceTracker.Core.DomainModels.Mertrics;
using DeviceTracker.Core.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DeviceTracker.Core.Repository.Impl;
internal class DeviceRepository : IDeviceRepository
{
    private readonly IAppDbContext _dbContext;

    public DeviceRepository(IAppDbContextFactory dbContext)
    {
        _dbContext = dbContext.CreateDbContext();
    }

    public async Task<IotDevice[]> GetAllDevices(CancellationToken cancellationToken)
    {
        return await _dbContext.Devices
            .Include(device => device.Group) // Include the Group navigation property if needed
            .ToArrayAsync(cancellationToken);
    }

    public async Task<IotDevice[]> GetAllDevicesInAGroup(Group group, CancellationToken cancellationToken)
    {
        return await _dbContext.Devices
            .Where(device => device.GroupId == group.Id)
            .Include(device => device.Group) // Include the Group navigation property if needed
            .ToArrayAsync(cancellationToken);
    }

    public async Task<IotDevice> AddOrUpdateDevice(IotDevice device, CancellationToken cancellationToken)
    {
        if (device.Id > 0)
        {
            await _dbContext.Devices.Where(x => x.Id == device.Id).ExecuteUpdateAsync(x => x
                .SetProperty(d => d.DeviceName, device.DeviceName)
                .SetProperty(d => d.GroupId, device.GroupId), cancellationToken);
        }
        else
        {
            _dbContext.Devices.Add(device);
            await _dbContext.SaveChangesAsync(cancellationToken);
            if (device.Id <= 0)
            {
                throw new InvalidOperationException("Device ID must be greater than zero after adding a new device.");
            }
        }

        return device;
    }

    public Task<VoltageMetric[]> GetAllVoltageMetrics(IotDevice device, CancellationToken cancellationToken)
    {
        return _dbContext.VoltageMetrics
            .Where(metric => metric.DeviceId == device.Id)
            .OrderByDescending(x => x.Instant)
            .ToArrayAsync(cancellationToken);
    }
}
