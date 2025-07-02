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

    public void AddLocationMetric(LocationMetric metric)
    {
        metric.ClearReferences();
        _dbContext.LocationData.Add(metric);
    }

    public void AddRelayMetric(RelayMetric metric)
    {
        metric.ClearReferences();
        _dbContext.RelayMetrics.Add(metric);
    }

    public void AddBatteryMetric(BatteryMetric metric)
    {
        metric.ClearReferences();
        _dbContext.BatteryMetrics.Add(metric);
    }

    public void AddCurrentMetric(CurrentMetric metric)
    {
        metric.ClearReferences();
        _dbContext.CurrentMetrics.Add(metric);
    }

    public void AddPowerMetric(PowerMetric metric)
    {
        metric.ClearReferences();
        _dbContext.PowerMetrics.Add(metric);
    }

    public void AddUptimeMetric(UptimeMetric metric)
    {
        metric.ClearReferences();
        _dbContext.UptimeData.Add(metric);
    }

    public Task Save()
    {
        return _dbContext.SaveChangesAsync();
    }
}
