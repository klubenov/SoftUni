using System;

namespace P11ConvertSpeedUnits
{
    class P11ConvertSpeedUnits
    {
        static void Main(string[] args)
        {
            float distMeter = float.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());
            int totalSec = seconds + minutes * 60 + hours * 3600;
            float totalHours = hours + (float)minutes / 60 + (float)seconds / 3600;
            float mS = distMeter / totalSec;
            float kmH = (distMeter / 1000) / totalHours;
            float milH = (distMeter / 1609) / totalHours;
            Console.WriteLine($"{mS}\n{kmH}\n{milH}");
        }
    }
}