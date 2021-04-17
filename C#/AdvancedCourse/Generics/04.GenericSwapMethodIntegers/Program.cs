using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> boxList = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                boxList.Add(input);
            }

            int[] swapIndices = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int firstIndex = swapIndices[0];
            int secondIndex = swapIndices[1];

            Box<int> box = new Box<int>(boxList);

            box.Swap(boxList, firstIndex, secondIndex);
            Console.WriteLine(box);
        }
    }
}
