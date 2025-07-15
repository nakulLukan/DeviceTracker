using DeviceTracker.Core;
using DeviceTracker.Core.Constants;
using DeviceTracker.Core.Contracts;
using DeviceTracker.Core.Repository;
using DeviceTracker.Core.Requests.Device;
using DeviceTracker.Web.Client.Contracts.Data.Api;
using DeviceTracker.Web.Components.Account;
using DeviceTracker.Web.Data.Api;
using DeviceTracker.Web.Data.Mqtt;
using DeviceTracker.Web.Data.Persistance;
using DeviceTracker.Web.Data.Persistance.Identity;
using DeviceTracker.Web.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

namespace DeviceTracker.Web;

public static class ServiceRegistry
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddBlazor(services);
        AddAuthentication(services);
        AddDbContext(services, configuration);
        AddIdentity(services);
        AddAppServices(services);
        AddMediatorLogger(services);
        services.RegisterCoreServices();
    }

    private static void AddMediatorLogger(IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    }

    private static void AddAppServices(IServiceCollection services)
    {
        services.AddSingleton<IMqttChannel, AppMqttChannel>();
        services.AddTransient<IDeviceDataService, DeviceDataService>();
    }

    private static void AddBlazor(IServiceCollection services)
    {
        // Add services to the container.
        services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents()
            .AddAuthenticationStateSerialization();

        services.AddCascadingAuthenticationState();
        services.AddMudServices();
        services.AddScoped<IdentityUserAccessor>();
        services.AddScoped<IdentityRedirectManager>();
        services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
    }

    private static void AddAuthentication(IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
            .AddIdentityCookies();
    }

    private static void AddIdentity(IServiceCollection services)
    {
        services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration[AppsettingKeyConstants.ConnectionStrings_DefaultConnection];

        services.AddDbContextFactory<ApplicationDbContext>(options =>
            options
            .UseNpgsql(connectionString));
        services.AddDatabaseDeveloperPageExceptionFilter();
        services.AddSingleton<IAppDbContextFactory, ApplicationDbContextFactory>();
    }
}
