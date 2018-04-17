using System;
using System.Collections.Generic;
using System.Linq;

namespace P6TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            char[] snake = Console.ReadLine().ToCharArray();
            int[] shotParameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = matrixDimensions[0];
            int columns = matrixDimensions[1];
            int shotRow = shotParameters[0];
            int shotCol = shotParameters[1];
            int radius = shotParameters[2];

            var matrix = new char[rows, columns];

            var snakeQueue = new Queue<char>();
            int indexer = 0;

            while (snakeQueue.Count < rows*columns)
            {
                snakeQueue.Enqueue(snake[indexer]);
                indexer++;
                if (indexer>snake.Length-1)
                {
                    indexer = 0;
                }
            }
            indexer = 1;
            for (int i = rows-1; i >=0 ; i--)
            {
                if (indexer%2==1)
                {
                    for (int j = columns-1; j >= 0; j--)
                    {
                        matrix[i, j] = snakeQueue.Dequeue();
                    }
                }
                else
                {
                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i, j] = snakeQueue.Dequeue();
                    }
                }
                indexer++;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int a = shotRow - i;
                    int b = shotCol - j;

                    double distance = Math.Sqrt(a * a + b * b);

                    if (distance<=radius)
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }

            Stack<char> fallDownStack = new Stack<char>();
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[j, i] == ' ')
                    {
                        break;
                    }
                    fallDownStack.Push(matrix[j, i]);
                    matrix[j, i] = ' ';
                }
                if (fallDownStack.Count == 0)
                {
                    continue;
                }
                for (int j = rows - 1; j >= 0; j--)
                {
                    if (matrix[j, i] == ' ')
                    {
                        matrix[j, i] = fallDownStack.Pop();
                    }
                    if (fallDownStack.Count == 0)
                    {
                        break;
                    }
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
