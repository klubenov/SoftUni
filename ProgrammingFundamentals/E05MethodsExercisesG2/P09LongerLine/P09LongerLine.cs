using System;

namespace P09LongerLine
{
    class P09LongerLine
    {
        static (double, double) ClosestPointToCenter(double x1, double y1, double x2, double y2)
        {
            if (Math.Sqrt(x1 * x1 + y1 * y1) <= Math.Sqrt(x2 * x2 + y2 * y2))
            {
                return (x1, y1);
            }
            return (x2, y2);
        }

        static (double, double) FarthestPointFromCenter(double x1, double y1, double x2, double y2)
        {
            if (Math.Sqrt(x1 * x1 + y1 * y1) >= Math.Sqrt(x2 * x2 + y2 * y2))
            {
                return (x1, y1);
            }
            return (x2, y2);
        }

        static double LineLength(double x1, double y1, double x2, double y2)
        {
            double length = 0.0;
            if (x1 == x2)
                length = Math.Abs(y1 - y2);
            else if (y1 == y2)
                length = Math.Abs(x1 - x2);
            else
            {
                double side1 = Math.Abs(x1 - x2);
                double side2 = Math.Abs(y1 - y2);
                length = Math.Sqrt(side1 * side1 + side2 * side2);
            }
            return length;
        }

        static void Main(string[] args)
        {
            double line1x1 = double.Parse(Console.ReadLine());
            double line1y1 = double.Parse(Console.ReadLine());
            double line1x2 = double.Parse(Console.ReadLine());
            double line1y2 = double.Parse(Console.ReadLine());
            double line2x1 = double.Parse(Console.ReadLine());
            double line2y1 = double.Parse(Console.ReadLine());
            double line2x2 = double.Parse(Console.ReadLine());
            double line2y2 = double.Parse(Console.ReadLine());
            double line1Lenght = LineLength(line1x1, line1y1, line1x2, line1y2);
            double line2Lenght = LineLength(line2x1, line2y1, line2x2, line2y2);
            if (line1Lenght >= line2Lenght)
            {
                var closestCoordinates = ClosestPointToCenter(line1x1, line1y1, line1x2, line1y2);
                var farthestCoordinates = FarthestPointFromCenter(line1x1, line1y1, line1x2, line1y2);
                Console.WriteLine($"({closestCoordinates.Item1}, {closestCoordinates.Item2})({farthestCoordinates.Item1}, {farthestCoordinates.Item2})");
            }
            else
            {
                var closestCoordinates = ClosestPointToCenter(line2x1, line2y1, line2x2, line2y2);
                var farthestCoordinates = FarthestPointFromCenter(line2x1, line2y1, line2x2, line2y2);
                Console.WriteLine($"({closestCoordinates.Item1}, {closestCoordinates.Item2})({farthestCoordinates.Item1}, {farthestCoordinates.Item2})");
            }
        }
    }
}
