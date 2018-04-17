using System;
using System.Collections.Generic;
using System.Text;


class Box
{
    private double length;

    private double Lenght
    {
        get { return length; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative. ");
            }
            length = value;
        }
    }

    private double width;

    private double Width
    {
        get { return width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative. ");
            }
            width = value;
        }
    }

    private double height;

    private double Height
    {
        get { return height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative. ");
            }
            height = value;
        }
    }

    public Box(double lenght, double width, double height)
    {
        Lenght = lenght;
        Width = width;
        Height = height;
    }

    public double GetSurfaceArea()
    {
        return 2 * Lenght * Width + 2 * Lenght * Height + 2 * Width * Height;
    }

    public double GetLateralSurfaceArea()
    {
        return 2 * Lenght * Height + 2 * Width * Height;
    }

    public double GetVolume()
    {
        return Width * Lenght * Height;
    }
}
