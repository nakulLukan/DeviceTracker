using DeviceTracker.Core.Contracts;
using DeviceTracker.Shared.Dto.ChannelPayload;
using FluentResults;
using MediatR;

namespace DeviceTracker.Core.Requests.Metric;
public class PublishToggleFuelCutRelayRequest : IRequest<Result<bool>>
{
    public required string DeviceName { get; set; }
    public required bool TurnOn { get; set; }
}
public class PublishToggleFuelCutRelayRequestHandler : IRequestHandler<PublishToggleFuelCutRelayRequest, Result<bool>>
{
    private readonly IMqttChannel _channel;
    public PublishToggleFuelCutRelayRequestHandler(IMqttChannel channel)
    {
        _channel = channel;
    }

    public async Task<Result<bool>> Handle(PublishToggleFuelCutRelayRequest request, CancellationToken cancellationToken)
    {
        var result = await _channel.PublishMessage(
            request.DeviceName,
            request.TurnOn ? new ChannelFCRelayOnPayload() : new ChannelFCRelayOffPayload(),
            cancellationToken).ConfigureAwait(false);
        return Result.Ok(result);
    }
}
