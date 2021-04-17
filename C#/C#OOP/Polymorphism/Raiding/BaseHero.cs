namespace Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public virtual int Power { get; }

        public virtual string CastAbility() { return null; }
    }
}
