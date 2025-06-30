using DeviceTracker.Core.DomainModels.Mertrics;
using DeviceTracker.Core.Repository.Contracts;

namespace DeviceTracker.Core.Repository.Impl;
internal class MetricRepository : IMetricRepository
{
    private readonly IAppDbContext _dbContext;

    public MetricRepository(IAppDbContextFactory dbContext)
    {
        _dbContext = dbContext.CreateDbContext();
    }

    public void AddVoltageMetric(VoltageMetric metric)
    {
        metric.ClearReferences();
        _dbContext.VoltageMetrics.Add(metric);
    }

    public Task Save()
    {
        return _dbContext.SaveChangesAsync();
    }
}
