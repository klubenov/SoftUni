using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03IntersectionOfCircles
{
    public class Point
    {
        public double xAxis { get; set; }
        public double yAxis { get; set; }
    }

    public class Circle
    {
        public Point Center { get; set; }
        public double Radius { get; set; }
    }

    class P03IntersectionOfCircles
    {
        static void Main(string[] args)
        {
            double[] firstCircleData = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double[] secondCircleData = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Circle firstCircle = new Circle();
            Circle secondCircle = new Circle();
            firstCircle.Center = new Point();
            firstCircle.Center.xAxis = firstCircleData[0];
            firstCircle.Center.yAxis = firstCircleData[1];
            firstCircle.Radius = firstCircleData[2];
            secondCircle.Center = new Point();
            secondCircle.Center.xAxis = secondCircleData[0];
            secondCircle.Center.yAxis = secondCircleData[1];
            secondCircle.Radius = secondCircleData[2];
            double xKatet = Math.Abs(firstCircle.Center.xAxis - secondCircle.Center.xAxis);
            double yKatet = Math.Abs(firstCircle.Center.yAxis - secondCircle.Center.yAxis);
            var distanceBetweenCenters = Math.Sqrt(Math.Pow(xKatet, 2) + Math.Pow(yKatet, 2));
            if (firstCircle.Radius+secondCircle.Radius >= distanceBetweenCenters)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
