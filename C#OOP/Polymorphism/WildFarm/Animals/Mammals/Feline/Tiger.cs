using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm
{
    public class Tiger : Feline
    {
        private const double weightIncreasePerFood = 1.00;
        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, allowedFoods, weightIncreasePerFood, livingRegion, breed)
        {
        }
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
