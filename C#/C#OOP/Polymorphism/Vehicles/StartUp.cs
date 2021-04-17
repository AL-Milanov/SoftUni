using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] busData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = new Car(double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));
            Vehicle truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(truckData[3]));
            Vehicle bus = new Bus(double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = input[1];
                double distanceOrFuel = double.Parse(input[2]);
                if (input[0] == "Drive")
                {
                    string drive = null;

                    if (type == "Car")
                    {
                        drive = car.Driving(distanceOrFuel);
                    }
                    else if (type == "Truck")
                    {
                        drive = truck.Driving(distanceOrFuel);
                    }
                    else
                    {
                        drive = bus.Driving(distanceOrFuel);
                    }

                    Console.WriteLine(drive);
                }
                else if (input[0] == "Refuel")
                {
                    try
                    {
                        if (type == "Car")
                        {
                            car.Refueling(distanceOrFuel);
                        }
                        else if (type == "Truck")
                        {
                            truck.Refueling(distanceOrFuel);
                        }
                        else
                        {
                            bus.Refueling(distanceOrFuel);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (input[0] == "DriveEmpty")
                {
                    Console.WriteLine(((Bus)bus).DrivingEmpty(distanceOrFuel));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
