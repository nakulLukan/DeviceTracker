namespace DeviceTracker.Shared.RequestDto;

public class LatestMetricResponseDto
{
    public LatestVoltageMetricDto? Voltage { get; set; }
    public LatestCurrentMetricDto? Current { get; set; }
    public LatestPowerMetricDto? Power { get; set; }
    public LatestLocationDataDto? Location { get; set; }
    public LatestBatteryDataDto? Battery { get; set; }
    public LatestRelayMetricDto? Relay { get; set; }
    public LatestExternalInterruptDto? ExternalInterrupt { get; set; }
}

public class LatestVoltageMetricDto
{
    public float V1 { get; set; }
    public float V2 { get; set; }
    public float V3 { get; set; }
}

public class LatestCurrentMetricDto
{
    public float I1 { get; set; }
    public float I2 { get; set; }
    public float I3 { get; set; }
}

public class LatestPowerMetricDto
{
    public float P1 { get; set; }
    public float P2 { get; set; }
    public float P3 { get; set; }
}

public class LatestLocationDataDto
{
    public double Lat { get; set; }
    public double Lng { get; set; }
}

public class LatestRelayMetricDto
{
    public bool StartStopRelay { get; set; }
    public bool FuelCutRelay { get; set; }
}

public class LatestBatteryDataDto
{
    public float MainBattery { get; set; }
    public float BackupBattery { get; set; }
}

public class LatestExternalInterruptDto
{
    public bool? E1 { get; set; }
    public bool? E2 { get; set; }
    public bool? E3 { get; set; }
    public bool? E4 { get; set; }
}