using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int healthPotionBaseWeight = 5;
        private const double healValue = 20;

        public HealthPotion() 
            : base(healthPotionBaseWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.GetHeal(healValue);
        }
    }
}
