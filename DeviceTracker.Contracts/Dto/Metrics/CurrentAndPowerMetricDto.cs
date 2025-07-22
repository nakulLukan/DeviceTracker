using System.Text.Json.Serialization;

namespace DeviceTracker.Shared.Dto.Metrics;

public class CurrentAndPowerMetricDto : MetricBaseDto
{
    [JsonPropertyName("CT")]
    public required CurrentMetricObjectDto Current { get; set; }

    [JsonPropertyName("PW")]
    public required PowerMetricObjectDto Power { get; set; }

    [JsonPropertyName("GS")]
    public required int GeneratorRunning { get; set; }

    public bool IsGeneratorRunning => GeneratorRunning == 1;
}

public class CurrentMetricObjectDto
{
    [JsonPropertyName("i1")]
    public required float I1 { get; set; }
    [JsonPropertyName("i2")]
    public required float I2 { get; set; }
    [JsonPropertyName("i3")]
    public required float I3 { get; set; }
}

public class PowerMetricObjectDto
{
    [JsonPropertyName("p1")]
    public required float P1 { get; set; }
    [JsonPropertyName("p2")]
    public required float P2 { get; set; }
    [JsonPropertyName("p3")]
    public required float P3 { get; set; }
}