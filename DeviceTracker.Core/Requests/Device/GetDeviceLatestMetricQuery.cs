using DeviceTracker.Core.DomainModels.Mertrics;
using DeviceTracker.Core.Repository.Contracts;
using DeviceTracker.Shared.RequestDto;
using FluentResults;
using MediatR;

namespace DeviceTracker.Core.Requests.Device;
public class GetDeviceLatestMetricQuery : IRequest<Result<LatestMetricResponseDto>>
{
    public required string DeviceName { get; set; }
}

public class GetDeviceLatestMetricQueryHandler : IRequestHandler<GetDeviceLatestMetricQuery, Result<LatestMetricResponseDto>>
{
    private readonly IDeviceRepository _deviceRepository;

    public GetDeviceLatestMetricQueryHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<Result<LatestMetricResponseDto>> Handle(GetDeviceLatestMetricQuery request, CancellationToken cancellationToken)
    {
        var device = await _deviceRepository.GetDeviceByName(request.DeviceName);
        var deviceMetrics = await device.GetAllLatestMetrics(cancellationToken);
        LatestMetricResponseDto result = new();
        foreach (var metric in deviceMetrics)
        {
            if (metric is VoltageMetric voltageMetric)
            {
                result.Voltage = new LatestVoltageMetricDto
                {
                    V1 = voltageMetric.V1,
                    V2 = voltageMetric.V2,
                    V3 = voltageMetric.V3,
                };
            }
            else if (metric is CurrentMetric currentMetric)
            {
                result.Current = new LatestCurrentMetricDto
                {
                    I1 = currentMetric.I1,
                    I2 = currentMetric.I2,
                    I3 = currentMetric.I3
                };
            }
            else if (metric is PowerMetric powerMetric)
            {
                result.Power = new LatestPowerMetricDto
                {
                    P1 = powerMetric.P1,
                    P2 = powerMetric.P2,
                    P3 = powerMetric.P3,
                };
            }
            else if (metric is RelayMetric relayMetric)
            {
                result.Relay = new LatestRelayMetricDto
                {
                    StartStopRelay = relayMetric.StartStopRelay,
                    FuelCutRelay = relayMetric.FuelCutRelay,
                };
            }
            else if (metric is BatteryMetric batteryMetric)
            {
                result.Battery = new LatestBatteryDataDto
                {
                    BackupBattery = batteryMetric.BackupBattery,
                    MainBattery = batteryMetric.MainBattery,
                };
            }
            else if (metric is LocationMetric locationMetric)
            {
                result.Location = new LatestLocationDataDto
                {
                    Lat = locationMetric.Lat,
                    Lng = locationMetric.Lng,
                };
            }
        }

        return result;
    }
}

