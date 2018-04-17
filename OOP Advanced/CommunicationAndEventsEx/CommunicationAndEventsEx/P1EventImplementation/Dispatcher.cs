using System;
using System.Collections.Generic;
using System.Text;
using P1EventImplementation.Contracts;

namespace P1EventImplementation
{
    public class Dispatcher : INameChangeable
    {
        public event NameChangeEventHandler NameChange;

        private string name;

        public Dispatcher(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.OnNameChange(new NameChangeEventArgs(value));
                this.name = value;
            }
        }

        public void OnNameChange(NameChangeEventArgs args)
        {
            this.NameChange?.Invoke(this,args);
        }
    }
}
