using DeviceTracker.Core.DomainModels;
using DeviceTracker.Core.DomainModels.Device;
using DeviceTracker.Core.DomainModels.Mertrics;

namespace DeviceTracker.Core.Repository.Contracts;
public interface IDeviceRepository : IRepositoryBase<IDeviceRepository>
{

    /// <summary>
    /// Function to check if a device with the given name exists in the database.
    /// </summary>
    /// <param name="deviceName"></param>
    /// <returns></returns>
    public Task<bool> DeviceExists(string deviceName);
    public Task<IotDevice> GetDeviceByName(string deviceName);
    public Task<IotDevice[]> GetAllDevices(CancellationToken cancellationToken);
    public Task<IotDevice[]> GetAllDevicesInAGroup(Group group, CancellationToken cancellationToken);
    public Task<IotDevice> AddOrUpdateDevice(IotDevice device, CancellationToken cancellationToken);
    public Task<int> UpdateSignalLastReceivedOn(IotDeviceDetails deviceDetails, CancellationToken cancellationToken);
    public Task<VoltageMetric[]> GetAllVoltageMetrics(IotDevice device, CancellationToken cancellationToken);
    public Task<VoltageMetric?> GetLatestVoltageMetric(IotDevice device, CancellationToken cancellationToken);
    public Task<CurrentMetric?> GetLatestCurrentMetric(IotDevice device, CancellationToken cancellationToken);
    public Task<PowerMetric?> GetLatestPowerMetric(IotDevice device, CancellationToken cancellationToken);
    public Task<RelayMetric?> GetLatestRelayMetric(IotDevice device, CancellationToken cancellationToken);
    public Task<BatteryMetric?> GetLatestBatteryMetric(IotDevice device, CancellationToken cancellationToken);
    public Task<LocationMetric?> GetLatestLocationMetric(IotDevice device, CancellationToken cancellationToken);
    public Task<ExternalInterruptMetric?> GetExternalInterruptMetric(IotDevice device, CancellationToken cancellationToken);
    public Task<IotDeviceDetails> GetDeviceDetails(IotDevice device, CancellationToken cancellationToken);
}
