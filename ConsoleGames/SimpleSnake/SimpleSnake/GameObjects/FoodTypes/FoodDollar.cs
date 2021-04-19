namespace SimpleSnake.GameObjects.FoodTypes
{
    public class FoodDollar : Food
    {
        private const char foodSymbol = '$';
        private const int foodPoints = 5;

        public FoodDollar(Wall wall) 
            : base(wall, foodSymbol, foodPoints)
        {
        }
    }
}
