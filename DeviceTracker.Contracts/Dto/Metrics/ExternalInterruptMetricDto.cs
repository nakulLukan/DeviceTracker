using System.Text.Json.Serialization;

namespace DeviceTracker.Shared.Dto.Metrics;

public class ExternalInterruptMetricDto : MetricBaseDto
{
    [JsonPropertyName("EXI")]
    public required InterruptMetricObjectDto Interrupts { get; set; }
}

public class InterruptMetricObjectDto
{
    [JsonPropertyName("e1")]
    public required int E1 { get; set; }
    [JsonPropertyName("e2")]
    public required int E2 { get; set; }
    [JsonPropertyName("e3")]
    public required int E3 { get; set; }
    [JsonPropertyName("e4")]
    public required int E4 { get; set; }
}