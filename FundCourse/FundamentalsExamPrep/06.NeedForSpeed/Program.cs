using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.NeedForSpeed
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                string[] car = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

                string model = car[0];
                int mileage = int.Parse(car[1]);
                int fuel = int.Parse(car[2]);

                cars.Add(model, new List<int> { mileage, fuel });
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] cmdArgs = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string token = cmdArgs[0];
                string car = cmdArgs[1];

                if (token == "Drive")
                {
                    int distance = int.Parse(cmdArgs[2]);
                    int neededFuel = int.Parse(cmdArgs[3]);
                    int availableFuel = cars[car][1];

                    if (neededFuel > availableFuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[car][1] -= neededFuel;
                        cars[car][0] += distance;

                        Console.WriteLine($"{car} driven for {distance} kilometers. {neededFuel} liters of fuel consumed.");
                    }
                    if (cars[car][0] >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {car}!");
                        cars.Remove(car);

                    }

                }
                else if (token == "Refuel")
                {
                    int fuel = int.Parse(cmdArgs[2]);
                    int currentFuel = cars[car][1];
                    int refill = currentFuel + fuel;
                    if (refill > 75)
                    {
                        cars[car][1] = 75;
                        fuel = 75 - currentFuel;
                    }
                    else
                    {
                        cars[car][1] = refill;
                    }
                    Console.WriteLine($"{car} refueled with {fuel} liters");
                }
                else if (token == "Revert")
                {
                    int kilometers = int.Parse(cmdArgs[2]);
                    int mileage = cars[car][0] - kilometers;

                    if (mileage < 10000)
                    {
                        cars[car][0] = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                        cars[car][0] = mileage;

                    }

                }

                command = Console.ReadLine();
            }

            foreach (var car in cars.OrderByDescending(m => m.Value[0]).ThenBy(n => n.Key))
            {

                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");

            }

        }
    }
}
