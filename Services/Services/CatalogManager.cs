using DataAccessLayer.Repository;
using BusinessObjects.App;
using BusinessObjects.Enum;

namespace Services.Services
{
    public class CatalogManager
    {
        private readonly BookRepository _bookRepository;

        public CatalogManager(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetCatalog() => _bookRepository.GetAll().ToList();

        public List<Book> GetCatalogue(TypeBook type) => _bookRepository.GetAll().Where(b =>  b.Type == type).ToList();

        public Book GetBook(int index) => _bookRepository.Get(index);
    }
}
