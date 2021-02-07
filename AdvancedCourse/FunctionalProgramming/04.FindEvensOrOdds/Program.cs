using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int firstNumber = numbers[0];
            int secondNumber = numbers[1];
            string findNumbers = Console.ReadLine();
            int evenOrOdd = 0;
            if (findNumbers == "odd")
            {
                evenOrOdd = 1;
            }
            List<int> listOfNumbers = new List<int>();
            for (int i = firstNumber; i <= secondNumber; i++)
            {
                listOfNumbers.Add(i);
            }
            var output = listOfNumbers.FindAll(n => n % 2 == evenOrOdd || n % 2 == - evenOrOdd);

            Console.WriteLine(String.Join(" ", output));
        }

    }
}
