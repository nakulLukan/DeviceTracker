namespace DeviceTracker.Core.Repository;

public interface IAppDbContextFactory
{
    IAppDbContext CreateDbContext();
}
