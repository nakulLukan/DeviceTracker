using DeviceTracker.Core.DomainModels;
using DeviceTracker.Core.DomainModels.Mertrics;

namespace DeviceTracker.Core.Repository.Contracts;
public interface IDeviceRepository
{
    public Task<IotDevice[]> GetAllDevices(CancellationToken cancellationToken);
    public Task<IotDevice[]> GetAllDevicesInAGroup(Group group, CancellationToken cancellationToken);
    public Task<IotDevice> AddOrUpdateDevice(IotDevice device, CancellationToken cancellationToken);
    public Task<VoltageMetric[]> GetAllVoltageMetrics(IotDevice device, CancellationToken cancellationToken);
}
