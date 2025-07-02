using DeviceTracker.Core.DomainModels.Mertrics;
using DeviceTracker.Core.Repository.Contracts;
using DeviceTracker.Shared.Dto.Metrics;

namespace DeviceTracker.Core.Manager.MetricManager;
public class CurrentAndPowerMetricService : MetricBaseService<CurrentAndPowerMetricDto>, IMetricService
{
    public CurrentAndPowerMetricService(
        CurrentAndPowerMetricDto data,
        IMetricRepository metricRepository,
        IDeviceRepository deviceRepository) : base(data, metricRepository, deviceRepository)
    {
    }

    public async Task StoreMetrics()
    {
        var device = await GetDevice();
        var currentMetric = new CurrentMetric(device, Data.Current.I1, Data.Current.I2, Data.Current.I3);
        MetricRepository.AddCurrentMetric(currentMetric);

        var powerMetric = new PowerMetric(device, Data.Power.P1, Data.Power.P2, Data.Power.P3);
        MetricRepository.AddPowerMetric(powerMetric);

        var uptimeMetric = new UptimeMetric(device, new TimeOnly(Data.Uptime.Hr, Data.Uptime.Min));
        MetricRepository.AddUptimeMetric(uptimeMetric);

        await MetricRepository.Save();
    }
}
