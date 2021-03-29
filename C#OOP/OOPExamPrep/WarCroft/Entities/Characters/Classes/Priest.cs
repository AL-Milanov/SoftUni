using System;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters.Classes
{
    public class Priest : Character, IHealer
    {
        private const double priestBaseHP = 50;
        private const double priestBaseArmor = 25;
        private const double priestBaseAbilityPoints = 40;

        public Priest(string name) 
            : base(name, priestBaseHP, priestBaseArmor, priestBaseAbilityPoints, new Backpack())
        {
            PriestName = name;
        }

        public string PriestName { get; set; }

        public void Heal(Character character)
        {
            if (IsAlive == true && character.IsAlive == true)
            {
                character.GetHeal(AbilityPoints);
            }
        }
    }
}
