using System;
using System.Collections.Generic;
using System.Linq;

namespace P8RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];
            var matrix = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            var movement = Console.ReadLine().ToCharArray();
            bool isAlive = true;
            bool isInside = true;
            bool isFound = false;
            int[] lastAliveOrInside = new int[2];

            for (int i = 0; i < movement.Length; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    for (int k = 0; k < columns; k++)
                    {
                        if (matrix[j,k]=='P')
                        {
                            isFound = true;
                            switch (movement[i])
                            {
                                case 'U':
                                    try
                                    {
                                        if (matrix[j - 1, k] != 'B')
                                        {
                                            matrix[j - 1, k] = 'P';
                                            matrix[j, k] = '.';
                                        }
                                        else
                                        {
                                            isAlive = false;
                                            lastAliveOrInside[0] = j-1;
                                            lastAliveOrInside[1] = k;
                                        }
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        isInside = false;
                                        lastAliveOrInside[0] = j;
                                        lastAliveOrInside[1] = k;
                                        matrix[j, k] = '.';
                                    }
                                    break;
                                case 'D':
                                    try
                                    {
                                        if (matrix[j + 1, k] != 'B')
                                        {
                                            matrix[j + 1, k] = 'P';
                                            matrix[j, k] = '.';
                                        }
                                        else
                                        {
                                            isAlive = false;
                                            lastAliveOrInside[0] = j+1;
                                            lastAliveOrInside[1] = k;
                                        }
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        isInside = false;
                                        lastAliveOrInside[0] = j;
                                        lastAliveOrInside[1] = k;
                                        matrix[j, k] = '.';
                                    }
                                    break;
                                case 'L':
                                    try
                                    {
                                        if (matrix[j , k - 1] != 'B')
                                        {
                                            matrix[j , k - 1] = 'P';
                                            matrix[j, k] = '.';
                                        }
                                        else
                                        {
                                            isAlive = false;
                                            lastAliveOrInside[0] = j;
                                            lastAliveOrInside[1] = k-1;
                                        }
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        isInside = false;
                                        lastAliveOrInside[0] = j;
                                        lastAliveOrInside[1] = k;
                                        matrix[j, k] = '.';
                                    }
                                    break;
                                case 'R':
                                    try
                                    {
                                        if (matrix[j, k + 1] != 'B')
                                        {
                                            matrix[j, k + 1] = 'P';
                                            matrix[j, k] = '.';
                                        }
                                        else
                                        {
                                            isAlive = false;
                                            lastAliveOrInside[0] = j;
                                            lastAliveOrInside[1] = k+1;
                                        }
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        isInside = false;
                                        lastAliveOrInside[0] = j;
                                        lastAliveOrInside[1] = k;
                                        matrix[j, k] = '.';
                                    }
                                    break;
                            }  
                        }
                        if (isFound || !isInside || !isAlive)
                        {
                            break;
                        }                        
                    }
                    if (isFound || !isInside || !isAlive)
                    {
                        isFound = false;
                        break;
                    }
                }

                var bunniesCoordiantes = new Queue<Tuple<int, int>>();

                for (int l = 0; l < rows; l++)
                {
                    for (int m = 0; m < columns; m++)
                    {
                        try
                        {
                            if (matrix[l, m] == 'B' && matrix[l - 1, m] == 'B' && matrix[l, m - 1] == 'B' && matrix[l + 1, m] == 'B' && matrix[l, m + 1] == 'B')
                            {
                                continue;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                        }
                        if (matrix[l, m] == 'B')
                        {
                            bunniesCoordiantes.Enqueue(new Tuple<int, int>(l, m));
                        }
                    }
                }
                var bunnieCount = bunniesCoordiantes.Count;
                for (int b = 0; b < bunnieCount; b++)
                {
                    var currentBunnie = bunniesCoordiantes.Dequeue();
                    var bunnieRow = currentBunnie.Item1;
                    var bunnieColumn = currentBunnie.Item2;
                    try
                    {
                        if (matrix[bunnieRow + 1, bunnieColumn] == 'P')
                        {
                            if (isAlive)
                            {
                                lastAliveOrInside[0] = bunnieRow + 1;
                                lastAliveOrInside[1] = bunnieColumn;
                            }
                            isAlive = false;
                        }
                        matrix[bunnieRow + 1, bunnieColumn] = 'B';
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                    try
                    {
                        if (matrix[bunnieRow - 1, bunnieColumn] == 'P')
                        {
                            if (isAlive)
                            {
                                lastAliveOrInside[0] = bunnieRow - 1;
                                lastAliveOrInside[1] = bunnieColumn;
                            }
                            isAlive = false;
                        }
                        matrix[bunnieRow - 1, bunnieColumn] = 'B';
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                    try
                    {
                        if (matrix[bunnieRow, bunnieColumn + 1] == 'P')
                        {
                            if (isAlive)
                            {
                                lastAliveOrInside[0] = bunnieRow;
                                lastAliveOrInside[1] = bunnieColumn + 1;
                            }
                            isAlive = false;
                        }
                        matrix[bunnieRow, bunnieColumn + 1] = 'B';
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                    try
                    {
                        if (matrix[bunnieRow, bunnieColumn - 1] == 'P')
                        {
                            if (isAlive)
                            {
                                lastAliveOrInside[0] = bunnieRow;
                                lastAliveOrInside[1] = bunnieColumn - 1;
                            }
                            isAlive = false;
                        }
                        matrix[bunnieRow, bunnieColumn - 1] = 'B';
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                }
                if (!isAlive || !isInside)
                {
                    break;
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
            if (!isInside)
            {
                Console.WriteLine($"won: {lastAliveOrInside[0]} {lastAliveOrInside[1]}");
            }
            if (!isAlive)
            {
                Console.WriteLine($"dead: {lastAliveOrInside[0]} {lastAliveOrInside[1]}");
            }
        }
    }
}
