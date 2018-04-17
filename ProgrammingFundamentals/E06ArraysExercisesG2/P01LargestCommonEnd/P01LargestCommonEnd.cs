using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01LargestCommonEnd
{
    class P01LargestCommonEnd
    {
        static void Main(string[] args)
        {
            string[] firstSequence = Console.ReadLine().Split(' ').ToArray();
            string[] secondSequence = Console.ReadLine().Split(' ').ToArray();
            int cycleLength = Math.Min(firstSequence.Length, secondSequence.Length);
            int sameStartCount = 0;
            int sameEndCount = 0;
            int arrayDifference = Math.Abs(firstSequence.Length - secondSequence.Length);
            string[] longerSequence = new string[Math.Max(firstSequence.Length, secondSequence.Length)];
            string[] shorterSequence = new string[Math.Min(firstSequence.Length, secondSequence.Length)];
            if (firstSequence.Length >= secondSequence.Length)
            {
                Array.Copy(firstSequence, longerSequence, firstSequence.Length);
                Array.Copy(secondSequence, shorterSequence, secondSequence.Length);
            }
            else
            {
                Array.Copy(firstSequence, shorterSequence, firstSequence.Length);
                Array.Copy(secondSequence, longerSequence, secondSequence.Length);
            }
            for (int i = 0; i < cycleLength-1; i++)
            {
                if (firstSequence[i] == secondSequence[i])
                sameStartCount++;
            }
            for (int i = cycleLength-1; i >= 0; i--)
            {
                if (longerSequence[i + arrayDifference] == shorterSequence[i])
                sameEndCount++;
            }
            Console.WriteLine(Math.Max(sameEndCount,sameStartCount));
        }
    }
}
