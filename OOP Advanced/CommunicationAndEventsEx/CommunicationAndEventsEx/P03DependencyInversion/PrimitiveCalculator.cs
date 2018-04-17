using System.Reflection;
using P03_DependencyInversion.Strategies;

namespace P03_DependencyInversion
{
    public class PrimitiveCalculator
    {
        private IStrategy strategy;
        private StragegyFactory stragegyFactory;

        public PrimitiveCalculator()
        {
            this.stragegyFactory = new StragegyFactory();
            this.strategy = new AdditionStrategy();
        }

        public void changeStrategy(char @operator)
        {
            this.strategy = this.stragegyFactory.CreateStrategy(@operator);
        }

        public int performCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
