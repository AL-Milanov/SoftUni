using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family people = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = person[0];
                int age = int.Parse(person[1]);
                people.AddMember(new Person(name, age));
            }

            Person oldestMember = people.GetOldestMember();

            Console.WriteLine(oldestMember.Name + " " + oldestMember.Age);
        }
    }
}
