using System;

namespace P09CountTheIntegers
{
    class P09CountTheIntegers
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 100; i++)
            {
                try
                {
                    int num = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
