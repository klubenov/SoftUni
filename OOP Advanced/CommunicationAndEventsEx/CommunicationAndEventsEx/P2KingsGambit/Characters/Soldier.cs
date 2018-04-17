using System;
using System.Collections.Generic;
using System.Text;
using P2King_sGambit.Contracts;

namespace P2King_sGambit.Characters
{
    public abstract class Soldier : IKillable
    {
        public bool IsAlive { get; private set; }   

        private int hitPoints;

        public string Name { get; }

        protected Soldier(string name, int hitPoints)
        {
            this.Name = name;
            this.IsAlive = true;
            this.hitPoints = hitPoints;
        }

        public void GetKillAttempted()
        {
            this.hitPoints--;
            if (this.hitPoints==0)
            {
                this.IsAlive = false;
            }
        }

        public abstract void OnKingGetAttacked(object sender, EventArgs args);
    }
}
