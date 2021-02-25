namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double milliliters = 50;

        private const decimal price = 3.50M;

        public Coffee(string name, double coffeine)
            : base(name, default, default)
        {
            Caffeine = coffeine;
        }

        //•	double CoffeeMilliliters = 50
        //•	decimal CoffeePrice = 3.50
        //•	Caffeine – double

        public override double Milliliters => milliliters;

        public override decimal Price => price;

        public double Caffeine { get; set; }

    }
}
