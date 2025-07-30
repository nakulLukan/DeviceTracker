using FluentResults;

namespace DeviceTracker.Web.Client.Contracts.Data.Api;

public interface IMetricDataService
{
    public Task<Result<bool>> PublishToggleStartStopRelayRequest(string deviceName, bool turnOn, CancellationToken cancellationToken = default);
    public Task<Result<bool>> PublishToggleFuelCutRelayRequest(string deviceName, bool turnOn, CancellationToken cancellationToken = default);
}
