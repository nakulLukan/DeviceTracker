using DeviceTracker.Core.Manager.MetricManager;
using DeviceTracker.Shared.RequestDto;
using MediatR;

namespace DeviceTracker.Core.Requests.Metric;
public class StoreMetricCommand : IRequest<ResponseData<bool>>
{
    public required string JsonPayload { get; set; }
}
public class StoreMetricCommandHandler : IRequestHandler<StoreMetricCommand, ResponseData<bool>>
{
    private readonly MetricManager _metricManager;

    public StoreMetricCommandHandler(MetricManager metricManager)
    {
        _metricManager = metricManager;
    }

    public async Task<ResponseData<bool>> Handle(StoreMetricCommand request, CancellationToken cancellationToken)
    {
        var service = _metricManager.CreateService(request.JsonPayload);
        try
        {
            await service.StoreMetrics();
            return new(true);
        }
        catch
        {
            return new(false);
        }
    }
}
