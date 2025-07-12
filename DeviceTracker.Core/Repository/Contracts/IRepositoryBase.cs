using DeviceTracker.Core.DomainModels.Mertrics;

namespace DeviceTracker.Core.Repository.Contracts;
public interface IRepositoryBase<T> 
    where T : IRepositoryBase<T>
{
    T SpawnRepository();
    Task Save();
}
