using DeviceTracker.Core.DomainModels.Mertrics;
using DeviceTracker.Core.Repository.Contracts;
using DeviceTracker.Shared.Dto.Metrics;

namespace DeviceTracker.Core.Manager.MetricManager;
public class VoltageAndRtcMetricService : IMetricService
{
    private readonly VoltageAndRtcMetricDto _data;
    private readonly IMetricRepository _metricRepository;
    private readonly IDeviceRepository _deviceRepository;

    public VoltageAndRtcMetricService(
        VoltageAndRtcMetricDto data,
        IMetricRepository metricRepository,
        IDeviceRepository deviceRepository)
    {
        _data = data;
        _metricRepository = metricRepository;
        _deviceRepository = deviceRepository;
    }

    public async Task StoreMetrics()
    {
        var device = await _deviceRepository.GetDeviceByName(_data.DeviceName);
        var voltageMetric = new VoltageMetric(device, _data.Voltage.V1, _data.Voltage.V2, _data.Voltage.V3);

        _metricRepository.AddVoltageMetric(voltageMetric);
        await _metricRepository.Save();
    }
}
