using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }

        public int Count => cars.Count;

        public string AddCar(Car car)
        {
            string regNumberOfCar = car.RegistrationNumber;

            if (cars.Where(c => c.RegistrationNumber == regNumberOfCar).Any())
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }
        public string RemoveCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(cars => cars.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(car);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNumber in registrationNumbers)
            {
                foreach (var car in cars.ToList())
                {
                    if (car.RegistrationNumber == regNumber)
                    {
                        cars.Remove(car);
                    }
                }
            }
        }
    }
}
