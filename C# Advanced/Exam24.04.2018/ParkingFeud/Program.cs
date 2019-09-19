using System;
using System.Linq;

namespace ParkingFeud
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = size[0];
            int columns = size[1];

            int startingEntrance = int.Parse(Console.ReadLine());

            int parkingRows = 2 * size[0];
            int parkingColumns = 2 + size[1];

            var parking = new char[parkingRows, parkingColumns];

            bool isThereConflict = false;
            bool isSamParked = false;
            int samTotalDistance = 0;

            while (!isSamParked)
            {
                var spots = Console.ReadLine().Split(' ');
                isThereConflict = CheckForConflict(spots, startingEntrance-1);

                var samTargetSpot = spots[startingEntrance-1];

                if (!isThereConflict)
                {
                    var distancePassed = CalculateDistanceToSpot(columns, startingEntrance, samTargetSpot);
                    Console.WriteLine($"Parked successfully at {samTargetSpot}.");
                    Console.WriteLine($"Total Distance Passed: {samTotalDistance + distancePassed}");
                    Environment.Exit(0);
                }
                else
                {
                    int conflicDriverIndex = FindConfilictDriverIndex(spots, samTargetSpot, startingEntrance-1);
                    int conflictDriverDistance = CalculateDistanceToSpot(columns, conflicDriverIndex, samTargetSpot);
                    int samDistance = CalculateDistanceToSpot(columns, startingEntrance, samTargetSpot);

                    if (samDistance<=conflictDriverDistance)
                    {
                        Console.WriteLine($"Parked successfully at {samTargetSpot}.");
                        Console.WriteLine($"Total Distance Passed: {samTotalDistance + samDistance}");
                        Environment.Exit(0);
                    }
                    else
                    {
                        samTotalDistance += (samDistance * 2);
                    }
                }
            }


        }

        public static int CalculateDistanceToSpot(int columns, int entrance, string target)
        {
            int targetCol = target[0] - 64;
            int targetRow = int.Parse(target[1].ToString());
            int distance = 0;

            if (targetRow==entrance || entrance+1==targetRow)
            {
                distance = targetCol;
            }
            else if(entrance<targetRow)
            {
                int rowsToSkip = Math.Abs(targetRow - entrance);
                if (rowsToSkip%2==0)
                {
                    distance = (rowsToSkip-1) * (columns + 3) + (columns-targetCol) + 1;
                }
                else
                {
                    distance = rowsToSkip * (columns + 3) + columns;
                }
            }
            else //entrance>targetRow
            {
                int rowsToSkip = entrance - targetRow;
                if (rowsToSkip % 2 == 1)
                {
                    distance = rowsToSkip * (columns + 3) + (columns - targetCol) + 1;
                }
                else
                {
                    distance = rowsToSkip * (columns + 3) + columns;
                }
            }
            return distance;
        }

        public static bool CheckForConflict(string[] spots, int index)
        {
            var spotToCheck = spots[index];
            for (int i = 0; i < spots.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }
                if (spots[i]==spotToCheck)
                {
                    return true;
                }
            }
            return false;
        }

        public static int FindConfilictDriverIndex(string[] spots, string spot, int samIndex)
        {
            for (int i = 0; i < spots.Length; i++)
            {
                if (i == samIndex)
                {
                    continue;
                }
                if (spots[i] == spot)
                {
                    return i+1;
                }
            }

            return 0;
        }
    }
}
