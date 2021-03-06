namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionIncrease = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption{ get ;set; }
        protected override double AdditionalConsumption{ get => fuelConsumptionIncrease;}

        public override void Refueling(double liters)
        {
            base.Refueling(liters);
            FuelQuantity -= liters * 0.05;
        }

    }
}
