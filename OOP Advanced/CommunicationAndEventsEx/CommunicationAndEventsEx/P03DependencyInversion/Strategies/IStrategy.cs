using System;
using System.Collections.Generic;
using System.Text;

namespace P03_DependencyInversion.Strategies
{
    public interface IStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}
