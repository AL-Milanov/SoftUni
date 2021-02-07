using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = travelledDistance;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public void CanMoveThatDistance(double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance) 
        {
            double fuelNeeded = fuelConsumptionPerKilometer * travelledDistance;
            if (fuelNeeded <= fuelAmount)
            {
                FuelAmount -= fuelNeeded;
                TravelledDistance += travelledDistance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
