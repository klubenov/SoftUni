namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Import;
    using System.Linq;
    using VaporStore.Data.Models;
    using System.Globalization;
    using VaporStore.Data.Enums;
    using System.Xml.Serialization;
    using System.IO;

    public static class Deserializer
	{
        private const string ERROR_MSG = "Invalid Data";


        public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            var sb = new StringBuilder();

            var deserializedGameDtos = JsonConvert.DeserializeObject<GameDto[]>(jsonString);

            foreach (var gameDto in deserializedGameDtos)
            {
                var gameTags = new List<GameTag>();

                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ERROR_MSG);
                    continue;
                }

                var developer = context.Developers.FirstOrDefault(d => d.Name == gameDto.Developer);
                var genre = context.Genres.FirstOrDefault(g => g.Name == gameDto.Genre);

                foreach (var tag in gameDto.Tags)
                {
                    var tagFromDb = context.Tags.FirstOrDefault(t => t.Name == tag);

                    if (tagFromDb == null)
                    {
                        tagFromDb = new Tag
                        {
                            Name = tag
                        };

                    }

                    gameTags.Add(new GameTag
                    {
                        Tag = tagFromDb
                    });
                }

                if (developer == null)
                {
                    developer = new Developer
                    {
                        Name = gameDto.Developer
                    };
                }

                if (genre == null)
                {
                    genre = new Genre
                    {
                        Name = gameDto.Genre
                    };
                }

                DateTime releaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate,
                    Developer = developer,
                    Genre = genre,
                    GameTags = gameTags
                };

                context.Games.Add(game);
                context.SaveChanges();

                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var sb = new StringBuilder();

            var deserializedUserDtos = JsonConvert.DeserializeObject<UserDto[]>(jsonString);

            foreach (var userDto in deserializedUserDtos)
            {
                var cards = new List<Card>();
                bool invalidCardOccurence = false;

                if (!IsValid(userDto))
                {
                    sb.AppendLine(ERROR_MSG);
                    continue;
                }

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        sb.AppendLine(ERROR_MSG);
                        invalidCardOccurence = true;
                        break;
                    }
                }

                if (invalidCardOccurence)
                {
                    continue;
                }

                foreach (var cardDto in userDto.Cards)
                {
                    CardType type = Enum.Parse<CardType>(cardDto.Type);

                    var card = new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = type
                    };

                    cards.Add(card);
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = cards
                };

                context.Users.Add(user);

                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(PurchaseDto[]), new XmlRootAttribute("Purchases"));
            var deserializedPurchaseDtos = (PurchaseDto[])serializer.Deserialize(new StringReader(xmlString));

            foreach (var purchaseDto in deserializedPurchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ERROR_MSG);
                    continue;
                }

                var game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);

                PurchaseType type = Enum.Parse<PurchaseType>(purchaseDto.Type);

                var card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);

                DateTime dateTime = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var purchase = new Purchase
                {
                    ProductKey = purchaseDto.ProductKey,
                    Type = type,
                    Card = card,
                    Date = dateTime,
                    Game = game
                };

                context.Purchases.Add(purchase);

                sb.AppendLine($"Imported {purchaseDto.Title} for {card.User.Username}");
            }

            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object obj)
        {
            var validatonContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            return System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, validatonContext, validationResults, true);
        }
    }
}