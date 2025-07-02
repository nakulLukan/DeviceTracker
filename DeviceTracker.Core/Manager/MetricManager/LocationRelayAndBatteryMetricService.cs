using DeviceTracker.Core.DomainModels.Mertrics;
using DeviceTracker.Core.Repository.Contracts;
using DeviceTracker.Shared.Dto.Metrics;

namespace DeviceTracker.Core.Manager.MetricManager;
public class LocationRelayAndBatteryMetricService : MetricBaseService<LocationRelayAndBatteryMetricDto>, IMetricService
{
    public LocationRelayAndBatteryMetricService(
        LocationRelayAndBatteryMetricDto data,
        IMetricRepository metricRepository,
        IDeviceRepository deviceRepository) : base(data, metricRepository, deviceRepository)
    {
    }

    public async Task StoreMetrics()
    {
        var device = await GetDevice();

        var locationMetric = new LocationMetric(device, Data.Location.Lat, Data.Location.Lng);
        MetricRepository.AddLocationMetric(locationMetric);

        var relayMetric = new RelayMetric(device, Data.Relay.StartStopOn == "ON", Data.Relay.FuelCutOn == "ON");
        MetricRepository.AddRelayMetric(relayMetric);

        var batteryMetric = new BatteryMetric(device, Data.Battery.MainBatteryVoltage, Data.Battery.BackupBatteryVoltage);
        MetricRepository.AddBatteryMetric(batteryMetric);

        await MetricRepository.Save();
    }
}
