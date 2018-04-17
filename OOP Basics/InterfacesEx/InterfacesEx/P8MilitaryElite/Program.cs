using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var currentPrivateList = new List<Private>();

        string input;

        while ((input = Console.ReadLine())!="End")
        {
            var inputData = input.Split(' ');

            switch (inputData[0])
            {
                case "Private":
                    var newPrivate = new Private(inputData[1], inputData[2], inputData[3], decimal.Parse(inputData[4]));
                    currentPrivateList.Add(newPrivate);
                    Console.WriteLine(newPrivate);
                    break;
                case "LeutenantGeneral":
                    var privateList = new List<Private>();
                    for (int i = 5; i < inputData.Length; i++)
                    {
                        privateList.Add(currentPrivateList.First(a=>a.Id==inputData[i]));
                    }
                    var newLeutenantGeneral = new LeutenantGeneral(inputData[1], inputData[2], inputData[3], decimal.Parse(inputData[4]), privateList);
                    Console.WriteLine(newLeutenantGeneral);
                    break;
                case "Engineer":
                    var repairList = new List<Repairs>();

                    for (int i = 6; i < inputData.Length; i+=2)
                    {
                        var newRepair = new Repairs(inputData[i], int.Parse(inputData[i + 1]));
                        repairList.Add(newRepair);
                    }
                    try
                    {
                        var newEngineer = new Engineer(inputData[1], inputData[2], inputData[3], decimal.Parse(inputData[4]), inputData[5], repairList);
                        Console.WriteLine(newEngineer);

                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }
                    break;
                case "Commando":
                    var missionList = new List<Mission>();

                    for (int i = 6; i < inputData.Length; i += 2)
                    {
                        try
                        {
                            var newMission = new Mission(inputData[i], inputData[i+1]);
                            missionList.Add(newMission);
                        }
                        catch (ArgumentException)
                        {
                            continue;
                        }
                    }
                    try
                    {
                        var newCommando = new Commando(inputData[1], inputData[2], inputData[3], decimal.Parse(inputData[4]), inputData[5], missionList);
                        Console.WriteLine(newCommando);
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }
                    break;
                case "Spy":
                    var newSpy = new Spy(inputData[1], inputData[2], inputData[3], int.Parse(inputData[4]));
                    Console.WriteLine(newSpy);
                    break;
            }
        }
    }
}

