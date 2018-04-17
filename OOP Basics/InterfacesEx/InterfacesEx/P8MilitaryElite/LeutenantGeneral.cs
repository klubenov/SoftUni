using System;
using System.Collections.Generic;
using System.Text;


public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public List<Private> PrivatesList { get; private set; }

    public LeutenantGeneral(string id, string firstName, string lastName, decimal salary, List<Private> privatesList) :
        base(id, firstName, lastName, salary)
    {
        PrivatesList = privatesList;
    }

    public override string ToString()
    {
        var privatesSb = new StringBuilder();

        foreach (var privatePerson in PrivatesList)
        {
            privatesSb.Append("  ").Append(privatePerson).AppendLine();
        }

        return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}\r\nPrivates:\r\n{privatesSb}".TrimEnd();
    }
}

