using System;
using System.Collections.Generic;
using System.Text;

namespace P03_DependencyInversion.Strategies
{
    public class StragegyFactory
    {
        public IStrategy CreateStrategy(char @operator)
        {
            switch (@operator)
            {
                case '+':
                    return new AdditionStrategy();
                case '-':
                    return new SubtractionStrategy();
                case '*':
                    return new MultiplicationStrategy();
                case '/':
                    return new DivisionStrategy();
            }

            throw new ArgumentException("Unknown stragegy!");
        }
    }
}
