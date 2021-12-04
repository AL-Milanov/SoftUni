namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Plays");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportPlayDto>), xmlRoot);

            using StringReader sr = new StringReader(xmlString);

            var playsDto = (List<ImportPlayDto>)xmlSerializer.Deserialize(sr);

            var plays = new List<Play>();

            foreach (var playDto in playsDto)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isDurationValid = TimeSpan.TryParseExact(
                    playDto.Duration, "c", CultureInfo.InvariantCulture, (TimeSpanStyles)DateTimeStyles.None
                    , out var duration);

                if (!isDurationValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (duration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isGenreValid = Enum.TryParse(typeof(Genre), playDto.Genre, out var genre);

                if (!isGenreValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play()
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = (Genre)genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter,
                };

                plays.Add(play);

                sb.AppendLine(string.Format(
                    SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Casts");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportCastsDto>), xmlRoot);

            using var sr = new StringReader(xmlString);

            var castsDto = (List<ImportCastsDto>)xmlSerializer.Deserialize(sr);

            var casts = new List<Cast>();

            foreach (var castDto in castsDto)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isMainCharacterValid = bool.TryParse(castDto.IsMainCharacter, out bool isMainCharacter);

                if (!isMainCharacterValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = isMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId,
                };

                casts.Add(cast);

                var mainOrLesser = isMainCharacter ? "main" : "lesser";

                sb.AppendLine(string.Format(
                    SuccessfulImportActor, cast.FullName, mainOrLesser));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var theatersDto = JsonConvert.DeserializeObject<List<ImportTheatreDto>>(jsonString);

            var theaters = new List<Theatre>();

            foreach (var theatreDto in theatersDto)
            {
                if (!IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var tickets = new List<Ticket>();

                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId,
                    };

                    tickets.Add(ticket);
                }

                var theatre = new Theatre()
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director,
                    Tickets = tickets
                };

                theaters.Add(theatre);

                sb.AppendLine(string.Format(
                    SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));

            }

            context.Theatres.AddRange(theaters);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
