using DeviceTracker.Core.DomainModels.Mertrics;
using DeviceTracker.Core.Repository.Contracts;
using DeviceTracker.Shared.Dto.Metrics;

namespace DeviceTracker.Core.Manager.MetricManager;
public class ExternalInterruptMetricService : MetricBaseService<ExternalInterruptMetricDto>, IMetricService
{
    public ExternalInterruptMetricService(
        ExternalInterruptMetricDto data,
        IMetricRepository metricRepository,
        IDeviceRepository deviceRepository) : base(data, metricRepository, deviceRepository)
    {
    }

    public async Task StoreMetrics()
    {
        var device = await GetDevice();
        var currentMetric = new ExternalInterruptMetric(device, Data.Interrupts.E1 == 0, Data.Interrupts.E2 == 0, Data.Interrupts.E3 == 0, Data.Interrupts.E4 == 0);
        MetricRepository.AddExternalInterruptMetric(currentMetric);
        await MetricRepository.Save();
    }
}
