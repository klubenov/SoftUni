using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P10PairsByDifference
{
    class P10PairsByDifference
    {
        static void Main(string[] args)
        {
            int[] numSeq = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int diffValue = int.Parse(Console.ReadLine());
            int pairCounter = 0;
            for (int i = 0; i < numSeq.Length; i++)
            {
                
                for (int j = 0; j < numSeq.Length; j++)
                {
                    if (j!=i && numSeq[i] - numSeq[j] == diffValue) pairCounter++;
                }
            }
            Console.WriteLine(pairCounter);
        }
    }
}
