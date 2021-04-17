namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int SaltwaterCapacity = 25;

        public SaltwaterAquarium(string name) 
            : base(name, SaltwaterCapacity)
        {
        }
    }
}
