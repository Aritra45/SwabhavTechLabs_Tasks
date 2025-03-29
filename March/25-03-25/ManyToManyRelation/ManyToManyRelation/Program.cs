using ManyToManyRelation.Database;
using ManyToManyRelation.Model;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    public static void AddAuthorBook()
    {
        Book book1 = new Book()
        {
            Title = "DSA",
        };
        Book book2 = new Book()
        {
            Title = "C#",
        };
        var context = new MyContext();
        context.AddRange(
            new Author
            {
                Name = "Aritra",
                Books = new List<Book> { book1 },
            },
            new Author
            {
                Name = "Avishek",
                Books = new List<Book> { book1, book2 },
            }
            );
        context.SaveChanges();
    }

    public static void DisplayByAuthor()
    {
        Console.WriteLine("Enter Author ID: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new MyContext())
        {
            Author author = context.Author.Include(a => a.Books).FirstOrDefault(a => a.AId == id);
            if (author != null)
            {
                Console.WriteLine($"Author: {author.Name}");
                foreach (var book in author.Books)
                {
                    Console.WriteLine($" - {book.Title}");
                }
            }
            else
            {
                Console.WriteLine("Author not found.");
            }
        }
    }

    public static void DisplayByBook()
    {
        Console.WriteLine("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new MyContext())
        {
            Book book = context.Book.Include(a => a.Authors).FirstOrDefault(a => a.BId == id);
            if (book != null)
            {
                Console.WriteLine($"Book: {book.Title}");
                foreach (var author in book.Authors)
                {
                    Console.WriteLine($" - {author.Name}");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }
    private static void Main(string[] args)
    {
        //AddAuthorBook();
        //DisplayByAuthor();
        //DisplayByBook();
    }
}