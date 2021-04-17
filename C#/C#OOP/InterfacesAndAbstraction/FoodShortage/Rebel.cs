using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage 
{
    public class Rebel : IHaveNameAndAge, IBuyer
    {
        private int food = 0;

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get ; set ; }

        public int Age { get; set; }

        public string Group { get; set; }
        public int Food => food;

        public int BuyFood()
        {
            return food += 5;
        }
    }
}
