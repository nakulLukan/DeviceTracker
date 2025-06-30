using DeviceTracker.Shared.RequestDto;

namespace DeviceTracker.Web.Client.Contracts.Data.Api;

public interface IDeviceDataService
{
    public Task<GetAllDeviceQueryResponseDto[]> GetAllDevicesAsync(CancellationToken cancellationToken = default);
}
