namespace DeviceTracker.Core.DomainModels.Metrics;

public abstract class MetricBase : DomainBase
{
    public long Id { get; private set; }

    public int DeviceId { get; init; }

    public DateTimeOffset Instant { get; set; }

    public IotDevice? Device { get; private set; }

    internal MetricBase(IotDevice device)
    {
        DeviceId = device.Id;
        Device = device;
        Instant = DateTimeOffset.UtcNow;
    }

    internal MetricBase()
    {
    }

    internal override void ClearReferences()
    {
        Device = null;
    }
}
