using DeviceTracker.Shared.RequestDto;
using FluentResults;

namespace DeviceTracker.Web.Client.Contracts.Data.Api;

public interface IDeviceDataService
{
    public Task<Result<GetAllDeviceQueryResponseDto[]>> GetAllDevicesAsync(CancellationToken cancellationToken = default);
    public Task<Result<LatestMetricResponseDto>> GetDeviceLatestMetricQuery(string deviceName, CancellationToken cancellationToken = default);
    public Task<Result<bool>> PublishAllMetricFetchRequest(string deviceName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Function to register new device by device name
    /// </summary>
    /// <param name="deviceName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<Result<int>> RegisterNewDevice(string deviceName, CancellationToken cancellationToken = default);
}
