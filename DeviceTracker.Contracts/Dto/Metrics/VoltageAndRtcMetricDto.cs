using System.Text.Json.Serialization;

namespace DeviceTracker.Shared.Dto.Metrics;

public class VoltageAndRtcMetricDto : MetricBaseDto
{
    [JsonPropertyName("VOL")]
    public required VoltageMetricObjectDto Voltage { get; set; }
    [JsonPropertyName("RTC")]
    public required DateTimeOffset Rtc { get; set; }
}

public class VoltageMetricObjectDto
{
    [JsonPropertyName("v1")]
    public required float V1 { get; set; }

    [JsonPropertyName("v2")]
    public required float V2 { get; set; }

    [JsonPropertyName("v3")]
    public required float V3 { get; set; }
}