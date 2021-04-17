using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm
{
    public class Dog : Mammal
    {
        private const double weightIncreasePerFood = 0.40;
        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, allowedFoods, weightIncreasePerFood, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
