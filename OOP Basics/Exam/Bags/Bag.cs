using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Bags
{
    public abstract class Bag
    {
        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; }

        public int Load => Items.Sum(i => i.Weight);

        private readonly List<Item> items;

        public IReadOnlyCollection<Item> Items
        {
            get { return this.items.AsReadOnly(); }
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight>this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count==0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            if (!this.items.Any(i => i.GetType().Name==name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            var item = items.Find(i => i.GetType().Name == name);
            this.items.Remove(item);
            return item;
        }
    }
}
