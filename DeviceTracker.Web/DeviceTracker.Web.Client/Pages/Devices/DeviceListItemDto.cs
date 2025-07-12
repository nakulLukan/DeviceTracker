namespace DeviceTracker.Web.Client.Pages.Devices;

public class DeviceListItemDto
{
    public required string DeviceIdentifier { get; set; }
    public required string DeviceName { get; set; }
    public required string GroupName { get; set; }
    public required DateTimeOffset CreatedOn { get; set; }
}
