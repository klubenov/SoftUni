using System;

namespace P1ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            Action<string> printer = n => Console.WriteLine("Sir "+n);
            foreach (var name in names)
            {
                printer(name);
            }
        }
    }
}
