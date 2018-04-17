using System;


class Program
{
    static void Main(string[] args)
    {
        var lenght = double.Parse(Console.ReadLine());
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());

        try
        {
            var box = new Box(lenght, width, height);
            Console.WriteLine($"Surface Area - {box.GetSurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {box.GetVolume():f2}");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
        finally
        {
            Environment.Exit(0);
        }
    }
}