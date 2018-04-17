using System;

namespace P13GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            var magNum = int.Parse(Console.ReadLine());
            var combCount = 0;
            var nMag = 0;
            var mMag = 0;
            for (int i = n; i <=m; i++)
            {
                for (int j = n; j <=m; j++)
                {
                    combCount++;
                    if (i + j == magNum)
                    {
                        nMag = i;
                        mMag = j;
                    }
                }
            }
            if (nMag == 0) Console.WriteLine($"{combCount} combinations - neither equals {magNum}");
            else Console.WriteLine($"Number found! {nMag} + {mMag} = {magNum}");
        }
    }
}
