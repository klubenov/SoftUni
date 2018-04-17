using System;

namespace P11GeometryCalculator
{
    class P11GeometryCalculator
    {
        static double TriangleArea(double side, double height)
        {
            double triangleArea = side * height / 2;
            return triangleArea;
        }

        static double SquareArea(double side)
        {
            double squareArea = Math.Pow(side, 2);
            return squareArea;
        }

        static double RectangleArea(double width, double height)
        {
            double rectangleArea = width * height;
            return rectangleArea;
        }

        static double CircleArea(double radius)
        {
            double circleArea = radius * radius * Math.PI;
            return circleArea;
        }

        static void Main(string[] args)
        {
            string figureType = Console.ReadLine();
            switch (figureType)
            {
                case "triangle":
                    double triangleSide = double.Parse(Console.ReadLine());
                    double triangleHeight = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{TriangleArea(triangleSide, triangleHeight):f2}");
                    return;
                case "square":
                    double squareSide = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{SquareArea(squareSide):f2}");
                    return;
                case "rectangle":
                    double rectangleSide = double.Parse(Console.ReadLine());
                    double rectangleHeight = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{RectangleArea(rectangleSide, rectangleHeight):f2}");
                    return;
                case "circle":
                    double radius = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{CircleArea(radius):f2}");
                    return;
            }
        }
    }
}
