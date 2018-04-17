using System;
using System.Collections.Generic;
using System.Text;
using P2King_sGambit.Contracts;

namespace P2King_sGambit.Characters
{
    public class Footman : Soldier
    {
        public Footman(string name) : base(name, 2)
        {

        }

        public override void OnKingGetAttacked(object sender, EventArgs args)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
