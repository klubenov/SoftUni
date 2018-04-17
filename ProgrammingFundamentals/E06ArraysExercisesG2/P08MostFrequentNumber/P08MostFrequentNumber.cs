using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08MostFrequentNumber
{
    class P08MostFrequentNumber
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int bestCount = 0;
            int currentBest = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                int numcount = 0;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        numcount++;
                    }
                }
                if (numcount > bestCount)
                {
                    bestCount = numcount;
                    currentBest = arr[i];                    
                }
            }
            Console.WriteLine(currentBest);
        }
    }
}
