using System;
using System.Linq;

namespace P11EqualSums
{
    class P11EqualSums
    {
        static void Main(string[] args)
        {
            int[] numArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            if (numArr.Length <= 1)
            {
                Console.WriteLine("0");
                return;
            }
            for (int i = 0; i < numArr.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                for (int j = 0; j < i; j++)
                {
                    leftSum += numArr[j];
                }
                for (int j = i+1; j < numArr.Length; j++)
                {
                    rightSum += numArr[j];
                }
                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    return;
                }

            }
            Console.WriteLine("no");
        }
    }
}
