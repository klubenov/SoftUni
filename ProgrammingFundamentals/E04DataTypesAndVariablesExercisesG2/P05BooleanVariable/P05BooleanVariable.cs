using System;

namespace P05BooleanVariable
{
    class P05BooleanVariable
    {
        static void Main(string[] args)
        {
            string boolValue = Console.ReadLine();
            bool finalBool = Convert.ToBoolean(boolValue);
            if (finalBool) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}
