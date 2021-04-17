namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double fuelConsumptionIncrease = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double AdditionalConsumption
        {
            get => fuelConsumptionIncrease;
        }

        public override string Driving(double distance)
        {
            
            return base.Driving(distance);
        }

        public string DrivingEmpty(double distance)
        {
            if (FuelQuantity >= distance * FuelConsumption)
            {
                FuelQuantity -= distance * FuelConsumption;
                return $"{GetType().Name} travelled {distance} km";
            }

            return $"{GetType().Name} needs refueling";
        }
    }
}
