using System;
using System.Collections.Generic;


namespace WildFarm
{
    public abstract class Animal 
    {
        
        public Animal(string name, double weight, HashSet<string> allowedFoods,double weightIncreasePerFood)
        {
            Name = name;
            Weight = weight;
            WeightIncreasePerFood = weightIncreasePerFood;
            AllowedFoods = allowedFoods;

        }

        private HashSet<string> AllowedFoods { get; set; }

        private double WeightIncreasePerFood { get; set; }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }


        public void Eating(Food food)
        {
            if (AllowedFoods.Contains(food.GetType().Name) == false)
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }

            FoodEaten += food.Quantity;

            Weight += food.Quantity * WeightIncreasePerFood;
        }

        public abstract string ProduceSound();

    }
}
