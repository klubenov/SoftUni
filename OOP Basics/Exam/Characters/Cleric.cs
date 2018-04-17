using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Bags;

namespace DungeonsAndCodeWizards.Characters
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name,Faction faction)
            :base(name,50,25,40,new Backpack(), faction) { }

        public void Heal(Character character)
        {
            this.EnsureAlive();
            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }
            character.GetHealed(this.AbilityPoints);
        }

        protected override double RestHealMultiplier
        {
            get { return base.RestHealMultiplier; }
            set { base.RestHealMultiplier = 0.5; }
        }
    }
}
