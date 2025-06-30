using DeviceTracker.Shared.Enums;
using System.Text.Json.Serialization;

namespace DeviceTracker.Shared.Dto.Metrics;

public class MetricBaseDto
{
    [JsonPropertyName("ID")]
    public required string DeviceName { get; set; }

    [JsonPropertyName("T")]
    public required MetricType Type { get; set; }

}
