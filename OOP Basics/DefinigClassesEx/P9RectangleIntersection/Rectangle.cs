using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle
{
    //public string Id { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double TopLeftX { get; set; }

    public double TopLeftY { get; set; }

    public Rectangle(double width, double height, double topLeftX, double topLeftY)
    {
        Width = width;
        Height = height;
        TopLeftX = topLeftX;
        TopLeftY = topLeftY;
    }

    public bool IntersectsWith(Rectangle rectangle)
    {
        bool horizontalInteesection = false;
        bool verticalIntersection = false;
        bool result = false;

        if (TopLeftX>=rectangle.TopLeftX-Width && TopLeftX<=rectangle.TopLeftX+rectangle.Width)
        {
            horizontalInteesection = true;
        }
        if (TopLeftY>=rectangle.TopLeftY-rectangle.Height && TopLeftY-Height<=rectangle.TopLeftY)
        {
            verticalIntersection = true;
        }

        if (horizontalInteesection && verticalIntersection)
        {
            result = true;
        }
        return result;
    }
}
