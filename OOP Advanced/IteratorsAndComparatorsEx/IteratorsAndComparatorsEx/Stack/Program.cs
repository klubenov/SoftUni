using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var customStack = new CustomStack<string>();

            while (true)
            {
                var input = Console.ReadLine().Split(new []{' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                switch (input[0])
                {
                    case "Push":
                        customStack.Push(input.Skip(1).ToArray());
                        break;
                    case "Pop":
                        try
                        {
                            customStack.Pop();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "END":
                        for (int i = 0; i < 2; i++)
                        {
                            foreach (var item in customStack)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        return;
                }
            }
        }
    }
}
