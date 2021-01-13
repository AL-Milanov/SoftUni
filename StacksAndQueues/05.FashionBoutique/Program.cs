using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(clothes);

            int rackCapacity = int.Parse(Console.ReadLine());
            int allRacksUsed = 1;
            int currentRack = 0;

            while (stack.Count > 0)
            {
                int currentStack = stack.Peek();
                stack.Pop();

                bool isEnoughSpace = currentRack + currentStack <= rackCapacity;

                if (isEnoughSpace)
                {

                    currentRack += currentStack;
                }
                else
                {
                    if (currentStack + currentRack >= rackCapacity)
                    {
                        allRacksUsed++;
                        currentRack = 0;
                        currentRack += currentStack;
                    }

                }
            }
            Console.WriteLine(allRacksUsed);

        }
    }
}
