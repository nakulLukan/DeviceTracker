using DeviceTracker.Core.Contracts;
using DeviceTracker.Shared.Dto.ChannelPayload;
using FluentResults;
using MediatR;

namespace DeviceTracker.Core.Requests.Metric;
public class PublishAllMetricsFetchRequest : IRequest<Result<bool>>
{
    public required string DeviceName { get; set; }
}
public class PublishAllMetricsFetchRequestHandler : IRequestHandler<PublishAllMetricsFetchRequest, Result<bool>>
{
    private readonly IMqttChannel _channel;
    public PublishAllMetricsFetchRequestHandler(IMqttChannel channel)
    {
        _channel = channel;
    }

    public async Task<Result<bool>> Handle(PublishAllMetricsFetchRequest request, CancellationToken cancellationToken)
    {
        var result = await _channel.PublishMessage(request.DeviceName, new ChannelGetPayload(), cancellationToken).ConfigureAwait(false);
        return Result.Ok(result);
    }
}
