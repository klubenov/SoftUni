using System;
using System.Collections.Generic;
using P2King_sGambit.Characters;
using P2King_sGambit.Contracts;

namespace P2King_sGambit
{
    class Program
    {
        static void Main(string[] args)
        {
            var king = new King(Console.ReadLine());

            var soldiersList = new List<IKillable>();

            var royalGuards = Console.ReadLine().Split(' ');
            foreach (var royalGuardName in royalGuards)
            {
                var royalGuard = new RoyalGuard(royalGuardName);
                soldiersList.Add(royalGuard);
                king.GetAttacked += royalGuard.OnKingGetAttacked;
            }

            var footmen = Console.ReadLine().Split(' ');
            foreach (var footmanName in footmen)
            {
                var footman = new Footman(footmanName);
                soldiersList.Add(footman);
                king.GetAttacked += footman.OnKingGetAttacked;
            }

            string input;

            while ((input=Console.ReadLine())!="End")
            {
                var inputData = input.Split(' ');
                if (inputData[0]=="Attack")
                {
                   king.OnGetAttacked(new EventArgs());
                }
                else
                {
                    var soldierToBeKilled = soldiersList.Find(s => s.Name == inputData[1]);
                    soldierToBeKilled.GetKillAttempted();
                    if (!soldierToBeKilled.IsAlive)
                    {
                        king.GetAttacked -= soldierToBeKilled.OnKingGetAttacked;
                    }
                }
            }
        }
    }
}
