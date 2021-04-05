using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private const int baseCapacity = 100;

        private readonly List<Item> items;

        public Bag(int capacity = baseCapacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity { get; set; }

        public int Load => items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public void AddItem(Item item)
        {
            if ((Load + item.Weight) > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (Load == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item neededItem = items.FirstOrDefault(i => i.GetType().Name == name);
            
            if (neededItem == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            
            items.Remove(neededItem);
            return neededItem;
        }
    }
}
