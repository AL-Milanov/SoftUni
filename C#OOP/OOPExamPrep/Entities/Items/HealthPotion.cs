﻿using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int healthPotionBaseWeight = 5;

        public HealthPotion() 
            : base(healthPotionBaseWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += 20;
        }
    }
}
