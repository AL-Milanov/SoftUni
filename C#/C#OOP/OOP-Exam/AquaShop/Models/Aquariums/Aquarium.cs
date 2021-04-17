using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private readonly ICollection<IDecoration> decorations;
        private readonly ICollection<IFish> allFish;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decorations = new List<IDecoration>();
            allFish = new List<IFish>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations => decorations.ToList();

        public ICollection<IFish> Fish => allFish.ToList();

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (allFish.Count >= Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            allFish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in allFish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            string result = string.Empty;

            result += $"{Name} ({GetType().Name})" +
                Environment.NewLine +
                "Fish: ";
           
            result += allFish.Count == 0
                ? "none" + Environment.NewLine
                : $"{string.Join(", ", allFish.Select(f => f.Name))}" + Environment.NewLine;
            
            result += $"Decorations: {decorations.Count}" +
              Environment.NewLine +
              $"Comfort: {Comfort}";

            return result;
        }

        public bool RemoveFish(IFish fish)
        {
            return allFish.Remove(fish);
        }
    }
}
