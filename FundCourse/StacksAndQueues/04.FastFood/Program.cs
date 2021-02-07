using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(orders);
            int biggestOrder = 0;

            while (queue.Count > 0)
            {
                int currentOrder = queue.Peek();

                if (biggestOrder < currentOrder)
                {
                    biggestOrder = currentOrder;
                }

                if (quantity >= currentOrder)
                {
                    queue.Dequeue();
                    quantity -= currentOrder;
                }
                else
                {
                    Console.WriteLine(biggestOrder);
                    Console.WriteLine($"Orders left: " + string.Join(" ", queue));
                    return;
                }
            }
            Console.WriteLine(biggestOrder);
            Console.WriteLine($"Orders complete");
        }
    }
}
