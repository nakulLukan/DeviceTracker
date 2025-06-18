using System;

namespace DeviceTracker.Core.DomainModels;
public class IotDevice : DomainBase
{
    public int Id { get; private set; }

    private string? _deviceName;
    public required string DeviceName
    {
        get => _deviceName!;
        set => _deviceName = !string.IsNullOrEmpty(value) ? value : throw new ArgumentNullException(DeviceName);
    }

    public int GroupId { get; private set; }

    public Group? Group { get; private set; }

    public IotDevice(string deviceName, Group group)
    {
        Group = group;
        GroupId = group.Id;
        DeviceName = deviceName;
    }

    public void ChangeGroup(Group group)
    {
        Group = group;
        GroupId = group.Id;
    }

    internal IotDevice()
    {
    }
}
