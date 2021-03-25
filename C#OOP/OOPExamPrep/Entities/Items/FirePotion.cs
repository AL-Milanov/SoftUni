using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        public const int firePotionBaseWeight = 5;

        public FirePotion() 
            : base(firePotionBaseWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= 20;
            // TODO : Check if character is alive
        }
    }
}
