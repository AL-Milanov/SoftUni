using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string gender = "Female";

        public Kitten(string name, int age) 
            : base(name, age, default)
        {
        }

        public override string Gender => gender;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
