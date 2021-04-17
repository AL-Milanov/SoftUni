using System;
using System.Collections.Generic;
using System.Linq;

namespace P03
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine()
                                                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                         .Select(int.Parse)
                                                         .ToArray());

            Queue<int> scarfs = new Queue<int>(Console.ReadLine()
                                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                        .Select(int.Parse)
                                                        .ToArray());
            List<int> sets = new List<int>();

            int increaseValue = 0;
            int biggestPrice = -1;

            while (true)
            {

                int price = 0;

                if (!hats.Any() || !scarfs.Any())
                {
                    break;
                }

                int hat = hats.Peek() + increaseValue;
                int scarf = scarfs.Peek();

                if (hat > scarf)
                {
                    price = hat + scarf;

                    if (price > biggestPrice)
                    {
                        biggestPrice = price;
                    }

                    hats.Pop();
                    scarfs.Dequeue();
                    increaseValue = 0;
                    sets.Add(price);
                }
                else if (scarf > hat)
                {
                    hats.Pop();
                    increaseValue = 0;
                }
                else if (hat == scarf)
                {
                    scarfs.Dequeue();
                    increaseValue++;
                }
            }

            Console.WriteLine($"The most expensive set is: {biggestPrice}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
