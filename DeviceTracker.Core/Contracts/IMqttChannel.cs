using DeviceTracker.Shared.Dto.ChannelPayload;

namespace DeviceTracker.Core.Contracts;
public interface IMqttChannel
{
    public Task<bool> PublishMessage(string deviceName, ChannelPayloadBaseDto payload, CancellationToken cancellationToken = default);
}
