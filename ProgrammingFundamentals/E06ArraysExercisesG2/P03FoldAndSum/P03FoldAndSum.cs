using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03FoldAndSum
{
    class P03FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] originalSeq = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int qrtLength = originalSeq.Length / 4;
            int[] leftPart = new int[qrtLength];
            int[] rightPart = new int[qrtLength];
            int[] botLine = new int[originalSeq.Length/2];
            int[] sumLine = new int[originalSeq.Length/2];
            for (int i = 0; i < qrtLength; i++)
            {
                leftPart[i] = originalSeq[i];
                rightPart[i] = originalSeq[originalSeq.Length - qrtLength + i];
            }
            Array.Reverse(leftPart);
            Array.Reverse(rightPart);
            int[] topLine = leftPart.Concat(rightPart).ToArray();
            for (int i = 0; i < originalSeq.Length/2; i++)
            {
                botLine[i] = originalSeq[qrtLength + i];
            }
            for (int i = 0; i < originalSeq.Length/2; i++)
            {
                sumLine[i] = topLine[i] + botLine[i];
            }
            Console.WriteLine(string.Join(" ", sumLine));
        }
    }
}
