using System;
using System.Collections.Generic;
using System.Linq;

namespace _16.Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int wreaths = 0;
            int flowersLeft = 0;

            while (lilies.Count > 0 && roses.Count > 0 && wreaths < 5) 
            {
                int numberOfLilies = lilies.Pop();
                int numberOfRoses = roses.Dequeue();
                int sum = numberOfLilies + numberOfRoses;

                if (sum == 15)
                {
                    wreaths++;
                }
                else if (sum < 15)
                {
                    flowersLeft += sum;
                }
                else if (sum > 15)
                {
                    if (sum % 2 != 0)
                    {
                        wreaths++;
                    }
                    else
                    {
                        flowersLeft += 14;
                    }
                }
            }

            wreaths += flowersLeft / 15;

            string result = wreaths >= 5
                ? $"You made it, you are going to the competition with {wreaths} wreaths!"
                : $"You didn't make it, you need {5 - wreaths} wreaths more!";

            Console.WriteLine(result);
        }
    }
}
