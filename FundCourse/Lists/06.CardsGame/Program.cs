using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine()
                                           .Split()
                                           .Select(int.Parse)
                                           .ToList();

            List<int> secoundPlayer = Console.ReadLine()
                                             .Split()
                                             .Select(int.Parse)
                                             .ToList();


            while (true)
            {
                if (firstPlayer.Count <= 0 || secoundPlayer.Count <= 0)
                {
                    break;
                }
                else
                {
                    if (firstPlayer[0] > secoundPlayer[0])
                    {
                        firstPlayer.Add(firstPlayer[0]);
                        firstPlayer.Add(secoundPlayer[0]);
                    }
                    else if (secoundPlayer[0] > firstPlayer[0])
                    {

                        secoundPlayer.Add(secoundPlayer[0]);
                        secoundPlayer.Add(firstPlayer[0]);
                    }
                    firstPlayer.RemoveAt(0);
                    secoundPlayer.RemoveAt(0);

                }
            }
            if (firstPlayer.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
            }
            else if (secoundPlayer.Count > 0)
            {
                Console.WriteLine($"Second player wins! Sum: {secoundPlayer.Sum()}");
            }

        }

    }
}
