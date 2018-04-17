using System;
using System.Collections.Generic;
using System.Text;

namespace P2King_sGambit.Contracts
{
    public delegate void GetAttackedEventHandler(object sender, EventArgs args);

    public interface IAttackable : ICharacter
    {
        event GetAttackedEventHandler GetAttacked;

        void OnGetAttacked(EventArgs args);
    }
}
