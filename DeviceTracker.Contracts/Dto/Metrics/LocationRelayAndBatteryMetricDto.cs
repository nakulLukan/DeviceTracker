using System.Text.Json.Serialization;

namespace DeviceTracker.Shared.Dto.Metrics;

public class LocationRelayAndBatteryMetricDto : MetricBaseDto
{
    [JsonPropertyName("LOC")]
    public required LocationMetricDto Location { get; set; }

    [JsonPropertyName("RLY")]
    public required RelayMetricDto Relay { get; set; }

    [JsonPropertyName("PS")]
    public required BatteryMetricDto Battery { get; set; }
}

public class  LocationMetricDto
{
    [JsonPropertyName("lat")]
    public required double Lat { get; set; }
    
    [JsonPropertyName("lon")]
    public required double Lng { get; set; }
}

public class RelayMetricDto
{
    [JsonPropertyName("sr")]
    public required string StartStopOn { get; set; }

    [JsonPropertyName("fr")]
    public required string FuelCutOn { get; set; }
}

public class BatteryMetricDto
{
    [JsonPropertyName("mb")]
    public required float MainBatteryVoltage { get; set; }

    [JsonPropertyName("bb")]
    public required float BackupBatteryVoltage { get; set; }
}