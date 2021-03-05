namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double fuelConsumptionIncrease = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override string Driving(double distance)
        {
            FuelConsumption += fuelConsumptionIncrease;
            return base.Driving(distance);
        }

        public string DrivingEmpty(double distance)
        {
            return base.Driving(distance);
        }
    }
}
