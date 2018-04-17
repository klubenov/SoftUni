using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace P02RotateAndSum
{
    class P02RotateAndSum
    {
        static void Main(string[] args)
        {
            int[] originalSequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());
            int[] summedSequence = new int[originalSequence.Length];
            for (int i = 1; i <= rotations; i++)
            {
                int lastDigitTemp = originalSequence[originalSequence.Length - 1];
                for (int j = 0; j <= originalSequence.Length-1; j++)
                {
                    if (j == originalSequence.Length - 1)
                    {
                        originalSequence[0] = lastDigitTemp;
                    }
                    else
                    {
                        originalSequence[originalSequence.Length - 1 - j] =
                            originalSequence[originalSequence.Length - 2 - j];
                    }
                }
                for (int s = 0; s <= originalSequence.Length-1; s++)
                {
                    summedSequence[s] += originalSequence[s];
                }
            }
            Console.WriteLine(string.Join(" ", summedSequence));
        }
    }
}
