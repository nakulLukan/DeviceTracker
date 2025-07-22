using DeviceTracker.Core.DomainModels.Metrics;

namespace DeviceTracker.Core.DomainModels.Mertrics;
public class ExternalInterruptMetric : MetricBase
{
    public bool E1 { get; private set; }
    public bool E2 { get; private set; }
    public bool E3 { get; private set; }
    public bool E4 { get; private set; }
    public ExternalInterruptMetric(IotDevice device, bool e1, bool e2, bool e3, bool e4) : base(device)
    {
        E1 = e1;
        E2 = e2;
        E3 = e3;
        E4 = e4;
    }

    internal ExternalInterruptMetric()
    {
    }
}
