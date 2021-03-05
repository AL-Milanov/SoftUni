using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle : ICheck
    {
        private double fuelQuantity;
        private double tankCapacity;


        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            set
            {
                if (value > tankCapacity)// or > ??
                {
                    value = 0;
                }
                this.fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption
        {
            get;
            set;
        }

        public double TankCapacity
        {
            get => this.tankCapacity;
            private set
            {
                this.tankCapacity = value;
            }

        }

        public bool CanDrive(double distance)
        {
            return FuelQuantity >= distance * FuelConsumption;
        }

        public string CanRefillFuel(double liters)
        {
            string res = null;

            double availableSpace = liters + FuelQuantity;

            if (availableSpace > TankCapacity) //??
            {
                res = $"Cannot fit {liters} fuel in the tank";
                return res;
            }
            if (liters <= 0)
            {
                res = "Fuel must be a positive number";
                return res;
            }
            return res;
        }

        public virtual string Driving(double distance)
        {
            if (CanDrive(distance))
            {
                FuelQuantity -= distance * FuelConsumption;
                return $"{GetType().Name} travelled {distance} km";
            }

            return $"{GetType().Name} needs refueling";
        }

        public virtual void Refueling(double liters)
        {
            string res = CanRefillFuel(liters);
            if (res != null)
            {
                Console.WriteLine(res);
            }
            else
            {
                FuelQuantity += liters;
            }
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
