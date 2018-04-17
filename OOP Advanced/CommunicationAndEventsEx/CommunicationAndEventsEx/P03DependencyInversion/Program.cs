using System;

namespace P03_DependencyInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new PrimitiveCalculator();

            string input;

            while ((input=Console.ReadLine())!="End")
            {
                var inputData = input.Split(' ');

                if (inputData[0]=="mode")
                {
                    calculator.changeStrategy(inputData[1][0]);
                }
                else
                {
                    Console.WriteLine(calculator.performCalculation(int.Parse(inputData[0]), int.Parse(inputData[1])));
                }
            }
        }
    }
}
