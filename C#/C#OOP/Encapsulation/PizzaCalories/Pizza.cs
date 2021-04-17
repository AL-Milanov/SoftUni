using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MaxToppings = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)// ??
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough DoughType 
        {
            get => this.dough;
            set
            {
                this.dough = value;
            }
        } 

        public double TotalCalories
        {
            get => this.DoughType.GetDoughCalories() + this.toppings.Sum(t => t.GetToppingCalories());
        }

        public void AddTopping(Topping topping)
        {

            this.toppings.Add(topping);
            if (this.toppings.Count > MaxToppings)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{MaxToppings}].");
            }
        }
    }
}
