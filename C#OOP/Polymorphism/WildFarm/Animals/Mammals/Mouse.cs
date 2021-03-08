using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        private const double weightIncreasePerFood = 0.10;
        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit)
        };

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, allowedFoods, weightIncreasePerFood, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
