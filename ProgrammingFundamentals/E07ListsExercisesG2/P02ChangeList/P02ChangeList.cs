using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02ChangeList
{
    class P02ChangeList
    {
        static void Main(string[] args)
        {
            List<int> numList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<string> commandList = Console.ReadLine().Split(' ').ToList();
            while (commandList[0] != "Odd" && commandList[0] != "Even")
            {
                if (commandList[0] == "Delete")
                {
                    int commandNum = int.Parse(commandList[1]);
                    numList.RemoveAll(num => num == commandNum);
                }
                else if (commandList[0] == "Insert")
                {
                    int commandNum = int.Parse(commandList[1]);
                    int commandPos = int.Parse(commandList[2]);
                    numList.Insert(commandPos,commandNum);
                }
                commandList.Clear();
                commandList = Console.ReadLine().Split(' ').ToList();
            }
            if (commandList[0] == "Odd")
            {
                foreach (int num in numList)
                {
                    if (num % 2 == 1)
                    {
                        Console.Write($"{num} ");
                    }
                }
            }
            else if (commandList[0] == "Even")
            {
                foreach (int num in numList)
                {
                    if (num % 2 == 0)
                    {
                        Console.Write($"{num} ");
                    }
                }
            }
        }
    }
}
