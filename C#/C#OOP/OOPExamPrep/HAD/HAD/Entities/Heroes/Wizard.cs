namespace HAD.Entities.Heroes
{
    public class Wizard : BaseHero
    {
        private const long BaseIntelligenceHeroStrength = 25;
        private const long BaseIntelligenceHeroAgility = 25;
        private const long BaseIntelligenceHeroIntelligence = 100;
        private const long BaseIntelligenceHeroHitPoints = 100;
        private const long BaseIntelligenceHeroDamage = 250;


        public Wizard(string name)
            : base(
                  name,
                  BaseIntelligenceHeroStrength,
                  BaseIntelligenceHeroAgility,
                  BaseIntelligenceHeroIntelligence,
                  BaseIntelligenceHeroHitPoints,
                  BaseIntelligenceHeroDamage)
        {
        }
    }
}
