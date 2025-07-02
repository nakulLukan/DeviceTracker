using DeviceTracker.Core.Repository;
using DeviceTracker.Web.Data.Persistance;
using Microsoft.EntityFrameworkCore;

namespace DeviceTracker.Web.Extensions;

public static class DbInitializer
{
    public static Task RunMigrationAsync(this WebApplication app)
    {
        Task.Run(async () =>
        {
            try
            {
                using (var scope = app.Services.CreateScope())
                {
                    var dbContext = (ApplicationDbContext)scope.ServiceProvider.GetRequiredService<IAppDbContextFactory>().CreateDbContext();
                    await dbContext.Database.MigrateAsync();
                    await dbContext.Database.EnsureCreatedAsync();
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Logger.Error(ex, "Failed to run migration");
            }
        });
        return Task.CompletedTask;
    }
}
