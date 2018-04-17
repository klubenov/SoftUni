using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09BookLibrary
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
            string inputFilePath = "../../input.txt";
            string outputFilePath = "../../output.txt";
            File.WriteAllText(outputFilePath, String.Empty);
            List<string> inputLines = File.ReadAllLines(inputFilePath).ToList();
            inputLines.RemoveAt(0);
            Library library = new Library();
            library.Books = new List<Book>();
            for (int i = 0; i < inputLines.Count; i++)
            {
                string[] input = inputLines[i].Split(' ');
                Book currentBook = new Book();
                currentBook.Title = input[0];
                currentBook.Author = input[1];
                currentBook.Pubisher = input[2];
                currentBook.ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                currentBook.ISBN = input[4];
                currentBook.Price = double.Parse(input[5]);
                library.Books.Add(currentBook);
            }
            SortedDictionary<string, double> printDict = new SortedDictionary<string, double>();
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
            foreach (var author in printDict.OrderByDescending(x => x.Value))
            {
                File.AppendAllText(outputFilePath, $"{author.Key} -> {author.Value:f2}");
                File.AppendAllText(outputFilePath, Environment.NewLine);
            }
        }
    }
}
