namespace Raiding
{
    public class Paladin : BaseHero
    {
        private const int heroPower = 100;

        public Paladin(string name) 
            : base(name)
        {
            
        }

        public override int Power => heroPower;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
