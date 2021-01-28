using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> evenNumbers = new List<int>(numbers.Where(n => n % 2 == 0).OrderBy(n => n));
            List<int> oddNumbers = new List<int>(numbers.Where(n => n % 2 != 0).OrderBy(n => n));
            List<int> orderedList = new List<int>();
            orderedList.AddRange(evenNumbers);
            orderedList.AddRange(oddNumbers);

            Console.WriteLine(String.Join(" ", orderedList));


            Func<int, int, int> comparer =
                (a, b) =>
                {
                    return 0;
                };
            Array.Sort(numbers, (a,b) => { return; });
        }
    }
}
