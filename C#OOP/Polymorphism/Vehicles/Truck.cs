using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionIncrease = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption 
        { 
            get => base.FuelConsumption; 
            set => base.FuelConsumption = value + fuelConsumptionIncrease; 
        }

        public override void Refueling(double liters)
        {
            string res = CanRefillFuel(liters);
            if (res != null)
            {
                Console.WriteLine(res);
            }
            else
            {
                FuelQuantity += liters - (liters * 0.05);
            }
        }
    }
}
