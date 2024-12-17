using BusinessObjects.App;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Entity
{
    [Table("library")]
    public class Library : IEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Adress {  get; private set; }

        public IEnumerable<Book> Books { get; set; }

        public Library(int id, string name, string adress)
        {
            Id = id;
            Name = name;
            Adress = adress;
            Books = new List<Book>();
        }

        public override string ToString() => $"{Name} Matricule n°{Id} | Location : {Adress} | Nombre de livres : {Books.Count()}";
    }
}
