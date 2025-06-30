using DeviceTracker.Core.Manager.MetricManager;
using DeviceTracker.Core.Repository.Contracts;
using DeviceTracker.Core.Repository.Impl;
using DeviceTracker.Core.Requests.Device;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceTracker.Core;
public static class ServiceRegistry
{

    public static void RegisterCoreServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllDeviceQuery>());
        services.AddScoped<IDeviceRepository, DeviceRepository>();
        services.AddScoped<IMetricRepository, MetricRepository>();

        services.AddScoped<MetricManager>();
    }
}
