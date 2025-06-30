using DeviceTracker.Core.DomainModels.Mertrics;

namespace DeviceTracker.Core.Repository.Contracts;
public interface IMetricRepository : IRepositoryBase
{
    public void AddVoltageMetric(VoltageMetric metric);
}
