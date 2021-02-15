using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> secondBox = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            int value = 0;


            while (firstBox.Count != 0 && secondBox.Count != 0)
            {
                int firstBoxValue = firstBox.Peek();
                int secondBoxValue = secondBox.Pop();
                int sum = firstBoxValue + secondBoxValue;

                if (sum % 2 == 0)
                {
                    value += sum;
                    firstBox.Dequeue();
                }
                else
                {
                    firstBox.Enqueue(secondBoxValue);
                }
            }

            string outputResult = firstBox.Count == 0 ? "First lootbox is empty" : "Second lootbox is empty";
            string valueResult = value >= 100
                ? $"Your loot was epic! Value: {value}" : $"Your loot was poor... Value: {value}";

            Console.WriteLine(outputResult + Environment.NewLine + valueResult);

        }
    }
}
