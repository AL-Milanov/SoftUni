using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            int n = numArray[0]; // first set
            int m = numArray[1]; // second set
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondtSet = new HashSet<int>();

            ForLoopMethod(n, firstSet);
            ForLoopMethod(m, secondtSet);
            
            if (n > m )
            {
                CommonElements(firstSet, secondtSet);
            }
            else if (m >= n)
            {
                CommonElements(secondtSet, firstSet);   
            }
            
        }

        private static void ForLoopMethod(int count, HashSet<int> set)
        {
            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());
                set.Add(input);
                
            }
        }

        private static void CommonElements( HashSet<int> biggerSet, HashSet<int> smallerSet)
        {
            foreach (var element in smallerSet)
            {
                foreach (var commonElement in biggerSet)
                {
                    if (commonElement == element)
                    {
                        Console.Write(element + " ");
                    }
                }
            }
        }
    }
}
