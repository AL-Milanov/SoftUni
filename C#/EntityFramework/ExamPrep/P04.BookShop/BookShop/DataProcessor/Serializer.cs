namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authorsDto = context.Authors
                .Select(a => new ExportAuthorsDto
                {
                    AuthorName = a.FirstName + ' ' + a.LastName,
                    Books = a.AuthorsBooks
                        .OrderByDescending(b => b.Book.Price)
                        .Select(b => new ExportBooksDto
                        {
                            BookName = b.Book.Name,
                            BookPrice = b.Book.Price.ToString("f2")
                        })
                        .ToList()
                })
                .ToList()
                .OrderByDescending(a => a.Books.Count)
                .ThenBy(a => a.AuthorName)
                .ToList();

            var authorsJson = JsonConvert.SerializeObject(authorsDto, Formatting.Indented);

            return authorsJson;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Books");
            var xmlSerializer = new XmlSerializer(typeof(List<ExportOldestBookDto>), xmlRoot);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var oldestBookDto = context.Books
                .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Select(b => new ExportOldestBookDto
                {
                    Pages = b.Pages,
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .Take(10)
                .ToList();

            StringWriter sw = new StringWriter(sb);

            xmlSerializer.Serialize(sw, oldestBookDto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}