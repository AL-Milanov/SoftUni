using System;
using System.Linq;

namespace _07.HeartMo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine().Split("@").Select(int.Parse).ToArray();
            int index = 0;
            string command = Console.ReadLine();

            while (command != "Love!")
            {
                string[] cmdArgs = command.Split();

                int length = int.Parse(cmdArgs[1]);

                index += length;
                if (index >= 0 && index < neighborhood.Length)
                {
                    neighborhood[index] -= 2;
                }
                else
                {
                    index = 0;
                    neighborhood[index] -= 2;
                }
                if (neighborhood[index] == 0)
                {
                    Console.WriteLine($"Place {index} has Valentine's day.");
                }
                else if (neighborhood[index] < 0)
                {
                    Console.WriteLine($"Place {index} already had Valentine's day.");
                }

                command = Console.ReadLine();
            }
            int fails = 0;
            Console.WriteLine($"Cupid's last position was {index}.");
            foreach (int item in neighborhood)
            {
                if (item <= 0)
                {
                    fails--;
                }
                fails++;
            }
            if (fails != 0)
            {
                Console.WriteLine($"Cupid has failed {fails} places.");
            }
            else
            {
                Console.WriteLine("Mission was successful.");
            }

        }
    }
}
