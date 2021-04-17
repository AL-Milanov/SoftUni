using System.Collections.Generic;

namespace WildFarm
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, 
            double weight, HashSet<string> allowedFoods, 
            double weightIncreasePerFood, 
            string livingRegion,
            string breed) 
            : base(name, weight, allowedFoods, weightIncreasePerFood, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }

    }
}
