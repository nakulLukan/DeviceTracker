using DeviceTracker.Core.Repository.Contracts;
using DeviceTracker.Shared.Dto.Metrics;
using System.Text.Json;

namespace DeviceTracker.Core.Manager.MetricManager;
public class MetricManager
{
    protected readonly IMetricRepository _metricRepository;
    protected readonly IDeviceRepository _deviceRepository;

    public MetricManager(IMetricRepository metricRepository, IDeviceRepository deviceRepository)
    {
        _metricRepository = metricRepository;
        _deviceRepository = deviceRepository;
    }

    public IMetricService CreateService(string jsonPayload)
    {
        if (string.IsNullOrEmpty(jsonPayload))
        {
            throw new ArgumentException("JSON payload cannot be null or empty.", nameof(jsonPayload));
        }

        var metricBase = System.Text.Json.JsonSerializer.Deserialize<MetricBaseDto>(jsonPayload)!;
        if (metricBase.Type == Shared.Enums.MetricType.IsAlive)
        {
            return new IsAliveMetricService(JsonSerializer.Deserialize<IsAliveMetricDto>(jsonPayload)!, _metricRepository, _deviceRepository);
        }
        else if (metricBase.Type == Shared.Enums.MetricType.LocationRelayAndBattery)
        {
            return new LocationRelayAndBatteryMetricService(JsonSerializer.Deserialize<LocationRelayAndBatteryMetricDto>(jsonPayload)!, _metricRepository, _deviceRepository);
        }
        else if (metricBase.Type == Shared.Enums.MetricType.VoltageCurrentAndPower)
        {
            return new VoltageCurrentAndPowerMetricService(JsonSerializer.Deserialize<VoltageCurrentAndPowerMetricDto>(jsonPayload)!, _metricRepository, _deviceRepository);
        }
        else if (metricBase.Type == Shared.Enums.MetricType.ExternalInterrupt)
        {
            return new ExternalInterruptMetricService(JsonSerializer.Deserialize<ExternalInterruptMetricDto>(jsonPayload)!, _metricRepository, _deviceRepository);
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}