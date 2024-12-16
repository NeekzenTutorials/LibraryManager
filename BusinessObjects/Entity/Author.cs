using BusinessObjects.App;

namespace BusinessObjects.Entity
{
    public class Author : IEntity
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public Author(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Books = new List<Book>();
        }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
