using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string command = Console.ReadLine();
            int carsPassedCount = 0;
            
            while (command != "END")
            {
                if (command == "green" && cars.Count != 0)
                {
                    string car = cars.Peek();
                    string currCar = car;
                    for (int i = 0; i < greenLight; i++)
                    {
                        car = car.Remove(0, 1);
                        if (car == "")
                        {
                            cars.Dequeue();
                            carsPassedCount++;
                            if (cars.Count != 0)
                            {
                                car = cars.Peek();
                                currCar = car;

                            }
                            else
                            {
                                break;
                            }

                        }
                    }
                    if (car != "")
                    {

                        for (int i = 0; i < freeWindow; i++)
                        {
                            car = car.Remove(0, 1);
                            if (car == "")
                            {
                                carsPassedCount++;
                                break;
                            }
                        }
                        if (car.Length > 0)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currCar} was hit at {car[0]}.");
                            return;

                        }

                    }
                }
                else
                {
                    cars.Enqueue(command);
                }


                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassedCount} total cars passed the crossroads.");

        }
    }
}
