using System;

namespace PizzaCalories
{
    public class Topping
    {
        private const int MinValue = 1;
        private const int MaxValue = 50;

        private string type;
        private int weight;

        public Topping(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type 
        { 
            get => this.type;
            private set
            {
                string valueToLower = value.ToLower();
                if (valueToLower != "meat" && valueToLower != "veggies" && 
                    valueToLower != "cheese" && valueToLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public int Weight 
        { 
            get => this.weight;
            private set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [{MinValue}..{MaxValue}].");
                }
                this.weight = value;
            }
        }

        public double GetToppingCalories()
        {
            double toppingModifier = GetToppingTypeModifier(this.Type.ToLower());
            return Weight * 2 * toppingModifier;
        }

        private double GetToppingTypeModifier(string type)
        {
            if (type == "meat")
            {
                return 1.2;
            }
            if (type == "veggies")
            {
                return 0.8;
            }
            if (type == "cheese")
            {
                return 1.1;
            }
            return 0.9;
        }
    }
}