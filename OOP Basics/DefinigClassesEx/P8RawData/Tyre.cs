﻿using System;
using System.Collections.Generic;
using System.Text;


class Tyre
{
    public double Pressure { get; set; }

    public int Age { get; set; }

    public Tyre(double pressure, int age)
    {
        Pressure = pressure;
        Age = age;
    }
}

