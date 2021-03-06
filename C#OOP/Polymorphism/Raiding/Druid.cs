namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int heroPower = 80;

        public Druid(string name) 
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
