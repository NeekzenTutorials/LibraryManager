using BusinessObjects.Entity;
using DataAccessLayer.Repository;

public interface IRepositoryManager
{
    IEnumerable<T> GetAll<T>() where T : class, IEntity;
    T GetById<T>(int id) where T : class, IEntity;
    void RegisterRepository<T>(IGenericRepository<T> repository) where T : class, IEntity;
}