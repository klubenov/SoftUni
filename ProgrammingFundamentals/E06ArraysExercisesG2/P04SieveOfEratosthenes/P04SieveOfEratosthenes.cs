using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04SieveOfEratosthenes
{
    class P04SieveOfEratosthenes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool[] sieve = new bool[n+1];
            for (int i = 0; i < sieve.Length; i++)
            {
                sieve[i] = true;
            }
            sieve[0] = false;
            sieve[1] = false;
            if (n == 2)
            {
                Console.WriteLine(2);
                return;
            }
            for (int i = 2; i <= Math.Sqrt(sieve.Length); i++)
            {
                if (sieve[i] == true)
                {
                    for (int j = 2; j*i < sieve.Length; j++)
                    {
                        if (i*j >sieve.Length-1)
                        {
                            break;
                        }
                        if (i*j==sieve.Length-1)
                        {
                            sieve[i * j] = false;
                            break;
                        }
                        sieve[j * i] = false;
                    }

                }
            }
            for (int i = 0; i < sieve.Length; i++)
            {
                if(sieve[i]==true)
                    Console.Write($"{i} ");
            }
        }
    }
}
