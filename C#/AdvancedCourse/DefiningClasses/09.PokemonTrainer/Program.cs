using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Trainer> allTrainers = new List<Trainer>(1);

            while (input != "Tournament")
            {
                string[] token = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = token[0];
                string pokemonName = token[1];
                string element = token[2];
                int health = int.Parse(token[3]);
                bool isAdded = false;

                foreach (var trainer in allTrainers.ToList())
                {
                    if (trainer.TrainerName == trainerName)
                    {
                        isAdded = true;
                        trainer.CollectionOfPokemon.Add(new Pokemon(pokemonName, element, health));
                    }
                }

                if (isAdded == false)
                {
                    allTrainers.Add(new Trainer(trainerName, new List<Pokemon>() { new Pokemon(pokemonName, element, health) }));
                }
                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var trainer in allTrainers)
                {
                    bool haveSuchType = false;

                    foreach (var pokemon in trainer.CollectionOfPokemon)
                    {
                        if (pokemon.Element == command)
                        {
                            trainer.NumberOfBadges++;

                            haveSuchType = true;
                            if (haveSuchType == true)
                            {
                                break;
                            }
                        }
                    }
                    if (haveSuchType == false)
                    {

                        foreach (var pokemon in trainer.CollectionOfPokemon.ToList())
                        {
                            pokemon.Health -= 10;
                            if (pokemon.Health <= 0 && haveSuchType == false)
                            {
                                trainer.CollectionOfPokemon.Remove(pokemon);
                            }

                        }
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var trainer in allTrainers.OrderByDescending(n => n.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.TrainerName} {trainer.NumberOfBadges} {trainer.CollectionOfPokemon.Count}");
            }
        }
    }
}
