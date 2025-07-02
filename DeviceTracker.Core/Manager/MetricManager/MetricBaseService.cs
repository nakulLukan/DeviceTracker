using DeviceTracker.Core.Constants;
using DeviceTracker.Core.DomainModels;
using DeviceTracker.Core.Repository.Contracts;
using DeviceTracker.Shared.Dto.Metrics;

namespace DeviceTracker.Core.Manager.MetricManager;
public abstract class MetricBaseService<T>
    where T : MetricBaseDto
{
    protected readonly T Data;
    protected readonly IMetricRepository MetricRepository;
    protected readonly IDeviceRepository DeviceRepository;

    public MetricBaseService(
        T data,
        IMetricRepository metricRepository,
        IDeviceRepository deviceRepository)
    {
        Data = data;
        MetricRepository = metricRepository;
        DeviceRepository = deviceRepository;
    }

    protected async Task<IotDevice> GetDevice()
    {
        IotDevice? device = null;
        try
        {
            device = await DeviceRepository.GetDeviceByName(Data.DeviceName);
        }
        catch (InvalidOperationException)
        {
            // If the device is not found, we create a new one with the default group.
            device = new IotDevice(Data.DeviceName, GroupConstants.DefaultGroup);
            await DeviceRepository.AddOrUpdateDevice(device, default);
        }

        return device;
    }
}
