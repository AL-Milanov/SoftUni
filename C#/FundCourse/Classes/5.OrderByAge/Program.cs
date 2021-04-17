using System;
using System.Collections.Generic;
using System.Linq;


namespace Order_By_Age
{
    class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> command = Console.ReadLine().Split().ToList();
            List<Person> people = new List<Person>();

            while (command[0] != "End")
            {

                string name = command[0].ToString();
                string id = command[1].ToString();
                int age = int.Parse(command[2]);

                Person person = new Person(name, id, age);
                people.Add(person);

                command = Console.ReadLine().Split().ToList();

            }

            foreach (var person in people.OrderBy(x => x.Age))
            {
                Console.WriteLine(person);
            }

        }
    }
}