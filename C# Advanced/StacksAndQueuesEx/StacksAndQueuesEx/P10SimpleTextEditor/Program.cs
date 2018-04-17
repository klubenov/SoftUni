using System;
using System.Collections.Generic;
using System.Text;

namespace P10SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            var rollBack = new Stack<string>();
            rollBack.Push("");

            var text = new StringBuilder();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commands = Console.ReadLine().Split(' ');
                int commandType = int.Parse(commands[0]);

                switch (commandType)
                {
                    case 1:
                        rollBack.Push(text.ToString());
                        string newString = commands[1];
                        text.Append(newString);
                        break;
                    case 2:
                        rollBack.Push(text.ToString());
                        int length = int.Parse(commands[1]);
                        text.Remove(text.Length - length, length);
                        break;
                    case 3:
                        int index = int.Parse(commands[1]);
                        Console.WriteLine(text[index-1]);
                        break;
                    case 4:
                        text.Clear();
                        text.Append(rollBack.Pop());
                        break;
                }
            }
        }
    }
}
