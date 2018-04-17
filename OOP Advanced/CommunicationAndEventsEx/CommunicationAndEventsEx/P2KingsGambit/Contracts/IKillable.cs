using System;
using System.Collections.Generic;
using System.Text;

namespace P2King_sGambit.Contracts
{
    public interface IKillable : ICharacter
    {
        bool IsAlive { get; }

        void GetKillAttempted();

        void OnKingGetAttacked(object sender, EventArgs args);
    }
}
