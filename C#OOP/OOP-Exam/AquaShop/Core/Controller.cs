using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly DecorationRepository decorations;
        private readonly Dictionary<string, IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new Dictionary<string, IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            if (aquarium == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquariumName, aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }

            if (decoration == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            if (fish == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            string aquariumType = aquariums[aquariumName].GetType().Name;

            if (aquariumType == nameof(FreshwaterAquarium) && fishType == nameof(FreshwaterFish))
            {
                aquariums[aquariumName].AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium) && fishType == nameof(SaltwaterFish))
            {
                aquariums[aquariumName].AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }

            return OutputMessages.UnsuitableWater;
        }

        public string CalculateValue(string aquariumName)
        {
            decimal sum = aquariums[aquariumName].Decorations.Sum(d => d.Price) +
                          aquariums[aquariumName].Fish.Sum(f => f.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, sum);
        }

        public string FeedFish(string aquariumName)
        {
            int fedFishCount = aquariums[aquariumName].Fish.Count;

            aquariums[aquariumName].Feed();

            return string.Format(OutputMessages.FishFed, fedFishCount);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration,
                    decorationType));
            }

            aquariums[aquariumName].AddDecoration(decoration);
            decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            string result = string.Join(Environment.NewLine, aquariums.Values.Select(a => a.GetInfo()));

            return result;
        }

    }
}
