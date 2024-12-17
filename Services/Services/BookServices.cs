using BusinessObjects.App;
using BusinessObjects.Enum;

namespace Services.Services
{
    public class BookServices : IServices
    {
        private readonly RepositoryManager _repositoryManager;

        public BookServices(RepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public List<Book> GetBookByType(TypeBook type) => _repositoryManager.GetAll<Book>().Where(b => b.Type == type).ToList();
    }
}
