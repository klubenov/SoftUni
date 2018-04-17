using System;
using System.Collections.Generic;

namespace P12StringMatrixRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var rotateCommand = Console.ReadLine().Split(new[] {'(', ')'});
            var rotationDegrees = int.Parse(rotateCommand[1]);
            int rotationTimes = rotationDegrees / 90 % 4;

            var input = Console.ReadLine();

            List<char[]> arrayList = new List<char[]>();

            while (input != "END")
            {
                arrayList.Add(input.ToCharArray());
                input = Console.ReadLine();
            }

            int maxLength = 0;

            foreach (var charArr in arrayList)
            {
                if (charArr.Length > maxLength)
                {
                    maxLength = charArr.Length;
                }
            }

            switch (rotationTimes)
            {
                case 0:
                    for (int i = 0; i < arrayList.Count; i++)
                    {
                        Console.WriteLine(string.Join("", arrayList[i]));
                    }
                    break;
                case 1:
                    for (int i = 0; i < maxLength; i++)
                    {
                        for (int j = arrayList.Count-1; j >=0 ; j--)
                        {
                            try
                            {
                                Console.Write(arrayList[j][i]);
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    for (int i = arrayList.Count-1; i >=0; i--)
                    {
                        for (int j = maxLength-1; j >=0; j--)
                        {
                            try
                            {
                                Console.Write(arrayList[i][j]);
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    for (int i = maxLength-1; i >=0; i--)
                    {
                        for (int j = 0; j <arrayList.Count; j++)
                        {
                            try
                            {
                                Console.Write(arrayList[j][i]);
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
            }
        }
    }
}
