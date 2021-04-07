namespace HAD.Entities.Heroes
{
    public class Assassin : BaseHero
    {
        private const long BaseAgilityHeroStrength = 25;
        private const long BaseAgilityHeroAgility = 100;
        private const long BaseAgilityHeroIntelligence = 15;
        private const long BaseAgilityHeroHitPoints = 150;
        private const long BaseAgilityHeroDamage = 300;


        public Assassin(string name) 
            : base(
                  name,
                  BaseAgilityHeroStrength,
                  BaseAgilityHeroAgility,
                  BaseAgilityHeroIntelligence,
                  BaseAgilityHeroHitPoints,
                  BaseAgilityHeroDamage)
        {
        }
    }
}
