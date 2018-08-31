using System;
using System.Globalization;
using System.Linq;
using System.Text;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                int result = RemoveBooks(db);

                Console.WriteLine(result);

                //var count = db.Books.Count();
                //Console.WriteLine(count);
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var bookWithLessThan4200Copies = context.Books
                .Where(b => b.Copies < 4200).ToArray();

            var count = bookWithLessThan4200Copies.Count();

            context.Books.RemoveRange(bookWithLessThan4200Copies);
            context.SaveChanges();

            return count;
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.ToArray();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoriesAndTop3RecentBooks = context.Categories.Include(c => c.CategoryBooks)
                .ThenInclude(cb => cb.Book.Title)
                .Select(c => new
                {
                    c.Name,
                    Top3Books = c.CategoryBooks.Select(cb => cb.Book).OrderByDescending(b => b.ReleaseDate).Take(3)
                        .ToArray()
                })
                .OrderBy(c => c.Name)
                .ToArray();

            var sbTop3RecentByCategory = new StringBuilder();

            foreach (var category in categoriesAndTop3RecentBooks)
            {
                sbTop3RecentByCategory.AppendLine($"--{category.Name}");
                foreach (var book in category.Top3Books)
                {
                    sbTop3RecentByCategory.AppendLine($"{book.Title} ({book.ReleaseDate.GetValueOrDefault().Year})");
                }
            }

            return sbTop3RecentByCategory.ToString();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories.Include(c => c.CategoryBooks).ThenInclude(cb => cb.Book)
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToArray();

            var sbCategoriesWithProfit = new StringBuilder();

            foreach (var category in categories)
            {
                sbCategoriesWithProfit.AppendLine($"{category.Name} ${category.TotalProfit}");
            }

            return sbCategoriesWithProfit.ToString();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copiesByAuthor = context.Authors.Include(a => a.Books)
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.TotalCopies)
                .ToArray();

            var copiesAuthors = new StringBuilder();

            foreach (var author in copiesByAuthor)
            {
                copiesAuthors.AppendLine($"{author.FullName} - {author.TotalCopies}");
            }

            return copiesAuthors.ToString();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var count = context.Books
                .Count(b => b.Title.Length > lengthCheck);

            return count;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var stringToCheck = input.ToLower();

            var books = context.Books.Include(b => b.Author)
                .Where(b => b.Author.LastName.ToLower().StartsWith(stringToCheck))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    b.Author
                })
                .ToArray();

            var sbTitlesAuthors = new StringBuilder();

            foreach (var book in books)
            {
                sbTitlesAuthors.AppendLine($"{book.Title} ({book.Author.FirstName} {book.Author.LastName})");
            }

            return sbTitlesAuthors.ToString();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var stringToCheck = input.ToLower();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(stringToCheck))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(x => x)
                .ToArray();

            return string.Join(Environment.NewLine, authors);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var stringToCheck = input.ToLower();

            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(stringToCheck))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateToCheck = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < dateToCheck)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            var sbBooksWithPrices = new StringBuilder();

            foreach (var book in books)
            {
                sbBooksWithPrices.AppendLine($"{book.Title} - {book.EditionType.ToString()} - ${book.Price:f2}");
            }

            return sbBooksWithPrices.ToString();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(' ').ToArray();

            var books = context.Books.Include(b => b.BookCategories).ThenInclude(b => b.Category)
                .Where(b => b.BookCategories.Any(x => categories.Contains(x.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.GetValueOrDefault().Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                }).ToArray();

            var sbBooksWithPrices = new StringBuilder();

            foreach (var book in books)
            {
                sbBooksWithPrices.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sbBooksWithPrices.ToString();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, goldenBooks);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestrictionType = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestrictionType)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }
    }
}
