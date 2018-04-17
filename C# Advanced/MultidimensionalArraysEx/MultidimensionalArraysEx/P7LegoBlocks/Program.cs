using System;
using System.Linq;

namespace P7LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            var leftArr = new string[rows][];
            var rightArr = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                leftArr[i] = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            }
            for (int i = 0; i < rows; i++)
            {
                rightArr[i] = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            }
            bool isSquare = true;
            for (int i = 1; i < rows; i++)
            {
                if (leftArr[i].Length + rightArr[i].Length != leftArr[i-1].Length + rightArr[i-1].Length)
                {
                    isSquare = false;
                    break;
                }
            }
            if (isSquare)
            {
                for (int i = 0; i < rows; i++)
                {
                    Console.Write("[");
                    for (int j = 0; j < leftArr[i].Length; j++)
                    {
                        Console.Write(leftArr[i][j]+", ");
                    }
                    for (int j = rightArr[i].Length-1; j >=0; j--)
                    {
                        if (j!=0)
                        {
                            Console.Write(rightArr[i][j] + ", ");
                        }
                        else
                        {
                            Console.Write(rightArr[i][j]);
                        }
                    }
                    Console.WriteLine("]");
                }
            }
            else
            {
                int totalElements = 0;
                for (int i = 0; i < rows; i++)
                {

                    totalElements += leftArr[i].Length + rightArr[i].Length;
                }
                Console.WriteLine($"The total number of cells is: {totalElements}");
            }
        }
    }
}
