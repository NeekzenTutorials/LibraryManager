using BusinessObjects.Entity;
using BusinessObjects.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.App
{

    [Table("book")]
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public TypeBook Type { get; set; }
        public int Rate { get; set; }

        public Author Author { get; set; }

        [Column("id_author")]
        public int AuthorId { get; set; }

        public IEnumerable<Library> Libraries { get; set; }

        public Book()
        {
            Libraries = new List<Library>();
        }

        public Book(int id, string name, int pages, TypeBook type, int rate, Author author)
        {
            Id = id;
            Name = name;
            Pages = pages;
            Type = type;
            Rate = rate;
            Author = author;
            Libraries = new List<Library>();
        }

        public override string ToString() => $"Titre: {Name}, Genre: {Type}, Auteur: {Author}";
    }

}
