﻿using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            BaseArmor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public string Name 
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                name = value;
            }
        }

        public double BaseHealth { get => baseHealth; private set { baseHealth = value; health = baseHealth; } }

        public double Health 
        {
            get => health;
            set 
            {
                health = value;

                if (health > baseHealth)
                {
                    value = baseHealth;
                }

                health = value;
            } 
        }

        public double BaseArmor { get => baseArmor; private set { baseArmor = value; armor = baseArmor; } }

        public double Armor { get => armor; }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        
        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            
            double currentArmor = armor;

            armor -= hitPoints;
            hitPoints -= currentArmor;

            if (armor < 0)
            {
                armor = 0;
            }

            if (hitPoints > 0)
            {
                health -= hitPoints;

                if (Health <= 0)
                {
                    health = 0;
                    IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}


        public override string ToString()
        {
            string status = IsAlive == true ? "Alive" : "Dead";
            return string.Format(SuccessMessages.CharacterStats, name, health, baseHealth, armor, BaseArmor, status);
        }
    }
}