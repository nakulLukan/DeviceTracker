namespace DeviceTracker.Shared.RequestDto;
public class GetAllDeviceQueryResponseDto
{
    public required int DeviceId { get; set; }
    public required string DeviceName { get; set; }
    public required int GroupId { get; set; }
    public required string GroupName { get; set; }
    public required DateTimeOffset CreatedOn { get; set; }
}
