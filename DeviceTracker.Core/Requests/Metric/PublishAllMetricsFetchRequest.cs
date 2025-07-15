using DeviceTracker.Core.Contracts;
using DeviceTracker.Shared.Dto.ChannelPayload;
using DeviceTracker.Shared.RequestDto;
using MediatR;

namespace DeviceTracker.Core.Requests.Metric;
public class PublishAllMetricsFetchRequest : IRequest<ResponseData<bool>>
{
    public required string DeviceName { get; set; }
}
public class PublishAllMetricsFetchRequestHandler : IRequestHandler<PublishAllMetricsFetchRequest, ResponseData<bool>>
{
    private readonly IMqttChannel _channel;
    public PublishAllMetricsFetchRequestHandler(IMqttChannel channel)
    {
        _channel = channel;
    }

    public async Task<ResponseData<bool>> Handle(PublishAllMetricsFetchRequest request, CancellationToken cancellationToken)
    {
        var result = await _channel.PublishMessage(request.DeviceName, new ChannelGetPayload(), cancellationToken).ConfigureAwait(false);
        return new ResponseData<bool>(result);
    }
}
