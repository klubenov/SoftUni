using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string name)
        {
            switch (name)
            {
                case "HealthPotion":
                    return new HealthPotion();
                case "ArmorRepairKit":
                    return new ArmorRepairKit();
                case "PoisonPotion":
                    return new PoisonPotion();
                default:
                    throw new ArgumentException($"Invalid item \"{name}\"!");
            }
        }
    }
}
