using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm
{
    public class Hen : Bird
    {
        private const double weightIncreasePerFood = 0.35;
        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Meat),
            nameof(Seeds)

        };

        public Hen(string name, double weight,double wingSize)
            : base(name, weight, allowedFoods, weightIncreasePerFood, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        
    }
}
