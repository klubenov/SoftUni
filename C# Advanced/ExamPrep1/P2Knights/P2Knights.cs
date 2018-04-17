using System;
using System.Numerics;

namespace P2Knights
{
    class P2Knights
    {
        static void Main(string[] args)
        {
            int side = int.Parse(Console.ReadLine());

            char[,] matrix = new char[side, side];

            for (int i = 0; i < side; i++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < side; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }
            for (int c = 0; c < Int32.MaxValue; c++)
            {
                int[] maxAttacksIndexes = new int[2];
                int maxAttackCount = 0;
                for (int i = 0; i < side; i++)
                {
                    for (int j = 0; j < side; j++)
                    {
                        if (matrix[i, j] == 'K')
                        {
                            int currentKnightAttacks = 0;
                            currentKnightAttacks = checkForTargets(matrix, i - 2, j - 1, currentKnightAttacks);
                            currentKnightAttacks = checkForTargets(matrix, i - 2, j + 1, currentKnightAttacks);
                            currentKnightAttacks = checkForTargets(matrix, i - 1, j - 2, currentKnightAttacks);
                            currentKnightAttacks = checkForTargets(matrix, i - 1, j + 2, currentKnightAttacks);
                            currentKnightAttacks = checkForTargets(matrix, i + 1, j - 2, currentKnightAttacks);
                            currentKnightAttacks = checkForTargets(matrix, i + 1, j + 2, currentKnightAttacks);
                            currentKnightAttacks = checkForTargets(matrix, i + 2, j - 1, currentKnightAttacks);
                            currentKnightAttacks = checkForTargets(matrix, i + 2, j + 1, currentKnightAttacks);
                            if (currentKnightAttacks > maxAttackCount)
                            {
                                maxAttackCount = currentKnightAttacks;
                                maxAttacksIndexes[0] = i;
                                maxAttacksIndexes[1] = j;
                            }
                        }
                    }
                }
                if (maxAttackCount==0)
                {
                    Console.WriteLine(c);
                    break;
                }
                matrix[maxAttacksIndexes[0], maxAttacksIndexes[1]] = '0';
            }
        }

        private static int checkForTargets(char[,] matrix, int i, int j, int currentKnightAttacks)
        {
            try
            {
                if (matrix[i, j] == 'K')
                {
                    currentKnightAttacks++;
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
            return currentKnightAttacks;
        }
    }
}
