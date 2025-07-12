using DeviceTracker.Core.DomainModels.Metrics;
using DeviceTracker.Core.Repository.Contracts;

namespace DeviceTracker.Core.DomainModels;
public class IotDevice : DomainBase
{
    private IDeviceRepository? _repository;

    public int Id { get; private set; }

    private string? _deviceName;
    public string DeviceName
    {
        get => _deviceName!;
        set => _deviceName = !string.IsNullOrEmpty(value) ? value : throw new ArgumentNullException(DeviceName);
    }

    public int GroupId { get; private set; }

    public DateTimeOffset CreatedOn { get; private set; }

    public Group? Group { get; private set; }

    public IotDevice(string deviceName, Group group)
    {
        Group = group;
        GroupId = group.Id;
        DeviceName = deviceName;
        CreatedOn = DateTimeOffset.UtcNow;
    }

    public void RegisterRepository(IDeviceRepository deviceRepository)
    {
        _repository = deviceRepository;
    }

    public void ChangeGroup(Group group)
    {
        Group = group;
        GroupId = group.Id;
    }

    internal IotDevice()
    {
    }

    internal override void ClearReferences()
    {
        Group = null;
    }

    public async Task<MetricBase?[]> GetAllLatestMetrics(CancellationToken cancellationToken)
    {
        var voltageMetricRepository = _repository!.SpawnRepository();
        var currentMetricRepository = _repository!.SpawnRepository();
        var powerMetricRepository = _repository!.SpawnRepository();
        var relayMetricRepository = _repository!.SpawnRepository();
        var batteryMetricRepository = _repository!.SpawnRepository();
        var locationMetricRepository = _repository!.SpawnRepository();

        var voltageMetricTask = voltageMetricRepository!.GetLatestVoltageMetric(this, cancellationToken);
        var currentMetricTask = currentMetricRepository!.GetLatestCurrentMetric(this, cancellationToken);
        var powerMetricTask = powerMetricRepository!.GetLatestPowerMetric(this, cancellationToken);
        var relayMetricTask = relayMetricRepository!.GetLatestRelayMetric(this, cancellationToken);
        var batteryMetricTask = batteryMetricRepository!.GetLatestBatteryMetric(this, cancellationToken);
        var locationMetricTask = locationMetricRepository!.GetLatestLocationMetric(this, cancellationToken);

        await Task.WhenAll(voltageMetricTask, currentMetricTask, powerMetricTask, relayMetricTask, batteryMetricTask, locationMetricTask);
        return [voltageMetricTask.Result, currentMetricTask.Result, powerMetricTask.Result, relayMetricTask.Result, batteryMetricTask.Result, locationMetricTask.Result];
    }
}
