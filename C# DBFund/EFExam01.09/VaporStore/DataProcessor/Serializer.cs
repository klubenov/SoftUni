namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var genres = context.Genres.Where(g => genreNames.Contains(g.Name))
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games.Where(gm => gm.Purchases.Count>0).Select(gm => new
                    {
                        Id = gm.Id,
                        Title = gm.Name,
                        Developer = gm.Developer.Name,
                        Tags = string.Join(", ", gm.GameTags.Select(gt => gt.Tag.Name).ToArray()),
                        Players = gm.Purchases.Count
                    }).OrderByDescending(x => x.Players).ThenBy(x => x.Id).ToArray(),
                    TotalPlayers = g.Games.Where(gm => gm.Purchases.Count > 0).Sum(gm => gm.Purchases.Count)
                }).OrderByDescending(x => x.TotalPlayers).ThenBy(x => x.Id).ToArray();

            var json = JsonConvert.SerializeObject(genres, Newtonsoft.Json.Formatting.Indented);

            return json;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            PurchaseType type = Enum.Parse<PurchaseType>(storeType);

            var users = context.Users.Select(u => new UserExportDto
            {
                Username = u.Username,
                Purchases = u.Cards.SelectMany(c => c.Purchases.Where(p => p.Type == type)).Select(p => new PurchaseExportDto
                {
                    Card = p.Card.Number,
                    Cvc = p.Card.Cvc,
                    Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                    Game = new GameExportDto
                    {
                        Title = p.Game.Name,
                        Genre = p.Game.Genre.Name,
                        Price = p.Game.Price
                    }
                }).OrderBy(p => p.Date).ToArray(),
                TotalSpent = u.Cards.SelectMany(c => c.Purchases.Where(p => p.Type == type)).Sum(p => p.Game.Price)
            }).Where(u => u.Purchases.Count() > 0).OrderByDescending(u => u.TotalSpent).ThenBy(u => u.Username).ToArray();


            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(UserExportDto[]), new XmlRootAttribute("Users"));
            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            var result = sb.ToString();
            return result;
        }
	}
}