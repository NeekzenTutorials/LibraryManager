using BusinessObjects.App;
using BusinessObjects.Enum;

namespace Services.Services
{
    public class BookServices : IBookServices
    {
        private readonly IRepositoryManager _repositoryManager;

        public BookServices(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public List<Book> GetBookByType(TypeBook type) => _repositoryManager.GetAll<Book>().Where(b => b.Type == type).ToList();
    }
}
