using System;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string> print = names => Console.WriteLine(names);
            Array.ForEach(names, print);
            
        }

    }
}
