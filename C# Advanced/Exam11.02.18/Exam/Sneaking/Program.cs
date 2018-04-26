using System;
using System.Linq;

namespace Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] room = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                room[i] = Console.ReadLine().ToCharArray();
            }

            char[] characterMoves = Console.ReadLine().ToCharArray();
            int movesIndex = 0;
            int[] characterDeathLocation = new int[2];

            bool isCharacterAlive = true;
            bool isNikoladzeAlive = true;

            while (true)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (!isCharacterAlive)
                    {
                        Console.WriteLine($"Sam died at {characterDeathLocation[0]}, {characterDeathLocation[1]}");
                        PrintRoom(room);
                        Environment.Exit(0);
                    }
                    if (!isNikoladzeAlive)
                    {
                        Console.WriteLine("Nikoladze killed!");
                    }

                    int indexOfEnemy = 0;
                    int indexOfCharacter = 0;
                    bool enemyExists = false;
                    bool enemyWillMove = true;
                    bool isEnemyRightFacing = true;
                    if (room[i].Contains('b'))
                    {
                        indexOfEnemy = FindIndex(room[i], 'b');
                        enemyExists = true;
                    }
                    else if(room[i].Contains('d'))
                    {
                        indexOfEnemy = FindIndex(room[i], 'd');
                        isEnemyRightFacing = false;
                        enemyExists = true;
                    }

                    if (enemyExists)
                    {
                        if (indexOfEnemy == 0 || indexOfEnemy == room[i].Length - 1)
                        {
                            enemyWillMove = false;
                        }
                    }

                    if (room[i].Contains('S'))
                    {
                        indexOfCharacter = FindIndex(room[i], 'S');
                        if (isEnemyRightFacing && indexOfCharacter > indexOfEnemy)
                        {
                            isCharacterAlive = false;
                            room[i][indexOfCharacter] = 'X';
                            characterDeathLocation[0] = i;
                            characterDeathLocation[1] = indexOfCharacter;
                        }
                        else if (!isEnemyRightFacing && indexOfCharacter<indexOfEnemy)
                        {
                            isCharacterAlive = false;
                            room[i][indexOfCharacter] = 'X';
                            characterDeathLocation[0] = i;
                            characterDeathLocation[1] = indexOfCharacter;
                        }
                    }

                    if (enemyExists && enemyWillMove)
                    {
                        if (isEnemyRightFacing)
                        {
                            room[i][indexOfEnemy + 1] = 'b';
                            room[i][indexOfEnemy] = '.';
                        }
                        else
                        {
                            room[i][indexOfEnemy - 1] = 'd';
                            room[i][indexOfEnemy] = '.';
                        }
                    }
                    else if(enemyExists)
                    {
                        if (isEnemyRightFacing)
                        {
                            room[i][indexOfEnemy] = 'd';
                        }
                        else
                        {
                            room[i][indexOfEnemy] = 'b';
                        }
                    }

                    if (isCharacterAlive)
                    {
                        char currentMove = characterMoves[movesIndex];
                        movesIndex++;

                        switch (currentMove)
                        {
                            case 'U':
                                isNikoladzeAlive = IsNikoladzeToBeKIlled(room[i - 1]);
                                room[i - 1][indexOfCharacter] = 'S';
                                room[i][indexOfCharacter] = '.';
                                break;
                            case 'D':
                                isNikoladzeAlive = IsNikoladzeToBeKIlled(room[i + 1]);
                                room[i + 1][indexOfCharacter] = 'S';
                                room[i][indexOfCharacter] = '.';
                                break;
                            case 'L':
                                room[i][indexOfCharacter-1] = 'S';
                                room[i][indexOfCharacter] = '.';
                                break;
                            case 'R':
                                room[i][indexOfCharacter + 1] = 'S';
                                room[i][indexOfCharacter] = '.';
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private static void PrintRoom(char[][] room)
        {   
            for (int i = 0; i < room.Length; i++)
            {
                Console.WriteLine(string.Join("", room[i]));
            }
        }

        public static int FindIndex(char[] line ,char character)
        {
            int index = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i]==character)
                {
                    index = i;
                }
            }
            return index;
        }

        public static bool LineContainsNikoladze(char[] row)
        {
            bool lineContainsNikoladze = false;
            if (row.Contains('N'))
            {
                lineContainsNikoladze = true;
            }
            return lineContainsNikoladze;
        }

        public static bool IsNikoladzeToBeKIlled(char[] row)
        {
            bool isNikoladzeAlive = false;

            if (LineContainsNikoladze(row))
            {
                int index = FindIndex(row, 'N');
                isNikoladzeAlive = false;
                row[index] = 'X';
            }

            return isNikoladzeAlive;
        }
    }
}
