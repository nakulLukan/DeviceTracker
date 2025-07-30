using DeviceTracker.Core.DomainModels.Device;
using DeviceTracker.Core.DomainModels.Metrics;

namespace DeviceTracker.Core.DomainModels.Mertrics;
public class VoltageMetric : MetricBase
{
    public float V1 { get; private set; }
    public float V2 { get; private set; }
    public float V3 { get; private set; }
    public VoltageMetric(IotDevice device, float v1, float v2, float v3) : base(device)
    {
        if (v1 < 0 || v2 < 0 || v3 < 0)
        {
            throw new ArgumentException("Param cannot be less than zero", nameof(v1));
        }
        this.V1 = v1;
        this.V2 = v2;
        this.V3 = v3;
    }

    internal VoltageMetric()
    {
    }
}
