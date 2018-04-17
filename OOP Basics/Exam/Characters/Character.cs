using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Characters
{

    public abstract class Character
    {
        protected Character(string name, double health, double armor, double abilityPoints
            , Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.RestHealMultiplier = 0.2;
        }

        private string name;

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; }

        private double health;

        public double Health
        {
            get { return this.health; }
            set
            {
                if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else if (value < 0)
                {
                    this.health = 0;
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public double BaseArmor { get; }

        private double armor;

        public double Armor
        {
            get { return this.armor; }
            set
            {
                if (value > this.BaseArmor)
                {
                    this.armor = this.BaseArmor;
                }
                else if (value < 0)
                {
                    this.armor = 0;
                }
                else
                {
                    this.armor = value;
                }
            }
        }

        public double AbilityPoints { get; }

        public Bag Bag { get; }

        public Faction Faction { get; set; }

        public bool IsAlive => this.Health > 0;

        private string Status => IsAlive ? "Alive" : "Dead";

        protected virtual double RestHealMultiplier { get; set; }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (hitPoints > this.Armor)
            {
                hitPoints -= this.Armor;
                this.Armor = 0;
                this.Health -= hitPoints;
            }
            else
            {
                this.Armor -= hitPoints;
            }
        }

        public void GetHealed(double hitPoints)
        {
            EnsureAlive();

            this.Health += hitPoints;

        }

        public void GetPoisoned()
        {
            EnsureAlive();

            this.health -= 20;

        }

        public void Rest()
        {
            EnsureAlive();

            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            character.ReceiveItem(item);

        }

        public void ReceiveItem(Item item)
        {
            this.Bag.AddItem(item);
        }


        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public override string ToString()
        {
            return $"{Name} - HP: {Health}/{BaseHealth}, AP: {Armor}/{BaseArmor}, Status: {Status}";
        }
    }
}
