using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05CompareCharArrays
{
    class P05CompareCharArrays
    {
        static void  PrintCloserToA(char[] closeset, char[] farthest)
        {
            Console.WriteLine(string.Join("", closeset));
            Console.WriteLine(string.Join("", farthest));
        }

        static void Main(string[] args)
        {
            char[] arr1 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] arr2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            for (int i = 0; i < Math.Min(arr1.Length,arr2.Length-1); i++)
            {
                if (arr1[i]==arr2[i])                
                    continue;
                if (arr1[i] < arr2[i])
                {
                    PrintCloserToA(arr1, arr2);
                    return;
                }
                    PrintCloserToA(arr2, arr1);
                    return;
            }
            if (arr1.Length > arr2.Length)
            {
                PrintCloserToA(arr2,arr1);
            }
            else
            {
                PrintCloserToA(arr1,arr2);
            }
        }
    }
}
