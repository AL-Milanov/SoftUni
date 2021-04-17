using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();
            int number = int.Parse(Console.ReadLine());

            listOfNumbers = listOfNumbers.FindAll(n => n % number != 0);
            Console.WriteLine(String.Join(" ", listOfNumbers));
        }
    }
}
