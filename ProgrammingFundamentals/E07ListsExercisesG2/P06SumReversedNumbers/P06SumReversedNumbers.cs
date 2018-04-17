using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06SumReversedNumbers
{
    class P06SumReversedNumbers
    {
        static int ReverseNum(int num)
        {
            int revertedNum = 0;
            while (num > 0)
            {
                int r = num % 10;
                revertedNum = revertedNum * 10 + r;
                num = num / 10; 
            }
            return revertedNum;
        }

        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = ReverseNum(numbers[i]);
            }
            foreach (int num in numbers)
            {
                sum += num;
            }
            Console.WriteLine(sum);
        }
    }
}
