using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


public class RaceTower
{
    private int LapsNumber { get; set; }

    private int TrackLength { get; set; }

    private string Weather { get; set; }

    private int CurrentLap { get; set; }

    public List<Driver> Drivers { get; set; }

    public bool IsRaceFinished => this.CurrentLap == this.LapsNumber;

    public Driver Winner => this.Drivers.Where(d => d.IsDnf == false).OrderBy(d => d.TotalTime).First();

    public string ResultString => $"{this.Winner.Name} wins the race for {this.Winner.TotalTime:f3} seconds.";

    public RaceTower(int lapsNumber, int trackLength)
    {
        this.Weather = "Sunny";
        this.CurrentLap = 0;
        this.LapsNumber = lapsNumber;
        this.TrackLength = trackLength;
        this.Drivers = new List<Driver>();
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.LapsNumber = lapsNumber;
        this.TrackLength = trackLength;
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var driverFactory = new DriverFactory();
            var newDriver = driverFactory.CreateDriver(commandArgs);
            Drivers.Add(newDriver);
        }
        catch (InvalidDataException exception)
        {
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var driver = Drivers.Find(d => d.Name == commandArgs[0]);
        driver.Box(commandArgs.Skip(1).ToList());
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var lapsToComplete = int.Parse(commandArgs[0]);
        var overtakeSb = new StringBuilder();
        if (lapsToComplete+CurrentLap>LapsNumber)
        {
            try
            {
                throw new ArgumentException($"There is no time! On lap {CurrentLap}.");
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }

        }
        for (int i = 0; i < lapsToComplete; i++)
        {
            var driversInRace = Drivers.Where(d => d.IsDnf == false).ToList();
            for (int j = 0; j < driversInRace.Count; j++)
            {
                driversInRace[j].CompleteLap(this.TrackLength);
            }

            var overtakeCheckList = this.OvertakeCheckList(Drivers);
            bool overtakeOccurance = false;

            for (int j = 0; j < overtakeCheckList.Count-1; j++)
            {
                if (overtakeOccurance)
                {
                    overtakeOccurance = false;
                    continue;
                }
                var driver = overtakeCheckList[j];
                var driverAhead = overtakeCheckList[j + 1];
                bool isDriverAggressiveUltrasoftFoggy = driver.GetType().Name == "AggressiveDriver"
                                                        && driver.Car.Tyre.Name == "Ultrasoft" &&
                                                        this.Weather == "Foggy";
                bool isDriverEnduranceHardRainy = driver.GetType().Name == "EnduranceDriver"
                                                  && driver.Car.Tyre.Name == "Hard" &&
                                                  this.Weather == "Rainy";
                if (isDriverEnduranceHardRainy || isDriverAggressiveUltrasoftFoggy)
                {
                    if (driver.TotalTime-driverAhead.TotalTime<=3)
                    {
                        driver.DnfDriver("Crashed");
                    }
                }

                if (driver.TotalTime-driverAhead.TotalTime<=2)
                {
                    driver.Overtake();
                    driverAhead.GetOvertaken();
                    overtakeOccurance = true;
                    overtakeSb.AppendLine($"{driver.Name} has overtaken {driverAhead.Name} on lap {CurrentLap}.");
                }
            }
            CurrentLap++;
        }
        return overtakeSb.ToString().Trim();
    }   

    public string GetLeaderboard()
    {
        var leaderBoardSB = new StringBuilder();
        leaderBoardSB.Append($"Lap {CurrentLap}/{LapsNumber}").AppendLine();
        int standingCounter = 1;
        foreach (var driver in Drivers.OrderBy(d => d.IsDnf).ThenBy(d => d.TotalTime))
        {
            leaderBoardSB.Append($"{standingCounter} {driver}").AppendLine();
            standingCounter++;
        }
        return leaderBoardSB.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.Weather = commandArgs[0];
    }

    private List<Driver> OvertakeCheckList(List<Driver> drivers)
    {
        return drivers.Where(d => d.IsDnf == false).OrderByDescending(d => d.TotalTime).ToList();
    }
}

