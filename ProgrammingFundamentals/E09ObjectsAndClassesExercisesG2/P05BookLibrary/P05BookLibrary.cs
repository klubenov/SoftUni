using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace P05BookLibrary
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

    class P05BookLibrary
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
            Dictionary<string,double> printDict = new Dictionary<string,double>();
            foreach (var book in library.Books)
            {
                if (!printDict.ContainsKey(book.Author))
                {
                    printDict.Add(book.Author, book.Price);
                }
                else
                {
                    printDict[book.Author] += book.Price;
                }
            }
            foreach (var author in printDict.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{author.Key} -> {author.Value:f2}");
            }
        }
    }
}
