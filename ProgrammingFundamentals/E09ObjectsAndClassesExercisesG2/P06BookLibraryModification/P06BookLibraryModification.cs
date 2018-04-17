using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06BookLibraryModification
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Pubisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
    }

    public class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }

    class P06BookLibraryModification
    {
        static void Main(string[] args)
        {
            int amount = int.Parse(Console.ReadLine());
            Library library = new Library();
            library.Books = new List<Book>();
            for (int i = 0; i < amount; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                Book currentBook = new Book();
                currentBook.Title = input[0];
                currentBook.Author = input[1];
                currentBook.Pubisher = input[2];
                currentBook.ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                currentBook.ISBN = input[4];
                currentBook.Price = double.Parse(input[5]);
                library.Books.Add(currentBook);
            }
            DateTime afterDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            foreach (var title in library.Books.Where(t => t.ReleaseDate >afterDate).OrderBy(t => t.ReleaseDate).ThenBy(t => t.Title))
            {
                Console.WriteLine($"{title.Title} -> {title.ReleaseDate:dd.MM.yyyy}");
            }
        }

    }
}
