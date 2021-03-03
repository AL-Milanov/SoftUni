using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : Id
    {

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            IdNumber = id;
        }

        public string Name { get; set; }

        public int Age { get; set; }
        public string IdNumber { get; set; }
    }
}
