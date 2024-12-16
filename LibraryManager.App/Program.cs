using BusinessObjects.App;
using BusinessObjects.Entity;
using BusinessObjects.Enum;
using DataAccessLayer.Repository;

public class Program
{
    private static void Main(string[] args)
    {
        List<Author> authors = new List<Author>
        {
            new Author(1, "Alexandre", "Dumas"),
            new Author(2, "Remy", "Synave"),
            new Author(3, "Dany", "Capitaine"),
            new Author(4, "Severine", "Lettrez"),
            new Author(5, "George", "Remi"),
            new Author(6, "Maxime", "Chattam")
        };

        List<Book> books = new List<Book>
            {
                new Book(1, "Le conte de Monte Cristo", 900, TypeBook.Aventure, 10, authors[0]),
                new Book(2, "Les trois mousquetaires", 300, TypeBook.Aventure, 9, authors[0]),
                new Book(3, "Apprendre le Java mais pas sur l'île de Java", 900, TypeBook.Enseignement, 10, authors[1]),
                new Book(4, "Le RC Lens, un club pas comme les autres", 900, TypeBook.Histoire, 10, authors[3]),
                new Book(5, "La RGPD, une protection contre l'injustice", 900, TypeBook.Juridique, 10, authors[0]),
                new Book(6, "Les aventures de Tintin : Le temple du Soleil", 300, TypeBook.Aventure, 9, authors[4]),
                new Book(7, "Le Signal", 1800, TypeBook.Horreur, 10, authors[5])
            };

        List<Library> libraries = new List<Library>
            {
                new Library(1, "Bibliothèque Roubaix", "44 Av. Jean Lebas, 59100 Roubaix"),
                new Library(2, "Médiathèque Calais", "16 Rue du Pont Lottin, 62100 Calais")
            };

        foreach (var library in libraries)
        {
            if (library.Id == 1)
            {
                library.Books = books.Where(b => b.Type == TypeBook.Aventure || b.Type == TypeBook.Horreur).ToList();
            }
            else if (library.Id == 2)
            {
                library.Books = books.Where(b => b.Type != TypeBook.Aventure || b.Type != TypeBook.Horreur).ToList();
            }
        }

        BookRepository bookRepository = new BookRepository(books);
        AuthorRepository authorRepository = new AuthorRepository(authors);
        LibraryRepository libraryRepository = new LibraryRepository(libraries);

        try
        {
            // Get All books and Get book with ID 2
            IEnumerable<Book> allBooks = bookRepository.GetAll();
            Book singleBook = bookRepository.Get(2);

            Console.WriteLine("Liste des Livres :");
            foreach (var book in allBooks)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("Détails du Livre avec ID 2 :");
            Console.WriteLine(singleBook);

            Console.WriteLine();

            // Get All Authors and Get Author with ID 1
            IEnumerable<Author> allAuthors = authorRepository.GetAll();
            Author singleAuthor = authorRepository.Get(1);

            Console.WriteLine("Liste des Auteurs :");
            foreach (var author in allAuthors)
            {
                Console.WriteLine(author);
            }

            Console.WriteLine("Détails de l'Auteur avec ID 1 :");
            Console.WriteLine(singleAuthor);

            Console.WriteLine();

            // Display Libraries with their books
            IEnumerable<Library> allLibraries = libraryRepository.GetAll();
            Console.WriteLine("Liste des Bibliothèques et leurs Livres :");
            foreach (var library in allLibraries)
            {
                Console.WriteLine(library);
                foreach (var book in library.Books)
                {
                    Console.WriteLine($"\t{book}");
                }
            }

            Console.WriteLine();

            IEnumerable<Book> adventureBooks = allBooks.Where(b => b.Type == TypeBook.Aventure);

            // Display All Adventure's Books
            Console.WriteLine("Affichage des Livres d'aventure :");
            foreach (Book book in adventureBooks)
            {
                Console.WriteLine(book);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }
}