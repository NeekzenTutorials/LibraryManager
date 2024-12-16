using BusinessObjects.App;

namespace DataAccessLayer.Repository
{
    public class BookRepository : IRepository<Book>
    {
        private List<Book> _books;

        public BookRepository(List<Book> books)
        {
            _books = books;
        }

        public IEnumerable<Book> GetAll() => _books;

        public Book Get(int id) => _books.FirstOrDefault(b => b.Id == id);
    }
}
