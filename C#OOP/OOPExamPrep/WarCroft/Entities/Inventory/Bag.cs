using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public int Capacity { get ; set; }

        public int Load => items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public void AddItem(Item item)
        {
            if ((Load + item.Weight) > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (Load == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            var itemType = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .Where(i => (typeof(Item).IsAssignableFrom(i)) && typeof(Item) != i)
                .FirstOrDefault(c => c.Name == name);

            if (itemType == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            var item = (Item)Activator.CreateInstance(itemType);
            return item;
        }
    }
}
