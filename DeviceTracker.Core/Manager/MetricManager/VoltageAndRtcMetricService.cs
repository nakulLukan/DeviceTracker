using DeviceTracker.Core.DomainModels;
using DeviceTracker.Core.DomainModels.Mertrics;
using DeviceTracker.Core.Repository.Contracts;
using DeviceTracker.Shared.Dto.Metrics;

namespace DeviceTracker.Core.Manager.MetricManager;
public class VoltageAndRtcMetricService : MetricBaseService<VoltageAndRtcMetricDto>, IMetricService
{
    public VoltageAndRtcMetricService(
        VoltageAndRtcMetricDto data,
        IMetricRepository metricRepository,
        IDeviceRepository deviceRepository) : base(data, metricRepository, deviceRepository)
    {
    }

    public async Task StoreMetrics()
    {
        IotDevice? device = await GetDevice();

        var voltageMetric = new VoltageMetric(device!, Data.Voltage.V1, Data.Voltage.V2, Data.Voltage.V3);

        MetricRepository.AddVoltageMetric(voltageMetric);
        await MetricRepository.Save();
    }
}
