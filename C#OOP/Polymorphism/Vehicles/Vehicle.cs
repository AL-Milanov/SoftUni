using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle : ICheck
    {
        
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            
            if (fuelQuantity <= tankCapacity)
            {
                FuelQuantity = fuelQuantity;
            }
            else
            {
                FuelQuantity = 0.0;
            }
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; set; }

        public virtual double FuelConsumption{get;set;}

        public double TankCapacity { get; set; }

        protected virtual double AdditionalConsumption { get; set; }

        public bool CanDrive(double distance)
        {
            return FuelQuantity >= distance * (FuelConsumption + AdditionalConsumption);
        }

        public virtual string Driving(double distance)
        {
            if (CanDrive(distance))
            {
                FuelQuantity -= distance * (FuelConsumption + AdditionalConsumption);
                return $"{GetType().Name} travelled {distance} km";
            }

            return $"{GetType().Name} needs refueling";
        }

        public virtual void Refueling(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (liters + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            FuelQuantity += liters;
           
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
