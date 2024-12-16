using LibraryManager.App;

public class Program
{
    private static void Main(string[] args)
    {
        List<Book> books = new List<Book>();

        for(int i = 0; i < 5; i++)
        {
            Console.WriteLine("Livre " + i);
            Console.WriteLine("Entrez le nom du livre :");
            books.Add(new Book(Console.ReadLine(), "Aventure"));
        }

        foreach(Book book in books)
            Console.WriteLine(book.DisplayBook());
    }
}