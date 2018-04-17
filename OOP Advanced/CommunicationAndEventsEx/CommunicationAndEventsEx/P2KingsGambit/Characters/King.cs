using System;
using System.Collections.Generic;
using System.Text;
using P2King_sGambit.Contracts;

namespace P2King_sGambit.Characters
{
    public class King : IAttackable
    {
        public string Name { get; }

        public event GetAttackedEventHandler GetAttacked;

        public King(string name)
        {
            this.Name = name;
        }

        public void OnGetAttacked(EventArgs args)
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is under attack!");
            this.GetAttacked?.Invoke(this,args);
        }
    }
}
