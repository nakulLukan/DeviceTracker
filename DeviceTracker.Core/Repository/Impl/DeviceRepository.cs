using DeviceTracker.Core.DomainModels;
using DeviceTracker.Core.DomainModels.Device;
using DeviceTracker.Core.DomainModels.Mertrics;
using DeviceTracker.Core.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DeviceTracker.Core.Repository.Impl;
internal class DeviceRepository : IDeviceRepository
{
    private readonly IAppDbContext _dbContext;
    private readonly IAppDbContextFactory _dbContextFactory;

    public DeviceRepository(IAppDbContextFactory dbContext)
    {
        _dbContextFactory = dbContext;
        _dbContext = dbContext.CreateDbContext();
    }

    /// <summary>
    /// Function to check if a device with the given name exists in the database.
    /// </summary>
    /// <param name="deviceName"></param>
    /// <returns></returns>
    public async Task<bool> DeviceExists(string deviceName)
    {
        return await _dbContext.Devices.AnyAsync(x => x.DeviceName == deviceName);
    }

    public async Task<IotDevice> GetDeviceByName(string deviceName)
    {
        var device = await _dbContext.Devices
            .Where(x => x.DeviceName == deviceName)
            .FirstAsync();
        device.RegisterRepository(this);
        return device;
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
            device.ClearReferences();
            _dbContext.Devices.Add(device);
            await _dbContext.SaveChangesAsync(cancellationToken);

            if (device.Id <= 0)
            {
                throw new InvalidOperationException("Device ID must be greater than zero after adding a new device.");
            }
        }

        return device;
    }
    public async Task<int> UpdateSignalLastReceivedOn(IotDeviceDetails deviceDetails, CancellationToken cancellationToken)
    {
        return await _dbContext.DeviceDetails
            .Where(x => x.Id == deviceDetails.Id)
            .ExecuteUpdateAsync(x => x.SetProperty(d => d.SignalLastReceivedOn, deviceDetails.SignalLastReceivedOn), cancellationToken);
    }

    public Task<VoltageMetric[]> GetAllVoltageMetrics(IotDevice device, CancellationToken cancellationToken)
    {
        return _dbContext.VoltageMetrics
            .Where(metric => metric.DeviceId == device.Id)
            .OrderByDescending(x => x.Instant)
            .ToArrayAsync(cancellationToken);
    }

    public async Task<VoltageMetric?> GetLatestVoltageMetric(IotDevice device, CancellationToken cancellationToken)
    {
        return await _dbContext.VoltageMetrics
            .Where(x => x.DeviceId == device.Id)
            .OrderByDescending(x => x.Id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public Task Save()
    {
        return _dbContext.SaveChangesAsync();
    }

    public async Task<CurrentMetric?> GetLatestCurrentMetric(IotDevice device, CancellationToken cancellationToken)
    {
        return await _dbContext.CurrentMetrics
           .Where(x => x.DeviceId == device.Id)
           .OrderByDescending(x => x.Id)
           .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PowerMetric?> GetLatestPowerMetric(IotDevice device, CancellationToken cancellationToken)
    {
        return await _dbContext.PowerMetrics
           .Where(x => x.DeviceId == device.Id)
           .OrderByDescending(x => x.Id)
           .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<RelayMetric?> GetLatestRelayMetric(IotDevice device, CancellationToken cancellationToken)
    {
        return await _dbContext.RelayMetrics
           .Where(x => x.DeviceId == device.Id)
           .OrderByDescending(x => x.Id)
           .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<BatteryMetric?> GetLatestBatteryMetric(IotDevice device, CancellationToken cancellationToken)
    {
        return await _dbContext.BatteryMetrics
           .Where(x => x.DeviceId == device.Id)
           .OrderByDescending(x => x.Id)
           .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<LocationMetric?> GetLatestLocationMetric(IotDevice device, CancellationToken cancellationToken)
    {
        return await _dbContext.LocationData
           .Where(x => x.DeviceId == device.Id)
           .OrderByDescending(x => x.Id)
           .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<ExternalInterruptMetric?> GetExternalInterruptMetric(IotDevice device, CancellationToken cancellationToken)
    {
        return await _dbContext.ExternalInterrupts
           .Where(x => x.DeviceId == device.Id)
           .OrderByDescending(x => x.Id)
           .FirstOrDefaultAsync(cancellationToken);
    }

    public IDeviceRepository SpawnRepository()
    {
        return new DeviceRepository(_dbContextFactory);
    }

    public async Task<IotDeviceDetails> GetDeviceDetails(IotDevice device, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.DeviceDetails
           .Where(x => x.DeviceId == device.Id)
           .OrderByDescending(x => x.Id)
           .FirstOrDefaultAsync(cancellationToken);
        if (entity == null)
        {
            entity = new IotDeviceDetails(device);
            entity.ClearReferences();
            _dbContext.DeviceDetails.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        return entity;
    }
}
