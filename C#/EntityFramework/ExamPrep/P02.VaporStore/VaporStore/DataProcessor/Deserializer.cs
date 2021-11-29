namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Enum;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto;

    public static class Deserializer
	{
		private const string ErrorMessage = "Invalid Data";

		private const string SuccessfulImportGameMessage = 
			"Added {0} ({1}) with {2} tags";

		private const string SuccessfulImportUserMessage =
			"Imported {0} with {1} cards";

		private const string SuccessfulImportPurchaseMessage =
			"Imported {0} for {1}";

		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			var gamesDto = JsonConvert.DeserializeObject<List<ImportGameDto>>(jsonString);

			List<Game> games = new List<Game>();
			List<Developer> developers = new List<Developer>();
			List<Genre> genres = new List<Genre>();
			List<Tag> tags = new List<Tag>();

            foreach (var gameDto in gamesDto)
            {

                if (!IsValid(gameDto))
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

				Developer developer = developers.FirstOrDefault(d => d.Name == gameDto.Developer);

                if (developer == null)
                {
					developer = new Developer()
					{
						Name = gameDto.Developer,
					};

					developers.Add(developer);
                }

				Genre genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);

				if (genre == null)
                {
					genre = new Genre()
					{
						Name = gameDto.Genre,
					};

					genres.Add(genre);
                }

				Game game = new Game()
				{
					Name = gameDto.Name,
					Price = gameDto.Price,
					ReleaseDate = DateTime.ParseExact
					(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
					Developer = developer,
					Genre = genre,
				};

				List<GameTag> gameTags = new List<GameTag>();

                foreach (var tagName in gameDto.Tags)
                {
					Tag tag = tags.FirstOrDefault(t => t.Name == tagName);

					if (tag == null)
                    {
						tag = new Tag()
						{
							Name = tagName,
						};
                    }

					tags.Add(tag);

					GameTag gameTag = new GameTag()
					{
						Game = game,
						Tag = tag,
					};

					gameTags.Add(gameTag);
                }

				game.GameTags.AddRange(gameTags);

				games.Add(game);

				sb.AppendLine(string.Format(SuccessfulImportGameMessage, game.Name
					, game.Genre.Name, game.GameTags.Count));
            }

			context.Games.AddRange(games);

			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			var usersDto = JsonConvert.DeserializeObject<List<ImportUserDto>>(jsonString);
			
			var usersDtoFiltered = new List<ImportUserDto>();

            foreach (var userDto in usersDto)
            {
                if (!IsValid(userDto))
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

				var cardsDto = new List<ImportCardDto>();

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
						sb.AppendLine(ErrorMessage);
						continue;
                    }

					var isCardTypeValid = Enum.TryParse(typeof(CardType), cardDto.Type, out var result);

					if (!isCardTypeValid)
                    {
						sb.AppendLine(ErrorMessage);
						continue;
                    }

					cardsDto.Add(cardDto);
                }

				userDto.Cards = cardsDto;

				usersDtoFiltered.Add(userDto);

				sb.AppendLine(string.Format(SuccessfulImportUserMessage, userDto.Username, userDto.Cards.Count));
            }

			var users = Mapper.Map<List<User>>(usersDtoFiltered);

			context.Users.AddRange(users);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			StringBuilder sb = new StringBuilder();

			var xmlRoot = new XmlRootAttribute("Purchases");
			var xmlSerializer = new XmlSerializer(typeof(List<ImportPurchaseDto>), xmlRoot);

			using var sr = new StringReader(xmlString);

			var purchasesDto = (List<ImportPurchaseDto>)xmlSerializer.Deserialize(sr);

			var purchases = new List<Purchase>();

            foreach (var purchaseDto in purchasesDto)
            {
                if (!IsValid(purchaseDto))
                {
					sb.AppendLine(ErrorMessage);

					continue;
                }

				var isTypeValid = Enum.TryParse(typeof(PurchaseType), purchaseDto.Type, out var result);

				if (!isTypeValid)
                {
					sb.AppendLine(ErrorMessage);

					continue;
                }

				var card = context.Cards
					.FirstOrDefault(c => c.Number == purchaseDto.Card);

                if (card == null)
                {
					sb.AppendLine(ErrorMessage);

					continue;
                }

				var game = context.Games
					.FirstOrDefault(g => g.Name == purchaseDto.GameTitle);

				if (game == null)
                {
					sb.AppendLine(ErrorMessage);

					continue;
                }

				var purchase = new Purchase()
				{
					Type = (PurchaseType)Enum.Parse(typeof(PurchaseType), purchaseDto.Type),
					ProductKey = purchaseDto.ProductKey,
					Date = DateTime.ParseExact
					(purchaseDto.Date, "dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture),
					Card = card,
					Game = game,
				};

				purchases.Add(purchase);

				sb.AppendLine(string.Format(SuccessfulImportPurchaseMessage, game.Name, card.User.Username));

            }

			context.Purchases.AddRange(purchases);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}