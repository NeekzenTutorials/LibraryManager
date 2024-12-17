using BusinessObjects.App;
using BusinessObjects.Enum;
using BusinessObjects.Entity;
using DataAccessLayer.Repository;
namespace Services.Services
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public void RegisterRepository<T>(IRepository<T> repository) where T : class, IEntity
        {
            _repositories[typeof(T)] = repository;
        }

        public IEnumerable<T> GetAll<T>() where T : class, IEntity
        {
            var repository = GetRepository<T>();
            return repository.GetAll();
        }

        public T GetById<T>(int index) where T : class, IEntity
        {
            var _repository = GetRepository<T>();
            return _repository.Get(index);
        }

        private IRepository<T> GetRepository<T>() where T : class, IEntity
        {
            if (_repositories.TryGetValue(typeof(T), out var repository))
            {
                return (IRepository<T>)repository;
            }
            throw new InvalidOperationException($"No repository registered for type {typeof(T)}");
        }
    }
}
