using System;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P13Factorial
{
    class P13Factorial
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            BigInteger nFact = 1;
            for (int i = 1; i <= n; i++)
            {
                nFact = nFact * i;
            }
            Console.WriteLine(nFact);
        }
    }
}
