namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992"));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
           
            var cmdToAgeRestriction = command.ToUpper();

            var booksByAgeRestriction = context.Books
                .ToList()
                .Where(b => b.AgeRestriction.ToString().ToUpper().CompareTo(command.ToUpper()) == 0)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, booksByAgeRestriction);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, goldenBooks);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksByPrice = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = $"${b.Price:f2}"
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksByPrice)
            {
                sb.AppendLine($"{book.Title} - {book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksNotReleasedIn = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, booksNotReleasedIn);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToUpper().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var booksByCategory = context.Books
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
                .Where(b => categories.Contains(b.BookCategories.First().Category.Name.ToUpper()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, booksByCategory);
        }

        //TODO This method need modifications
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var books = context.Books
                .ToList()
                .Where(b => b.ReleaseDate != null)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType.ToString(),
                    Price = b.Price,
                    ReleaseDate = (DateTime)b.ReleaseDate
                })
                .Where(b => DateTime
                    .Compare(DateTime.Parse(b.ReleaseDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture))
                    , DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture)) < 1)
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
