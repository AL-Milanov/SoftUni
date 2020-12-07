using System;
using System.Linq;

namespace ArcheryTrue
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                                   .Split("|", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
            string command = Console.ReadLine();
            int points = 0;

            while (command != "Game over")
            {
                string[] cmdArgs = command.Split("@", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                if (action == "Shoot Left")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int length = int.Parse(cmdArgs[2]);

                    if (index >= 0 && index < targets.Length)
                    {
                        int shootIndex = index;

                        if (shootIndex == targets.Length)
                        {
                            shootIndex = 0;
                        }
                        else 
                        {
                            shootIndex++;
                        }

                        for (int i = 0; i < length; i++)
                        {
                            shootIndex++;
                            if (shootIndex >= targets.Length)
                            {
                                shootIndex = 0;
                            }
                        }
                        if (targets[shootIndex] >= 5)
                        {
                            points += 5;
                            targets[shootIndex] -= 5;
                        }
                        else
                        {
                            points += targets[shootIndex];
                            targets[shootIndex] = 0;
                        }

                    }

                }
                else if (action == "Shoot Right")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int length = int.Parse(cmdArgs[2]);
                    if (index >= 0 && index < targets.Length)
                    {
                        if (index == 0)
                        {
                            index = targets.Length - 1;
                        }
                        else 
                        {
                            index--;
                        }

                        for (int i = length - 1; i > 0; i--)
                        {
                            index--;
                            if (index <= 0)
                            {
                                index = targets.Length;
                            }
                        }
                        if (targets[index] >= 5)
                        {
                            points += 5;
                            targets[index] -= 5;
                        }
                        else
                        {
                            points += targets[index];
                            targets[index] = 0;
                        }

                    }
                }
                else if (action == "Reverse")
                {
                    int[] reversed = targets.Reverse().ToArray();
                    targets = reversed;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" - ", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}
