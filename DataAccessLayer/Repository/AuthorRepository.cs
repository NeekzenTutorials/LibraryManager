using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class AuthorRepository : IRepository<Author>
    {
        private List<Author> _authors;

        public AuthorRepository(List<Author> authors)
        {
            _authors = authors;
        }

        public IEnumerable<Author> GetAll() => _authors;

        public Author Get(int id) => _authors.FirstOrDefault(a => a.Id == id);
    }
}
