using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03SearchForANumber
{
    class P03SearchForANumber
    {
        static void Main(string[] args)
        {
            List<int> numList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] commandArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = numList.Count; i > commandArr[0]; i--)
            {
                numList.RemoveAt(i-1);
            }
            for (int i = 0; i < commandArr[1]; i++)
            {
                numList.RemoveAt(0);
            }
                if (numList.Contains(commandArr[2]))
                {
                    Console.WriteLine("YES!");
                }
                else
                {
                    Console.WriteLine("NO!");
                }
        }
    }
}
