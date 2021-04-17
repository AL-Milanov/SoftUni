using System;
using System.Linq;
using System.Collections.Generic;
using WarCroft.Entities.Characters.Contracts;
using System.Reflection;
using WarCroft.Entities.Items;
using WarCroft.Entities.Characters.Classes;
using System.Text;
using WarCroft.Constants;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characters;
        private Stack<Item> items;

        public WarController()
        {
            characters = new List<Character>();
            items = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            if (args.Length == 3)
            {
                characterType = args[1];
                name = args[2];
            }

            Character characterClass = null;

            if (characterType == "Warrior")
            {
                characterClass = new Warrior(name);
            }
            else if (characterType == "Priest")
            {
                characterClass = new Priest(name);
            }

            if (characterClass == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            characters.Add(characterClass);

            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = null;

            if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            items.Push(item);

            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            var character = characters.FirstOrDefault(n => n.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (items.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));
            }

            var item = items.Pop();

            character.Bag.AddItem(item);

            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var character = characters.FirstOrDefault(n => n.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            var sortedCharacters = characters
                .OrderByDescending(a => a.IsAlive == true)
                .ThenByDescending(h => h.Health)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var member in sortedCharacters)
            {
                string status = member.IsAlive == true ? "Alive" : "Dead";
                sb.AppendLine(string.Format(SuccessMessages.CharacterStats
                    , member.Name, member.Health, member.BaseHealth, member.Armor, member.BaseArmor, status));
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            var attacker = characters.FirstOrDefault(n => n.Name == attackerName);
            var receiver = characters.FirstOrDefault(n => n.Name == receiverName);

            if (attacker == null || receiver == null)
            {
                string notValidName = attacker == null ? attackerName : receiverName;

                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, notValidName);
            }

            if (attacker is Priest)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
            }

            StringBuilder sb = new StringBuilder();

            ((Warrior)attacker).Attack(receiver);

            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter,
                attackerName,
                receiverName,
                attacker.AbilityPoints,
                receiverName,
                receiver.Health,
                receiver.BaseHealth,
                receiver.Armor,
                receiver.BaseArmor));

            if (receiver.IsAlive == false)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name));
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            var healer = characters.FirstOrDefault(n => n.Name == healerName);
            var receiver = characters.FirstOrDefault(n => n.Name == healingReceiverName);

            if (healer == null || receiver == null)
            {
                string notValidName = healerName == null ? healerName : healingReceiverName;

                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, notValidName);
            }

            if (healer is Warrior)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
            }

            StringBuilder sb = new StringBuilder();

            ((Priest)healer).Heal(receiver);

            sb.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}!" +
                $" {receiver.Name} has {receiver.Health} health now!");

            return sb.ToString().TrimEnd();
        }
    }
}
