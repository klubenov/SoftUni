using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07BombNumbers
{
    class P07BombNumbers
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string[] bombs = Console.ReadLine().Split(' ');
            int bomb = int.Parse(bombs[0]);
            int power = int.Parse(bombs[1]);
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == bomb)
                {
                    for (int j = i- power; j <=power+i; j++)
                    {
                        if (j>=0 && j<=nums.Count-1)
                        {
                            nums[j] = 0;
                        }
                    }
                }
            }
            Console.WriteLine(nums.Sum());
        }
    }
}
