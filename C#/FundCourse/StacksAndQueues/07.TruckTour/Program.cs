using System;
using System.Collections.Generic;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());
            Queue<string> pumps = new Queue<string>();

            for (int i = 0; i < petrolPumps; i++)
            {
                pumps.Enqueue(Console.ReadLine());
            }


            for (int i = 0; i < petrolPumps; i++)
            {
                bool isDone = true;
                int tank = 0;

                for (int j = 0; j < petrolPumps; j++)
                {
                    string[] pump = pumps.Peek().Split();
                    pumps.Enqueue(string.Join(" ", pump));
                    pumps.Dequeue();

                    int amountOfPetrol = int.Parse(pump[0]);
                    int distance = int.Parse(pump[1]);

                    tank += amountOfPetrol;

                    if (distance > tank)
                    {
                        isDone = false;
                        
                    }
                    else
                    {
                        tank -= distance;
                    }

                }
                if (isDone)
                {
                    Console.WriteLine(i);
                    break;
                }
                pumps.Enqueue(pumps.Peek());
                pumps.Dequeue();
            }
        }
    }
}
