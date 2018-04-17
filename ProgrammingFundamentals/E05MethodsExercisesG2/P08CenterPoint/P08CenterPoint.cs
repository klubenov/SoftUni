using System;

namespace P08CenterPoint
{
    class P08CenterPoint
    {
        private static (double, double) ClosestPointToCenter(double x1, double y1, double x2, double y2)
        {
            if (Math.Sqrt(x1 * x1 + y1 * y1) < Math.Sqrt(x2 * x2 + y2 * y2))
            {
                return (x1, y1);
            }
            return (x2, y2);
            

        }

        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            var coordinates = ClosestPointToCenter(x1, y1, x2, y2);
            Console.WriteLine($"({coordinates.Item1}, {coordinates.Item2})");
        }
    }
}
