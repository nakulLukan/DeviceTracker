using DeviceTracker.Core.DomainModels.Metrics;

namespace DeviceTracker.Core.DomainModels.Mertrics;
public class UptimeMetric : MetricBase
{
    public TimeOnly Uptime { get; private set; }
    public UptimeMetric(IotDevice device, TimeOnly uptime) : base(device)
    {
        Uptime = uptime;
    }

    internal UptimeMetric()
    {
    }
}
