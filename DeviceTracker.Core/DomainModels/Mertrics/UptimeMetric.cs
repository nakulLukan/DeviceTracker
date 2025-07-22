using DeviceTracker.Core.DomainModels.Metrics;

namespace DeviceTracker.Core.DomainModels.Mertrics;
public class UptimeMetric : MetricBase
{
    public bool IsGeneratorRunning { get; private set; }
    public UptimeMetric(IotDevice device, bool isGeneratorRunning) : base(device)
    {
        IsGeneratorRunning = isGeneratorRunning;
    }

    internal UptimeMetric()
    {
    }
}
