namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Books");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportBookDto>), xmlRoot);

            StringReader sr = new StringReader(xmlString);

            var booksDto = (List<ImportBookDto>)xmlSerializer.Deserialize(sr);

            var books = new List<Book>();

            foreach (var bookDto in booksDto)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var isDateValid = DateTime.TryParseExact(bookDto.PublishedOn,
                    "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime publishedOn);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var book = new Book()
                {
                    Name = bookDto.Name,
                    Genre = (Genre)bookDto.Genre,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    PublishedOn = publishedOn,
                };

                books.Add(book);

                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var authorsDto = JsonConvert.DeserializeObject<List<ImportAuthorDto>>(jsonString);

            var authors = new List<Author>();

            var booksInDb = context.Books.Select(b => b.Id).ToList();

            foreach (var authorDto in authorsDto)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var authorBooks = new List<AuthorBook>();

                if (authors.Where(a => a.Email == authorDto.Email).Any())
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var author = new Author()
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Phone = authorDto.Phone,
                    Email = authorDto.Email,
                };

                foreach (var bookIdDto in authorDto.Books)
                {
                    var isIdValid = int.TryParse(bookIdDto.Id, out int bookId);

                    if (!isIdValid)
                    {
                        continue;
                    }


                    if (!booksInDb.Contains(bookId))
                    {
                        continue;
                    }

                    var authorBook = new AuthorBook()
                    {
                        BookId = bookId,
                        Author = author
                    };

                    authorBooks.Add(authorBook);
                }

                if (!authorBooks.Any())
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                author.AuthorsBooks = authorBooks;

                var authorFullName = $"{author.FirstName} {author.LastName}";

                sb.AppendLine(string.Format(SuccessfullyImportedAuthor,
                    authorFullName, author.AuthorsBooks.Count));

                authors.Add(author);

            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}