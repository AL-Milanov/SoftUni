namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int heroPower = 100;

        public Warrior(string name) 
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
