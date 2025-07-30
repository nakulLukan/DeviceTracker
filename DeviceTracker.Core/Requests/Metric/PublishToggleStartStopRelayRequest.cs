using DeviceTracker.Core.Contracts;
using DeviceTracker.Shared.Dto.ChannelPayload;
using FluentResults;
using MediatR;

namespace DeviceTracker.Core.Requests.Metric;
public class PublishToggleStartStopRelayRequest : IRequest<Result<bool>>
{
    public required string DeviceName { get; set; }
    public required bool TurnOn { get; set; }
}
public class PublishToggleStartStopRelayRequestHandler : IRequestHandler<PublishToggleStartStopRelayRequest, Result<bool>>
{
    private readonly IMqttChannel _channel;
    public PublishToggleStartStopRelayRequestHandler(IMqttChannel channel)
    {
        _channel = channel;
    }

    public async Task<Result<bool>> Handle(PublishToggleStartStopRelayRequest request, CancellationToken cancellationToken)
    {
        var result = await _channel.PublishMessage(
            request.DeviceName,
            request.TurnOn ? new ChannelSSRelayOnPayload() : new ChannelSSRelayOffPayload(),
            cancellationToken).ConfigureAwait(false);
        return Result.Ok(result);
    }
}
