using System;
using System.Collections.Generic;
using System.Text;


class Car
{
    public string Model { get; set; }

    public int Speed { get; set; }

    public Car()
    {
        
    }

    public override string ToString()
    {
        if (Model!=null)
        {
            return $"{Model} {Speed}\r\n";
        }
        else
        {
            return null;
        }
    }
}

