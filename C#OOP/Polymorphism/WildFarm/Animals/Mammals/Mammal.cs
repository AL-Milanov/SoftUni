using System.Collections.Generic;

namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, HashSet<string> allowedFoods, double weightIncreasePerFood, string livingRegion) 
            : base(name, weight, allowedFoods, weightIncreasePerFood)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }


        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
