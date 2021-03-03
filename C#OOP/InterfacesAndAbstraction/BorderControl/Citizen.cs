using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : Id
    {

        public Citizen(string name, int age, long id)
        {
            Name = name;
            Age = age;
            IdNumber = id;
        }

        public string Name { get; set; }

        public int Age { get; set; }
        public long IdNumber { get ; private set; }
    }
}
