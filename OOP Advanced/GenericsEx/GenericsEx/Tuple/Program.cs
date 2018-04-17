using System;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split(' ');
            var secondInput = Console.ReadLine().Split(' ');
            var thirdInput = Console.ReadLine().Split(' ');

            Console.WriteLine(new CustomTuple<string, string, string>(firstInput[0] + " " + firstInput[1], firstInput[2], firstInput[3]));

            bool drunkOrNot = secondInput[2] == "drunk";

            Console.WriteLine(new CustomTuple<string,int, bool>(secondInput[0],int.Parse(secondInput[1]), drunkOrNot));
            Console.WriteLine(new CustomTuple<string, double,string>(thirdInput[0], double.Parse(thirdInput[1]), thirdInput[2]));
        }
    }
}
