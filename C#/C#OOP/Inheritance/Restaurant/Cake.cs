namespace Restaurant
{
    class Cake : Dessert
    {
        private const double grams = 250;

        private const double calories = 1000;

        private const decimal cakePrice = 5M;

        public Cake(string name)
            : base(name , default, default, default)
        {

        }

        public override double Grams => grams;

        public override double Calories => calories;

        public override decimal Price => cakePrice;

    }
}
