using BusinessObjects.App;
using BusinessObjects.Entity;
using BusinessObjects.Enum;
using DataAccessLayer.Contexts;
using DataAccessLayer.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Services;
using Microsoft.EntityFrameworkCore;

public class Program
{

    private static IHost CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // Enregistrer le DbContext
                services.AddDbContext<LibraryContext>(options =>
                    options.UseSqlite("Data Source=C:\\Users\\Asus\\source\\repos\\LibraryManager\\LibraryManager.App\\ressources\\library.db"));
                // Mettez le chemin absolu vers la base SQLite

                // Enregistrer GenericRepository pour chaque type d'entité
                services.AddTransient<IGenericRepository<Book>, GenericRepository<Book>>();
                services.AddTransient<IGenericRepository<Author>, GenericRepository<Author>>();
                services.AddTransient<IGenericRepository<Library>, GenericRepository<Library>>();

                // Enregistrer RepositoryManager modifié pour utiliser IGenericRepository<T>
                services.AddTransient<IRepositoryManager, RepositoryManager>(serviceProvider =>
                {
                    var bookRepo = serviceProvider.GetRequiredService<IGenericRepository<Book>>();
                    var authorRepo = serviceProvider.GetRequiredService<IGenericRepository<Author>>();
                    var libraryRepo = serviceProvider.GetRequiredService<IGenericRepository<Library>>();

                    var manager = new RepositoryManager();
                    manager.RegisterRepository(bookRepo);
                    manager.RegisterRepository(authorRepo);
                    manager.RegisterRepository(libraryRepo);

                    return manager;
                });

                // Enregistrer BookServices
                services.AddTransient<IBookServices, BookServices>();
            })
            .Build();
    }

    private static void Main(string[] args)
    {
        var host = CreateHostBuilder();

        var repositoryManager = host.Services.GetRequiredService<IRepositoryManager>();
        var bookServices = host.Services.GetRequiredService<IBookServices>();

        try
        {
            // Get All books and Get book with ID 2
            IEnumerable<Book> allBooks = repositoryManager.GetAll<Book>();
            Book singleBook = repositoryManager.GetById<Book>(2);

            Console.WriteLine("Liste des Livres :");
            foreach (var book in allBooks)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("Détails du Livre avec ID 2 :");
            Console.WriteLine(singleBook);

            Console.WriteLine();

            // Get All Authors and Get Author with ID 1
            IEnumerable<Author> allAuthors = repositoryManager.GetAll<Author>();
            Author singleAuthor = repositoryManager.GetById<Author>(1);

            Console.WriteLine("Liste des Auteurs :");
            foreach (var author in allAuthors)
            {
                Console.WriteLine(author);
            }

            Console.WriteLine("Détails de l'Auteur avec ID 1 :");
            Console.WriteLine(singleAuthor);

            Console.WriteLine();

            // Display Libraries with their books
            IEnumerable<Library> allLibraries = repositoryManager.GetAll<Library>();
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

            IEnumerable<Book> adventureBooks = bookServices.GetBookByType(TypeBook.Aventure);

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