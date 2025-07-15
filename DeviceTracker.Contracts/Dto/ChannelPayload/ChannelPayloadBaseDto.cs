namespace DeviceTracker.Shared.Dto.ChannelPayload;

public abstract class ChannelPayloadBaseDto
{
    public abstract string Payload { get; }
    public string SerializePayload()
    {
        return Payload;
    }
}
