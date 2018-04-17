using System;
using System.Collections.Generic;
using System.Text;


public class Mission
{
    public string CodeName { get; private set; }

    private string state;

    public string State
    {
        get { return state; }
        private set
        {
            if (value != "inProgress" && value != "Finished")
            {
                throw new ArgumentException();
            }

            state = value;
        }
    }

    public Mission(string codeName, string state)
    {
        State = state;
        CodeName = codeName;
    }

    public override string ToString()
    {
        return $"Code Name: {CodeName} State: {State}";
    }
}

