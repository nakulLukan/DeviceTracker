namespace DeviceTracker.Core.DomainModels.Device;
public class IotDeviceDetails : DomainBase
{
    public long Id { get; private set; }
    public int DeviceId { get; private set; }

    /// <summary>
    /// When the alive signal was last received from the device.
    /// </summary>
    public DateTimeOffset? SignalLastReceivedOn { get; set; }

    public IotDevice? Device { get; private set; }

    public IotDeviceDetails(IotDevice device)
    {
        Device = device ?? throw new ArgumentNullException(nameof(device));
        DeviceId = device.Id;
    }

    internal IotDeviceDetails()
    {
    }

    internal override void ClearReferences()
    {
        Device = null;
    }

}
