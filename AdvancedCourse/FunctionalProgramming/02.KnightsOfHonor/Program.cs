using System;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string> knights = names => Console.WriteLine($"Sir {names}");
            Array.ForEach(names, knights);
        }
    }
}
