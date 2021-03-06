﻿namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double fuelConsumptionIncrease = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption { get;  set;}

        protected override double AdditionalConsumption { get => fuelConsumptionIncrease; }
    }
}
