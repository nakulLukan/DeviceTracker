using DeviceTracker.Core.DomainModels.Device;
using DeviceTracker.Core.DomainModels.Metrics;

namespace DeviceTracker.Core.DomainModels.Mertrics;
public class LocationMetric : MetricBase
{
    /// <summary>
    /// Latitude of the device
    /// </summary>
    public double Lat { get; private set; }

    /// <summary>
    /// Longitude of the device
    /// </summary>
    public double Lng { get; private set; }
    public LocationMetric(IotDevice device, double lat, double lng) : base(device)
    {
        Lat = lat;
        Lng = lng;
    }

    internal LocationMetric()
    {
    }
}
