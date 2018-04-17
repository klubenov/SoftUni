using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class P03_JediGalaxy
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimestions[0];
            int columns = dimestions[1];

            int[,] matrix = new int[rows, columns];

            int value = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            string command;
            long sum = 0;
            while ((command=Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoStartCoordinates = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilStartCoordinates = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int evilStartRow = evilStartCoordinates[0];
                int evilStartColumn = evilStartCoordinates[1];

                while (evilStartRow >= 0 && evilStartColumn >= 0)
                {
                    if (evilStartRow<rows && evilStartColumn<columns)
                    {
                        matrix[evilStartRow, evilStartColumn] = 0;
                    }
                    evilStartRow--;
                    evilStartColumn--;
                }

                int ivoStartRow = ivoStartCoordinates[0];
                int ivoStartColumn = ivoStartCoordinates[1];

                while (ivoStartRow >= 0 && ivoStartColumn < columns)
                {
                    if (ivoStartRow < rows && ivoStartColumn < columns && ivoStartColumn>=0)
                    {
                        sum += matrix[ivoStartRow, ivoStartColumn];
                    }

                    ivoStartColumn++;
                    ivoStartRow--;
                }

            }

            Console.WriteLine(sum);

        }
    }
}
