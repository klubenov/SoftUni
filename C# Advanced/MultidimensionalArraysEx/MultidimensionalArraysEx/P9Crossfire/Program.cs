using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P9Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];

            var matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = i * columns + j + 1;
                }
            }

            var nukeCommand = Console.ReadLine();

            while (nukeCommand != "Nuke it from orbit")
            {
                var nukeArr = nukeCommand.Split(' ').Select(int.Parse).ToArray();
                nuke(matrix,nukeArr);
                reArrange(matrix);
                nukeCommand=Console.ReadLine();
            }
            printMatrix(matrix);
        }

        private static void printMatrix(int[,] matrix)
        {
            bool emptyLineChecker = true;
            var result = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        result.Append(matrix[i, j]).Append(" ");
                        emptyLineChecker = false;
                    }                    
                }
                if (!emptyLineChecker)
                {
                    result.AppendLine();
                }
                emptyLineChecker = true;
            }
            Console.WriteLine(result.ToString().Trim());
        }

        private static void reArrange(int[,] matrix)
        {
            Stack<int> fallDownStack = new Stack<int>();
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = columns-1; j >=0; j--)
                {
                    if (matrix[i,j] ==0)
                    {
                        break;
                    }
                    fallDownStack.Push(matrix[i,j]);
                    matrix[i,j] = 0;
                }
                if (fallDownStack.Count == 0)
                {
                    continue;
                }
                for (int j = 0; j <columns; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, j] = fallDownStack.Pop();
                    }
                    if (fallDownStack.Count == 0)
                    {
                        break;
                    }
                }
            }
        }

        private static void nuke(int[,] matrix, int[] nukeArr)
        {
            int nukeRow = nukeArr[0];
            int nukeCol = nukeArr[1];
            int radius = nukeArr[2];

            for (int i = nukeCol-radius; i <= nukeCol+radius; i++)
            {
                try
                {
                    matrix[nukeRow, i] = 0;
                }
                catch (IndexOutOfRangeException)
                {
                }   
            }
            for (int i = nukeRow-radius; i <= nukeRow+radius; i++)
            {
                try
                {
                    matrix[i,nukeCol] = 0;
                }
                catch (IndexOutOfRangeException)
                {
                }
            }
        }
    }
}
