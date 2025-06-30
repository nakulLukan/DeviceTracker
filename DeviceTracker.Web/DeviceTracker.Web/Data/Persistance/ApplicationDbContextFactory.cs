using DeviceTracker.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace DeviceTracker.Web.Data.Persistance;

public class ApplicationDbContextFactory : IAppDbContextFactory
{
    readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public ApplicationDbContextFactory(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public IAppDbContext CreateDbContext()
    {
        return _dbContextFactory.CreateDbContext();
    }
}