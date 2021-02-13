using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> task = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> thread = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int valueOfTask = int.Parse(Console.ReadLine());

            while (true)
            {
                int taskValue = task.Peek();
                int threadValue = thread.Peek();

                bool isTaskToBeKilled = valueOfTask == taskValue;

                if (threadValue >= taskValue)
                {
                    task.Pop();
                }
                if (isTaskToBeKilled)
                {

                    break;
                }

                thread.Dequeue();
            }

            Console.WriteLine($"Thread with value {thread.Peek()} killed task {valueOfTask}");
            Console.WriteLine(string.Join(" ", thread));
        }
    }
}
