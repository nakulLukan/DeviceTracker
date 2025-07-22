using DeviceTracker.Core.Constants;
using DeviceTracker.Core.DomainModels;
using DeviceTracker.Core.Repository.Contracts;
using FluentResults;
using MediatR;

namespace DeviceTracker.Core.Requests.Device;
public class NewDeviceCommand : IRequest<Result<int>>
{
    public required string DeviceName { get; set; }
}
internal class NewDeviceCommandHandler : IRequestHandler<NewDeviceCommand, Result<int>>
{
    private readonly IDeviceRepository _deviceRepository;

    public NewDeviceCommandHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<Result<int>> Handle(NewDeviceCommand request, CancellationToken cancellationToken)
    {
        if (await _deviceRepository.DeviceExists(request.DeviceName))
        {
            return Result.Fail("DUPLICATE"); // Device already exists
        }
        var device = new IotDevice(request.DeviceName, GroupConstants.DefaultGroup);
        var result = await _deviceRepository.AddOrUpdateDevice(device, cancellationToken);
        return Result.Ok(result.Id); // Return the ID of the newly created device
    }
}

