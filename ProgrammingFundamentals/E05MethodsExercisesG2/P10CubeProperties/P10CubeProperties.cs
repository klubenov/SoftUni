using System;

namespace P10CubeProperties
{
    class P10CubeProperties
    {
        static double FaceDiagonal(double side)
        {
            double faceDiagonal = Math.Sqrt(2 * Math.Pow(side, 2));
            return faceDiagonal;
        }

        static double SpaceDiagonal(double side)
        {
            double spaceDiagonal = Math.Sqrt(3 * Math.Pow(side, 2));
            return spaceDiagonal;
        }

        static double Volume(double side)
        {
            double volume = Math.Pow(side, 3);
            return volume;
        }

        static double SurfaceArea(double side)
        {
            double surfaceArea = 6 * Math.Pow(side, 2);
            return surfaceArea;
        }

        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string targetCalcualtion = Console.ReadLine();
            switch (targetCalcualtion)
            {
                case "face":
                    Console.WriteLine($"{FaceDiagonal(side):f2}");
                    return;
                case "space":
                    Console.WriteLine($"{SpaceDiagonal(side):f2}");
                    return;
                case "volume":
                    Console.WriteLine($"{Volume(side):f2}");
                    return;
                case "area":
                    Console.WriteLine($"{SurfaceArea(side):f2}");
                    return;
            }
        }
    }
}
