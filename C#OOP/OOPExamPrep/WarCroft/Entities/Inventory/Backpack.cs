namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int backpackBaseCap = 100;

        public Backpack() 
            : base(backpackBaseCap)
        {
        }
    }
}
