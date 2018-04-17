using System;
using System.Linq;

namespace Problem3._02x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = input[0];
            var columns = input[1];
            char[,] matrix = new char[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                char[] chars = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = chars[j];
                }
            }
            int equalSquareCounter = 0;
            for (int i = 0; i < rows-1; i++)
            {
                for (int j = 0; j < columns-1; j++)
                {
                    if (matrix[i,j]==matrix[i,j+1] && matrix[i,j]==matrix[i+1,j] && matrix[i,j]==matrix[i+1,j+1])
                    {
                        equalSquareCounter++;
                    }
                }
            }
            Console.WriteLine(equalSquareCounter);
        }
    }
}
