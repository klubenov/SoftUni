using System;
using System.Collections.Generic;
using System.Text;

namespace P1EventImplementation.Contracts
{
    public interface INameChangeHandler
    {
        void OnDispatcherNameChange(object sender, NameChangeEventArgs args);
    }
}
