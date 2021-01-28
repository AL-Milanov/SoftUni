using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
             Func<string, int, bool> function = 
                    (names, number) => names.Sum(name => name) >= number;

            List<string> bestName = names.Where(name => function(name, number)).ToList();
            Console.WriteLine(bestName.First());
        }
    }
}
