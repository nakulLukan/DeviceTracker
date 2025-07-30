using DeviceTracker.Core.Requests.Device;
using DeviceTracker.Core.Requests.Metric;
using DeviceTracker.Shared.RequestDto;
using DeviceTracker.Web.Client.Contracts.Data.Api;
using FluentResults;
using MediatR;

namespace DeviceTracker.Web.Data.Api;

public class DeviceDataService : IDeviceDataService
{
    private readonly IMediator _mediator;

    public DeviceDataService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<Result<GetAllDeviceQueryResponseDto[]>> GetAllDevicesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await _mediator.Send(new GetAllDeviceQuery(), cancellationToken);
        }
        catch (Exception)
        {
            return Result.Fail("OOPS");
        }
    }

    public async Task<Result<LatestMetricResponseDto>> GetDeviceLatestMetricQuery(string deviceName, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _mediator.Send(new GetDeviceLatestMetricQuery() { DeviceName = deviceName }, cancellationToken);
        }
        catch (Exception)
        {
            return Result.Fail("OOPS");
        }
    }

    public async Task<Result<bool>> PublishAllMetricFetchRequest(string deviceName, CancellationToken cancellationToken = default)
    {
        try
        {
            var result =  await _mediator.Send(new PublishAllMetricsFetchRequest() { DeviceName = deviceName }, cancellationToken);
            return result;
        }
        catch (Exception)
        {
            return Result.Fail("OOPS");
        }
    }

    /// <summary>
    /// Function to register new device by device name
    /// </summary>
    /// <param name="deviceName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Result<int>> RegisterNewDevice(string deviceName, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _mediator.Send(new NewDeviceCommand() { DeviceName = deviceName }, cancellationToken);
        }
        catch (Exception)
        {
            return Result.Fail("OOPS");
        }
    }
}
