using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer(string trainerName, List<Pokemon> pokemon)
        {
            TrainerName = trainerName;
            NumberOfBadges = 0;
            CollectionOfPokemon = pokemon;
        }

        public string TrainerName { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> CollectionOfPokemon { get; set; }

    }
}
