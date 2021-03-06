namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int heroPower = 80;

        public Rogue(string name) 
            : base(name)
        {
            
        }

        public override int Power => heroPower;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
