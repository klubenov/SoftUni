using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class TyreFactory
{
    public Tyre CreateTyre(List<string> tyreData)
    {
        switch (tyreData[0])
        {
            case "Hard":
                return new HardTyre(double.Parse(tyreData[1]));
            case "Ultrasoft":
                return new UltrasoftTyre(double.Parse(tyreData[1]), double.Parse(tyreData[2]));
        }

        throw new InvalidDataException("Invalid tyre data!");
    }
}

