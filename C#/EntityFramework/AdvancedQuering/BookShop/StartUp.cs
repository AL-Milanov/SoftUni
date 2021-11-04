namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            Console.WriteLine(GetBooksByPrice(db));
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
    }
}
