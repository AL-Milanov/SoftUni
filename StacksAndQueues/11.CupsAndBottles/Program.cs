using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Stack<int> bottles = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int littersWasted = 0;

            while (cups.Count != 0 && bottles.Count != 0)
            {
                int cupValue = cups.Peek();
                int bottleValue = bottles.Peek();

                if (bottleValue > cupValue)
                {
                    littersWasted += bottleValue - cupValue;
                    cups.Dequeue();
                    bottles.Pop();
                }
                else if (cupValue >= bottleValue)
                {
                    while (cupValue > 0 && bottles.Count != 0)
                    {
                        if (cupValue == bottleValue)
                        {
                            cupValue = 0;
                            cups.Dequeue();
                            bottles.Pop();
                        }
                        else if (cupValue > bottleValue)
                        {
                            cupValue -= bottleValue;
                            bottles.Pop();
                            if (bottles.Count != 0)
                            {
                                bottleValue = bottles.Peek();
                            }
                        }
                        else if (bottleValue > cupValue)
                        {
                            littersWasted += bottleValue - cupValue;
                            cupValue -= bottleValue;
                            bottles.Pop();
                            cups.Dequeue();
                        }
                    }
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if(bottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {littersWasted}");
            
        }
    }
}
