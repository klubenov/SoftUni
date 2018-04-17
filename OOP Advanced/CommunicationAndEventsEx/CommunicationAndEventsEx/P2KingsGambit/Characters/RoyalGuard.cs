using System;
using System.Collections.Generic;
using System.Text;
using P2King_sGambit.Contracts;

namespace P2King_sGambit.Characters
{
    public class RoyalGuard : Soldier
    {
        public RoyalGuard(string name) : base(name, 3)
        {

        }

        public override void OnKingGetAttacked(object sender, EventArgs args)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
