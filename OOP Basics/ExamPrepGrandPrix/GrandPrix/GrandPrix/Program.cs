using System;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        int lapsNumber = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());
        RaceTower raceTower = new RaceTower(lapsNumber, trackLength);

        while (!raceTower.IsRaceFinished)
        {
            var input = Console.ReadLine().Split(' ').ToList();

            switch (input[0])
            {
                case "RegisterDriver":
                    input.RemoveAt(0);
                    raceTower.RegisterDriver(input);
                    break;
                case "Leaderboard":
                    Console.WriteLine(raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    input.RemoveAt(0);
                    var result = raceTower.CompleteLaps(input);
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                    }
                    break;
                case "Box":
                    input.RemoveRange(0, 2);
                    raceTower.DriverBoxes(input);
                    break;
                case "ChangeWeather":
                    input.RemoveAt(0);
                    raceTower.ChangeWeather(input);
                    break;
            }
        }
        Console.WriteLine(raceTower.ResultString);
    }
}

