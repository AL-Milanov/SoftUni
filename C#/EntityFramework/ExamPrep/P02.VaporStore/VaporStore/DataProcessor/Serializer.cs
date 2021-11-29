namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var gamesDto = context.Genres
				.Where(g => genreNames.Contains(g.Name))
				.ToList()
				.Select(g => new ExportGenresDto
                {
					Id = g.Id,
					Genre = g.Name,
					Games = g.Games
					    .Where(g => g.Purchases.Any())
						.Select(game => new ExportGamesDto
                        {
							Id = game.Id,
							Title = game.Name,
							Developer = game.Developer.Name,
							Tags = string.Join(", ", game.GameTags.Select(t => t.Tag.Name)),
							Players = game.Purchases.Count
                        })
						.OrderByDescending(game => game.Players)
						.ThenBy(game => game.Id)
						.ToList(),
					TotalPlayers = g.Games.Sum(g => g.Purchases.Count)
                })
				.OrderByDescending(g => g.TotalPlayers)
				.ThenBy(g => g.Id)
				.ToList();

			var gamesByGenresJson = JsonConvert.SerializeObject(gamesDto, Formatting.Indented);

			return gamesByGenresJson;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			StringBuilder sb = new StringBuilder();

			var xmlRoot = new XmlRootAttribute("Users");
			var xmlSerializer = new XmlSerializer(typeof(List<ExportUserDto>), xmlRoot);

			var namespaces = new XmlSerializerNamespaces();
			namespaces.Add(string.Empty, string.Empty);

			var usersPurchasesDto = context.Users
				.Where(u => u.Cards.Select(ca => ca.Purchases.Any(p => p.Type.ToString() == storeType)).Any())
				.ToList()
				.Select(u => new ExportUserDto
				{
					Username = u.Username,
					Purchases = u.Cards.SelectMany(c => c.Purchases)
						.Where(p => p.Type.ToString() == storeType)
						.OrderBy(p => p.Date)
						.Select(p => new ExportPurchasesDto
						{
							Card = p.Card.Number,
							Cvc = p.Card.Cvc,
							Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
							Game = new ExportGameDto
							{
								Title = p.Game.Name,
								Genre = p.Game.Genre.Name,
								Price = p.Game.Price,
							}
						})
						.ToList(),
					TotalSpent = u.Cards.SelectMany(c => c.Purchases)
						.Where(p => p.Type.ToString() == storeType)
						.Sum(p => p.Game.Price),
				})
				.Where(u => u.Purchases.Count > 0)
				.OrderByDescending(u => u.TotalSpent)
				.ThenBy(u => u.Username)
				.ToList();

			using var sw = new StringWriter(sb);

			xmlSerializer.Serialize(sw, usersPurchasesDto, namespaces);

			return sb.ToString().TrimEnd();
		}
	}
}