using DeviceTracker.Core.DomainModels.Metrics;

namespace DeviceTracker.Core.DomainModels.Mertrics;
public class RelayMetric : MetricBase
{
    /// <summary>
    /// Whether the start/stop relay is on
    /// </summary>
    public bool StartStopRelay { get; private set; }

    /// <summary>
    /// Whether the fuel cut relay is on
    /// </summary>
    public bool FuelCutRelay { get; private set; }
    public RelayMetric(IotDevice device, bool startStopRelay, bool fuelCutRelay) : base(device)
    {
        StartStopRelay = startStopRelay;
        FuelCutRelay = fuelCutRelay;
    }

    internal RelayMetric()
    {
    }
}
