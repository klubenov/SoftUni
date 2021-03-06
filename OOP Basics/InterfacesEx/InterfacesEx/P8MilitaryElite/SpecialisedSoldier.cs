﻿using System;
using System.Collections.Generic;
using System.Text;


public class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    private string corps;

    public string Corps
    {
        get { return corps; }
        private set
        {
            if (value != "Airforces" && value != "Marines")
            {
                throw new ArgumentException();
            }
            corps = value;
        }
    }

    public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName,
        lastName, salary)
    {
        Corps = corps;
    }
}

