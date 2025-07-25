﻿using DeviceTracker.Core.Repository.Contracts;
using DeviceTracker.Shared.RequestDto;
using FluentResults;
using MediatR;

namespace DeviceTracker.Core.Requests.Device;
public class GetAllDeviceQuery : IRequest<Result<GetAllDeviceQueryResponseDto[]>>
{
}
internal class GetAllDeviceQueryHandler : IRequestHandler<GetAllDeviceQuery, Result<GetAllDeviceQueryResponseDto[]>>
{
    private readonly IDeviceRepository _deviceRepository;

    public GetAllDeviceQueryHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<Result<GetAllDeviceQueryResponseDto[]>> Handle(GetAllDeviceQuery request, CancellationToken cancellationToken)
    {
        var devices = await _deviceRepository.GetAllDevices(cancellationToken);
        var response = devices.Select(device => new GetAllDeviceQueryResponseDto
        {
            DeviceId = device.Id,
            DeviceName = device.DeviceName,
            GroupId = device.GroupId,
            GroupName = device.Group?.Name ?? string.Empty,
            CreatedOn = device.CreatedOn
        }).ToArray();
        return response;
    }
}

