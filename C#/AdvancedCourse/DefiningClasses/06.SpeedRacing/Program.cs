using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionForOneKm = double.Parse(input[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumptionForOneKm, 0));
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = cmdArgs[1];
                double amountOfKm = double.Parse(cmdArgs[2]);

                foreach (var car in cars)
                {
                    if (car.Model == model)
                    {
                        car.CanMoveThatDistance(car.FuelAmount, car.FuelConsumptionPerKilometer, amountOfKm);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
