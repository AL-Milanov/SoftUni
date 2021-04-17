namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int FreshwaterCapacity = 50;

        public FreshwaterAquarium(string name) 
            : base(name, FreshwaterCapacity)
        {
        }
    }
}
