using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateOfNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<string> listOfNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            listOfNames = new List<string>(listOfNames.Where(n => n.Length <= length));
            Console.WriteLine(String.Join(Environment.NewLine, listOfNames));
        }
    }
}
