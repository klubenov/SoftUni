using System;

namespace P12RectangleProperties
{
    class P12RectangleProperties
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double rectPerimeter = 2 * width + 2 * height;
            double rectArea = width * height;
            double rectDiagonal = Math.Sqrt(height * height + width * width);
            Console.WriteLine($"{rectPerimeter}\n{rectArea}\n{rectDiagonal}");
        }
    }
}
