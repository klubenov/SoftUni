using System;
using System.Collections.Generic;
using System.Text;

namespace P1EventImplementation.Contracts
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public interface INameChangeable : INameable
    {
        event NameChangeEventHandler NameChange;

        void OnNameChange(NameChangeEventArgs args);
    }
}
