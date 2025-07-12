using DeviceTracker.Core.Requests.Device;
using DeviceTracker.Shared.RequestDto;
using DeviceTracker.Web.Client.Contracts.Data.Api;
using MediatR;

namespace DeviceTracker.Web.Data.Api;

public class DeviceDataService : IDeviceDataService
{
    private readonly IMediator _mediator;

    public DeviceDataService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<GetAllDeviceQueryResponseDto[]> GetAllDevicesAsync(CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new DeviceTracker.Core.Requests.Device.GetAllDeviceQuery(), cancellationToken);
    }

    public async Task<LatestMetricResponseDto> GetDeviceLatestMetricQuery(string deviceName, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new GetDeviceLatestMetricQuery() { DeviceName = deviceName }, cancellationToken);
    }
}
