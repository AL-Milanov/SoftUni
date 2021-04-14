using System;

namespace CocktailParty
{
    public class Ingredient
    {
        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }

        public string Name { get; set; }

        public int Alcohol { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            string result = $"Ingredient: {Name}" + Environment.NewLine;
            result += $"Quantity: {Quantity}" + Environment.NewLine;
            result += $"Alcohol: {Alcohol}";

            return result;

        }
    }
}
