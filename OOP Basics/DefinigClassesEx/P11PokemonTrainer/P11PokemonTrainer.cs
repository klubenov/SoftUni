using System;
using System.Collections.Generic;
using System.Linq;

namespace P11PokemonTrainer
{
    class P11PokemonTrainer
    {
        static void Main(string[] args)
        {
            var trainerList = new List<Trainer>();

            string input = "";

            while ((input = Console.ReadLine()) != "Tournament")
            {
                var trainerData = input.Split();

                var trainer = trainerData[0];
                var pokemonName = trainerData[1];
                var pokemonElement = trainerData[2];
                var pokemonHealth = int.Parse(trainerData[3]);

                if (trainerList.Any(t => t.Name == trainer))
                {
                    trainerList.First(t => t.Name == trainer).PokemonCollectionList
                        .Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }
                else
                {
                    var newTrainer = new Trainer(trainer, trainerList.Count+1);
                    newTrainer.PokemonCollectionList.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                    trainerList.Add(newTrainer);
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainerList)
                {
                    if (trainer.PokemonCollectionList.Any(p=>p.Element==input))
                    {
                        trainer.BadgeCount++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.PokemonCollectionList)
                        {
                            pokemon.Health -= 10;
                        }
                    }
                }
            }

            foreach (var trainer in trainerList.OrderByDescending(t=>t.BadgeCount).ThenBy(t => t.Position))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgeCount} {trainer.PokemonCollectionList.Count(p => p.Health > 0)}");
            }
        }
    }
}
