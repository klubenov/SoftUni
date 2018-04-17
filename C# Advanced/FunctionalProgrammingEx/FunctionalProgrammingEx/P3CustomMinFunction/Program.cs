using System;
using System.Linq;

namespace P3CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Func<int[], int> findSmallest = (array) =>
            {
                int minNum = Int32.MaxValue;
                foreach (var num in array)
                {
                    if (num < minNum)
                        minNum = num;
                }
                return minNum;
            };
            Console.WriteLine(findSmallest(numbers));
        }
    }
}
