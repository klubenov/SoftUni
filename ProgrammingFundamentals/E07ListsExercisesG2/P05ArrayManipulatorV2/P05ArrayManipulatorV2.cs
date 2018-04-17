using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05ArrayManipulatorV2
{
    class P05ArrayManipulatorV2
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input!="print")
            {
                string[] commands = input.Split(' ');
                switch (commands[0])
                {
                    case "add":
                        nums.Insert(int.Parse(commands[1]), int.Parse(commands[2]));
                        break;
                    case "addMany":                      
                        nums.InsertRange(int.Parse(commands[1]), commands.Skip(2).Select(int.Parse).ToList());
                        break;
                    case "contains":
                        Console.WriteLine(nums.IndexOf(int.Parse(commands[1])));
                        break;
                    case "remove":
                        nums.RemoveAt(int.Parse(commands[1]));
                        break;
                    case "shift":
                        //for (int i = 0; i < int.Parse(commands[1]); i++)
                        //{
                        //    int rotateNum = nums[0];
                        //    nums.RemoveAt(0);
                        //    nums.Add(rotateNum);
                        //}
                        int rotator = int.Parse(commands[1]);
                        rotator = rotator % nums.Count;
                        var rotationList = nums.Take(rotator).ToList();
                        nums.RemoveRange(0, rotator);
                        nums.AddRange(rotationList);
                        break;
                    case "sumPairs":
                        var sumList = new List<int>();
                        int pairSum = 0;
                        for (int i = 1; i <= nums.Count; i++)
                        {
                            pairSum += nums[i - 1];
                            if (i % 2 == 0)
                            {
                                sumList.Add(pairSum);
                                pairSum = 0;
                            }
                        }
                        if (nums.Count%2!=0)
                        {
                            sumList.Add(pairSum);
                        }
                        nums.Clear();
                        nums = sumList;
                        //for (int i = 0; i < nums.Count-1; i++)
                        //{
                        //    int sum = nums[i] + nums[i + 1];
                        //    nums[i] = sum;
                        //    nums.RemoveAt(i+1);
                        //}
                        break;
                }
                input = Console.ReadLine();
            }
            StringBuilder result = new StringBuilder();
            foreach (var num in nums)
            {
                result.Append(num).Append(", ");
            }
            result.Remove(result.Length - 2, 2);
            Console.WriteLine($"[{result}]");
        }
    }
}
