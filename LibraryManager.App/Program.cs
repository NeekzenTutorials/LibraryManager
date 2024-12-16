using LibraryManager.App;

public class Program
{
    private static void Main(string[] args)
    {
        List<Book> books = new List<Book>();

        Dictionary<string, string> bookInfos = new Dictionary<string, string>{
            { "Le magicien d'Oz", "Aventure" },
            { "Seven", "Thriller" },
            { "Les mysterieuses Cités d'or", "Aventure" },
            { "Harry Potter et la Chambre des Secrets", "Aventure" },
            { "Comment compiler en C", "Educatif" }
        };

        foreach (var info in bookInfos)
        {
            books.Add(new Book(info.Key, info.Value));
        }

        foreach (Book book in books)
            Console.WriteLine(book);
    }
}