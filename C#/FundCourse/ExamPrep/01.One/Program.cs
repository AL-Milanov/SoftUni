using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.One
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> biggerNumbers = new List<int>();

            double averageNum = numbers.Average();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > averageNum)
                {
                    biggerNumbers.Add(numbers[i]);
                }
            }
            biggerNumbers.Sort();
            biggerNumbers.Reverse();
            
            
            if (biggerNumbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else if (biggerNumbers.Count <= 5)
            {
                Console.WriteLine(string.Join(" ", biggerNumbers));

            }
            else if (biggerNumbers.Count > 5)
            {
                for (int i = 0; i < biggerNumbers.Count; i++)
                {
                    if (i >= 5)
                    {
                        biggerNumbers.RemoveAt(i) ;
                        i--;
                    }
                }
                Console.WriteLine(string.Join(" ", biggerNumbers));
            }
        }
    }
}
