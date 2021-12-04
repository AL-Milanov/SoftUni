namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var rows = new sbyte[] { 1, 2, 3, 4, 5 };

            var theatersDto = context.Theatres
                .ToList()
                .Where(t => t.NumberOfHalls >= numbersOfHalls &&
                    t.Tickets.Count >= 20)
                .Select(t => new ExportTheatersDto
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(p => rows.Contains(p.RowNumber))
                        .Sum(p => p.Price),
                    Tickets = t.Tickets
                        .Where(p => rows.Contains(p.RowNumber))
                        .OrderByDescending(p => p.Price)
                        .Select(p => new ExportTicketsDto
                        {
                            Price = p.Price,
                            RowNumber = p.RowNumber
                        })
                        .ToList()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToList();

            var theatersJson = JsonConvert.SerializeObject(theatersDto, Formatting.Indented);

            return theatersJson;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Plays");
            var xmlSerializer = new XmlSerializer(typeof(List<ExportPlayDto>), xmlRoot);

            using var sw = new StringWriter(sb);

            var playsDto = context.Plays
                .ToList()
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .Where(a => a.IsMainCharacter == true)
                        .Select(a => new ExportActorDto
                        {
                            FullName = a.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(a => a.FullName)
                        .ToList()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToList();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(sw, playsDto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
