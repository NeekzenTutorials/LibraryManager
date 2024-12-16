using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class LibraryRepository : IRepository<Library>
    {
        private List<Library> _libraries;

        public LibraryRepository(List<Library> libraries)
        {
            _libraries = libraries;
        }

        public IEnumerable<Library> GetAll() => _libraries;

        public Library Get(int id) => _libraries.FirstOrDefault(l => l.Id == id);
    }
}
