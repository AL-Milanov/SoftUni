using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> boxList = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                boxList.Add(input);
            }

            int[] swapIndices = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int firstIndex = swapIndices[0];
            int secondIndex = swapIndices[1];

            Box<string> box = new Box<string>(boxList);

            box.Swap(boxList, firstIndex, secondIndex);
            Console.WriteLine(box);
        }
    }
}
