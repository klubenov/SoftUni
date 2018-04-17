using System;
using System.Linq;

namespace P1MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = input[0];
            int columns = input[1];
            string[,] matrix = new string[rows, columns];
            int rowcounter = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] =string.Join("", new char[]{ (char)(i + 97), (char)(j + 97 + rowcounter) , (char)(i + 97) });
                }
                rowcounter++;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
