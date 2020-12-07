using System;
using System.Linq;

namespace _05.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = Console.ReadLine();
            int counter = 0;

            while (command != "End")
            {
                int index = int.Parse(command);

                if (index >= 0 && index < targets.Length)
                {
                    if (targets[index] != -1)
                    {
                        counter++;
                        int value = targets[index];
                        targets[index] = -1;

                        for (int i = 0; i < targets.Length; i++)
                        {
                            if (targets[i] != -1)
                            {
                                if (value >= targets[i])
                                {
                                    targets[i] += value;
                                }
                                else if (value < targets[i])
                                {
                                    targets[i] -= value;
                                }
                            }
                        }
                    }

                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {counter} -> " + string.Join(" ", targets));

        }
    }
}
