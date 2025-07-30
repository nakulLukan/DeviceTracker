using DeviceTracker.Core.DomainModels.Device;
using DeviceTracker.Core.Repository.Contracts;
using DeviceTracker.Shared.Dto.Metrics;

namespace DeviceTracker.Core.Manager.MetricManager;
public class IsAliveMetricService : MetricBaseService<IsAliveMetricDto>, IMetricService
{
    public IsAliveMetricService(
        IsAliveMetricDto data,
        IMetricRepository metricRepository,
        IDeviceRepository deviceRepository) : base(data, metricRepository, deviceRepository)
    {
    }

    public async Task StoreMetrics()
    {
        IotDevice device = await GetDevice()!;
        var deviceDetails = await DeviceRepository.GetDeviceDetails(device!, default);
        deviceDetails.SignalLastReceivedOn = DateTime.UtcNow;

        var updateCount = await DeviceRepository.UpdateSignalLastReceivedOn(deviceDetails, default);
        if (updateCount == 0)
        {
            throw new InvalidOperationException("Failed to update the device's last received signal time.");
        }
    }
}
