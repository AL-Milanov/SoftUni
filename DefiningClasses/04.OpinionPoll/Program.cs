using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                if (age > 30)
                {
                    people.Add(new Person(name, age));
                }
            }

            foreach (var person in people.OrderBy(n => n.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
