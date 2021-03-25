using System;

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
            AbilityPoins = abilityPoints;
            Bag = bag;
        }

        public string Name 
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                name = value;
            }
        }

        public double BaseHealth { get => baseHealth; private set { baseHealth = value; } }

        public double Health 
        {
            get => health;
            set 
            {
                if (value + health > baseHealth)
                {
                    value = baseHealth;
                }
                else
                {
                    value += health;
                }
                health = value;
            } 
        }

        public double BaseArmor { get => armor = baseArmor; private set { baseArmor = value; } }

        public double Armor { get => armor; private set { armor = value; } }

        public double AbilityPoins { get; private set; }

        public Bag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        
        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            
            double currentArmor = Armor;

            Armor -= hitPoints;
            hitPoints -= currentArmor;

            if (Armor < 0)
            {
                Armor = 0;
            }

            if (hitPoints > 0)
            {
                Health -= hitPoints;

                if (Health <= 0)
                {
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
	}
}