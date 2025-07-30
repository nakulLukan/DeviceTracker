using DeviceTracker.Core.Requests.Metric;
using DeviceTracker.Web.Client.Contracts.Data.Api;
using FluentResults;
using MediatR;

namespace DeviceTracker.Web.Data.Api;

public class MetricDataDevice : IMetricDataService
{
    private readonly IMediator _mediator;

    public MetricDataDevice(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<Result<bool>> PublishToggleStartStopRelayRequest(string deviceName, bool turnOn, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _mediator.Send(new PublishToggleStartStopRelayRequest()
            {
                DeviceName = deviceName,
                TurnOn = turnOn
            }, cancellationToken);
        }
        catch (Exception)
        {
            return Result.Fail("OOPS");
        }
    }

    public async Task<Result<bool>> PublishToggleFuelCutRelayRequest(string deviceName, bool turnOn, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _mediator.Send(new PublishToggleFuelCutRelayRequest()
            {
                DeviceName = deviceName,
                TurnOn = turnOn
            }, cancellationToken);
        }
        catch (Exception)
        {
            return Result.Fail("OOPS");
        }
    }
}
