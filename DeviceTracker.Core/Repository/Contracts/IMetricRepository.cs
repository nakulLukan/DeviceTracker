using DeviceTracker.Core.DomainModels.Mertrics;

namespace DeviceTracker.Core.Repository.Contracts;
public interface IMetricRepository : IRepositoryBase
{
    public void AddVoltageMetric(VoltageMetric metric);
    public void AddLocationMetric(LocationMetric metric);
    public void AddRelayMetric(RelayMetric metric);
    public void AddBatteryMetric(BatteryMetric metric);
    public void AddCurrentMetric(CurrentMetric metric);
    public void AddPowerMetric(PowerMetric metric);
    public void AddUptimeMetric(UptimeMetric metric);
}
