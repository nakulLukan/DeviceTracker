using DeviceTracker.Core.DomainModels.Device;
using DeviceTracker.Core.DomainModels.Metrics;

namespace DeviceTracker.Core.DomainModels.Mertrics;
public class PowerMetric : MetricBase
{
    public float P1 { get; private set; }
    public float P2 { get; private set; }
    public float P3 { get; private set; }
    public PowerMetric(IotDevice device, float p1, float p2, float p3) : base(device)
    {
        P1 = p1;
        P2 = p2;
        P3 = p3;
    }

    internal PowerMetric()
    {
    }
}
