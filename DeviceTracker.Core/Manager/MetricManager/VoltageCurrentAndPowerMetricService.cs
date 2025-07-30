using DeviceTracker.Core.DomainModels.Mertrics;
using DeviceTracker.Core.Repository.Contracts;
using DeviceTracker.Shared.Dto.Metrics;

namespace DeviceTracker.Core.Manager.MetricManager;
public class VoltageCurrentAndPowerMetricService : MetricBaseService<VoltageCurrentAndPowerMetricDto>, IMetricService
{
    public VoltageCurrentAndPowerMetricService(
        VoltageCurrentAndPowerMetricDto data,
        IMetricRepository metricRepository,
        IDeviceRepository deviceRepository) : base(data, metricRepository, deviceRepository)
    {
    }

    public async Task StoreMetrics()
    {
        var device = await GetDevice();
        var voltageMetric = new VoltageMetric(device, Data.Voltage.V1, Data.Voltage.V2, Data.Voltage.V3);
        MetricRepository.AddVoltageMetric(voltageMetric);

        var currentMetric = new CurrentMetric(device, Data.Current.I1, Data.Current.I2, Data.Current.I3);
        MetricRepository.AddCurrentMetric(currentMetric);

        var powerMetric = new PowerMetric(device, Data.Power.P1, Data.Power.P2, Data.Power.P3);
        MetricRepository.AddPowerMetric(powerMetric);

        var uptimeMetric = new UptimeMetric(device, Data.IsGeneratorRunning);
        MetricRepository.AddUptimeMetric(uptimeMetric);

        await MetricRepository.Save();
    }
}
