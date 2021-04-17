using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CalculateSequencewithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Queue<long> testQueue = new Queue<long>();
            Queue<long> outputQueue = new Queue<long>();

            testQueue.Enqueue(n);

            int counter = 1;
            for (int i = 1; i < 151; i++) //?
            {
                long number = testQueue.Peek();

                if (counter == 1)
                {
                    testQueue.Enqueue(number + 1);
                }
                else if (counter == 2)
                {
                    number *= 2;
                    number++;
                    testQueue.Enqueue(number);
                }
                else if (counter == 3)
                {
                    number += 2;
                    testQueue.Enqueue(number);
                    outputQueue.Enqueue(testQueue.Peek());
                    testQueue.Dequeue();
                }
                counter++;
                if (counter == 4)
                {
                    counter = 1;
                }
            }


            Console.WriteLine(string.Join(" ", outputQueue));
        }
    }
}
