using System;
using System.Collections.Generic;
using System.Linq;

namespace P5RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];

            int commandsCount = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows,columns];

            int fillCounter = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = fillCounter;
                    fillCounter++;
                }
            }
            fillCounter = 1;
            var tempQueue = new Queue<int>();
            for (int i = 0; i < commandsCount; i++)
            {
                var command = Console.ReadLine().Split();
                int rotateTarget = int.Parse(command[0]);
                string action = command[1];
                int rotateCount = int.Parse(command[2]);

                switch (action)
                {
                    case "up":
                        for (int j = 0; j < rows; j++)
                        {
                            tempQueue.Enqueue(matrix[j,rotateTarget]);
                        }
                        for (int j = 0; j < rotateCount%rows; j++)
                        {
                            tempQueue.Enqueue(tempQueue.Dequeue());
                        }
                        for (int j = 0; j < rows; j++)
                        {
                            matrix[j, rotateTarget] = tempQueue.Dequeue();
                        }
                        break;
                    case "down":
                        for (int j = rows-1; j >=0; j--)
                        {
                            tempQueue.Enqueue(matrix[j, rotateTarget]);
                        }
                        for (int j = 0; j < rotateCount % rows; j++)
                        {
                            tempQueue.Enqueue(tempQueue.Dequeue());
                        }
                        for (int j = rows - 1; j >= 0; j--)
                        {
                            matrix[j, rotateTarget] = tempQueue.Dequeue();
                        }
                        break;
                    case "left":
                        for (int j = 0; j < columns; j++)
                        {
                            tempQueue.Enqueue(matrix[rotateTarget, j]);
                        }
                        for (int j = 0; j < rotateCount % columns; j++)
                        {
                            tempQueue.Enqueue(tempQueue.Dequeue());
                        }
                        for (int j = 0; j < columns; j++)
                        {
                            matrix[rotateTarget, j] = tempQueue.Dequeue();
                        }
                        break;
                    case "right":
                        for (int j = columns-1; j >=0; j--)
                        {
                            tempQueue.Enqueue(matrix[rotateTarget, j]);
                        }
                        for (int j = 0; j < rotateCount % columns; j++)
                        {
                            tempQueue.Enqueue(tempQueue.Dequeue());
                        }
                        for (int j = columns-1; j >=0; j--)
                        {
                            matrix[rotateTarget, j] = tempQueue.Dequeue();
                        }
                        break;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] != fillCounter)
                    {
                        for (int k = i; k < rows; k++)
                        {
                            for (int l = 0; l < columns; l++)
                            {
                                if (fillCounter == matrix[k, l])
                                {
                                    Console.WriteLine($"Swap ({i}, {j}) with ({k}, {l})");
                                    int tempItem = matrix[i, j];
                                    matrix[i, j] = matrix[k, l];
                                    matrix[k, l] = tempItem;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                    fillCounter++;
                }
            }
        }
    }
}
