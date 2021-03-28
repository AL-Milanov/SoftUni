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

            var characterClass = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .Where(c => (typeof(Character).IsAssignableFrom(c)) && typeof(Character) != c)
                .FirstOrDefault(c => c.Name.Contains(characterType));

            if (characterClass == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            var character = (Character)Activator.CreateInstance(characterClass, new string[] { name });

            characters.Add(character);

            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            var item = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .Where(i => (typeof(Item).IsAssignableFrom(i)) && typeof(Item) != i)
                .FirstOrDefault(c => c.Name == itemName);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            var potion = (Item)Activator.CreateInstance(item);
            items.Push(potion);

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
            string itemName = item.GetType().Name;
            character.EnsureAlive();
            character.Bag.AddItem(item);

            return string.Format(SuccessMessages.PickUpItem, characterName, itemName);
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

            var item = character.Bag.GetItem(itemName);
            character.EnsureAlive();
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

            foreach (var item in sortedCharacters)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            var attacker = characters.FirstOrDefault(n => n.Name == attackerName);
            var receiver = characters.FirstOrDefault(n => n.Name == receiverName);
            string notValidName = attacker == null ? attackerName : receiverName;

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, notValidName));
            }
            attacker.EnsureAlive();
            if (attacker is Priest)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
            }

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, notValidName));
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
            string notValidName = healerName == null ? healerName : healingReceiverName;

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, notValidName));
            }
            healer.EnsureAlive();
            if (healer is Warrior)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
            }

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, notValidName));
            }

            StringBuilder sb = new StringBuilder();

            ((Priest)healer).Heal(receiver);

            sb.AppendLine(string.Format(SuccessMessages.HealCharacter,
                healer.Name,
                receiver.Name,
                healer.AbilityPoints,
                receiver.Name,
                receiver.Health));

            return sb.ToString().TrimEnd();
        }
    }
}
