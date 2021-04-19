namespace SimpleSnake.GameObjects.FoodTypes
{
    public class FoodHash : Food
    {
        private const char foodSymbol = '#';
        private const int foodPoints = 10;

        public FoodHash(Wall wall) 
            : base(wall, foodSymbol, foodPoints)
        {
        }
    }
}
