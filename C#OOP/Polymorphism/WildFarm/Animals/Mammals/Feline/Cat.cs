using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm
{
    public class Cat : Feline
    {
        private const double weightIncreasePerFood = 0.30;
        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Meat)
        };

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, allowedFoods, weightIncreasePerFood, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
