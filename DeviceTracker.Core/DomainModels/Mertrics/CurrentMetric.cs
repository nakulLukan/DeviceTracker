using DeviceTracker.Core.DomainModels.Device;
using DeviceTracker.Core.DomainModels.Metrics;

namespace DeviceTracker.Core.DomainModels.Mertrics;
public class CurrentMetric : MetricBase
{
    public float I1 { get; private set; }
    public float I2 { get; private set; }
    public float I3 { get; private set; }
    public CurrentMetric(IotDevice device, float i1, float i2, float i3) : base(device)
    {
        I1 = i1;
        I2 = i2;
        I3 = i3;
    }

    internal CurrentMetric()
    {
    }
}
