using DeviceTracker.Core.DomainModels.Metrics;

namespace DeviceTracker.Core.DomainModels.Mertrics;
public class VoltageMetric : MetricBase
{
    public float V1 { get; private set; }
    public VoltageMetric(IotDevice device, float v1) : base(device)
    {
        if (v1 < 0)
        {
            throw new ArgumentException("Param cannot be less than zero", nameof(v1));
        }
        this.V1 = v1;
    }

    internal VoltageMetric()
    {
    }
}
