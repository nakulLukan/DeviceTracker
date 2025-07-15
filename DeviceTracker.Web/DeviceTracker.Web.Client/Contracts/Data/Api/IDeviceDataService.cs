using DeviceTracker.Shared.RequestDto;

namespace DeviceTracker.Web.Client.Contracts.Data.Api;

public interface IDeviceDataService
{
    public Task<GetAllDeviceQueryResponseDto[]> GetAllDevicesAsync(CancellationToken cancellationToken = default);
    public Task<LatestMetricResponseDto> GetDeviceLatestMetricQuery(string deviceName, CancellationToken cancellationToken = default);
    public Task<ResponseData<bool>> PublishAllMetricFetchRequest(string deviceName, CancellationToken cancellationToken = default);
}
