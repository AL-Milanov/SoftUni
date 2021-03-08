using System.Collections.Generic;

namespace WildFarm
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, HashSet<string> allowedFoods, double weightIncreasePerFood, double wingSize) 
            : base(name, weight, allowedFoods, weightIncreasePerFood)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; set; }


        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
