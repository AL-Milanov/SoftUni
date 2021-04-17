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
                string[] car = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = car[0];
                int enginePower = int.Parse(car[2]);
                string cargoType = car[4];
                List<double> tires = new List<double>() {
                    double.Parse(car[5]),
                    double.Parse(car[7]),
                    double.Parse(car[9]),
                    double.Parse(car[11])
                };
                cars.Add(new Car(model, enginePower, cargoType, tires));
            }

            string cargoTypeParameter = Console.ReadLine();

            foreach (var car in cars)
            {
                if (car.CargoType == cargoTypeParameter)
                {
                    switch (cargoTypeParameter)
                    {
                        case "flamable":
                            if (car.Engine > 250)
                            {
                                Console.WriteLine(car.Model);
                            }
                            break;

                        case "fragile":
                            bool isUnderPressure = false;
                            foreach (var tire in car.Tires)
                            {
                                if (tire < 1)
                                {
                                    isUnderPressure = true;
                                }
                            }
                            if (isUnderPressure)
                            {
                                Console.WriteLine(car.Model);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
