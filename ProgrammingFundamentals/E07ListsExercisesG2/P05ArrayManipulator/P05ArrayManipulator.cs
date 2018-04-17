using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05ArrayManipulator
{
    class P05ArrayManipulator
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (true)
            {
                var commands = input.Split(' ').ToArray();
                if (commands[0] == "print") break;
                switch (commands[0])
                {
                    case "add":
                        nums.Insert(int.Parse(commands[1]), int.Parse(commands[2]));
                        break;
                    case "addMany":
                        //for (int i = 2; i < commands.Count; i++)
                        //{
                        //    nums.Insert(int.Parse(commands[1]) + i - 2, int.Parse(commands[i]));
                        //}                       
                        nums.InsertRange(int.Parse(commands[1]), commands.Skip(2).Select(int.Parse).ToList());
                        break;
                    case "contains":
                        //int breaker = 0;
                        //for (int i = 0; i < nums.Count; i++)
                        //{
                        //    if (nums[i] == int.Parse(commands[1]))
                        //    {
                        //        Console.WriteLine(i);
                        //        breaker++;
                        //        break;
                        //    }
                        //}
                        //if(breaker==0) Console.WriteLine(-1);
                            Console.WriteLine(nums.IndexOf(int.Parse(commands[1])));
                        break;
                    case "remove":
                        nums.RemoveAt(int.Parse(commands[1]));
                        break;
                    case "shift":
                        for (int i = 0; i < int.Parse(commands[1]); i++)
                        {
                            int rotateNum = nums[0];
                            nums.RemoveAt(0);
                            nums.Add(rotateNum);
                        }
                        break;
                    case "sumPairs":
                        var sumList = new List<int>();
                        int pairSum = 0;
                        for (int i = 1; i <= nums.Count; i++)
                        {
                            pairSum += nums[i-1];
                            if (i % 2 == 0)
                            {
                                sumList.Add(pairSum);
                                pairSum = 0;
                            }
                        }
                        if (pairSum != 0)
                        {
                            sumList.Add(pairSum);
                        }
                        nums.Clear();
                        nums = sumList;
                        break;                       
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }
    }
}
