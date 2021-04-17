using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> person = new List<Person>();
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                int age = int.Parse(data[1]);
                string town = data[2];

                person.Add(new Person(name, age, town));

                command = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            int matches = 0;


            for (int i = 0; i < person.Count; i++)
            {
                
                int compare = person[index].CompareTo(person[i]);

                if (compare == 0)
                {
                    matches++;
                }
            }

            if (matches > 1)
            {
                Console.WriteLine($"{matches} {person.Count - matches} {person.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
