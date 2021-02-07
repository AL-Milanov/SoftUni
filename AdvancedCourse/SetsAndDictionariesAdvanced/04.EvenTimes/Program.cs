using System;
using System.Collections.Generic;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];
            int counter = 0;
            int evenTimesNumber = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            foreach (var number in numbers)
            {
                counter = 0;
                foreach (var num in numbers)
                {
                    if (number == num)
                    {
                        counter++;
                    }
                }
                if (counter % 2 == 0)
                {
                    evenTimesNumber = number;
                }
            }
            Console.WriteLine(evenTimesNumber);
        }
    }
}
