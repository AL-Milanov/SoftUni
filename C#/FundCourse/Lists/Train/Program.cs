using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                                      .Split()
                                      .Select(int.Parse)
                                      .ToList();

            int limit = int.Parse(Console.ReadLine());

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                ;
                if (command[0] == "Add")
                {

                    wagons.Add(int.Parse(command[1]));

                }
                else
                {
                    int passangers = int.Parse(command[0]);
                    for (
                        int i = 0; i < wagons.Count; i++)
                    {
                        int currWagon = wagons[i];
                        if (currWagon + passangers <= limit)
                        {
                            currWagon += passangers;
                            wagons[i] = currWagon;
                            break;
                        }
                    }
                }


                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(' ', wagons));

        }
    }
}
