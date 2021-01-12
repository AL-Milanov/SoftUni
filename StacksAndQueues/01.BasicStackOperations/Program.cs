using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] operations = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = operations[0]; //push in stack
            int s = operations[1]; // pop from stack
            int x = operations[2]; // number to search in stack

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);

                }
                else
                {
                    int smallestNumber = int.MaxValue;
                    for (int i = 0; i < stack.Count; i++)
                    {
                        int currentNum = stack.Peek();

                        if (currentNum < smallestNumber)
                        {
                            smallestNumber = currentNum;
                        }
                    }
                    Console.WriteLine(smallestNumber);

                }
            }
        }
    }
}
