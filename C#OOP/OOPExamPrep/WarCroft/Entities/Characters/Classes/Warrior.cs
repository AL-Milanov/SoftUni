using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters.Classes
{
    public class Warrior : Character, IAttacker
    {
        private const double warriorBaseHP = 100;
        private const double warriorBaseArmor = 50;
        private const double warriorBaseAbilityPoints = 40;


        public Warrior(string name)
            : base(name, warriorBaseHP, warriorBaseArmor, warriorBaseAbilityPoints, new Satchel())
        {
            WarriorName = name;
        }

        public string WarriorName { get; private set; }


        public void Attack(Character character)
        {
            if (character == this)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            EnsureAlive();
            
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            character.TakeDamage(AbilityPoints);
        }

    }
}
