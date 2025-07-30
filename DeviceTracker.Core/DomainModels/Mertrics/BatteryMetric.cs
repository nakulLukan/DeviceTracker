using DeviceTracker.Core.DomainModels.Device;
using DeviceTracker.Core.DomainModels.Metrics;

namespace DeviceTracker.Core.DomainModels.Mertrics;
public class BatteryMetric : MetricBase
{
    /// <summary>
    /// Main battery voltage
    /// </summary>
    public float MainBattery { get; private set; }

    /// <summary>
    /// Backup battery voltage
    /// </summary>
    public float BackupBattery { get; private set; }

    public BatteryMetric(IotDevice device, float mainBattery, float backupBattery) : base(device)
    {
        MainBattery = mainBattery;
        BackupBattery = backupBattery;
    }

    internal BatteryMetric()
    {
    }
}
