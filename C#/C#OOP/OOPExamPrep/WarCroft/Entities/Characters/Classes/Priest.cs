using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters.Classes
{
    public class Priest : Character, IHealer
    {
        private const double baseHealth = 50;
        private const double baseArmor = 25;
        private const double abilityPoints = 40;

        public Priest(string name) 
            : base(name, baseHealth, baseArmor, abilityPoints, new Backpack())
        {
            PriestName = name;
        }

        public string PriestName { get; private set; }

        public void Heal(Character character)
        {
            if (IsAlive == true && character.IsAlive == true)
            {
                character.GetHeal(AbilityPoints);
            }
        }
    }
}
