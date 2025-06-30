using DeviceTracker.Web;
using DeviceTracker.Web.Data.Mqtt;
using DeviceTracker.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterServices(builder.Configuration);


var app = builder.Build();

await app.RunMigrationAsync();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<DeviceTracker.Web.Components.App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(DeviceTracker.Web.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();
await app.Services.GetRequiredService<AppMqttChannel>().InitChannelAsync();

app.Run();
