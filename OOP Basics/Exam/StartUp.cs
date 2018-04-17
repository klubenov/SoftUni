using System;
using System.Linq;

namespace DungeonsAndCodeWizards
{
    public class StartUp
    {
        // DO NOT rename this file's namespace or class name.
        // However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
        public static void Main(string[] args)
        {
            DungeonMaster dungeonMaster = new DungeonMaster();
            while (dungeonMaster.IsGameOver() == false)
            {
                string inputString = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputString))
                {
                    break;
                }
                var input = inputString.Split(' ');

                switch (input[0])
                {
                    case "JoinParty":
                        try
                        {

                            Console.WriteLine(dungeonMaster.JoinParty(input.Skip(1).ToArray()));
                        }
                        catch (Exception exception)
                        {
                            HandleException(exception);
                            Console.WriteLine(exception.Message);
                        }
                        break;
                    case "AddItemToPool":
                        try
                        {
                            Console.WriteLine(dungeonMaster.AddItemToPool(input.Skip(1).ToArray()));
                        }
                        catch (Exception exception)
                        {
                            HandleException(exception);
                        }
                        break;
                    case "PickUpItem":
                        try
                        {
                            Console.WriteLine(dungeonMaster.PickUpItem(input.Skip(1).ToArray()));
                        }
                        catch (Exception exception)
                        {
                            HandleException(exception);
                        }
                        break;
                    case "UseItem":
                        try
                        {
                            Console.WriteLine(dungeonMaster.UseItem(input.Skip(1).ToArray()));
                        }
                        catch (Exception exception)
                        {
                            HandleException(exception);
                        }
                        break;
                    case "UseItemOn":
                        try
                        {
                            Console.WriteLine(dungeonMaster.UseItemOn(input.Skip(1).ToArray()));
                        }
                        catch (Exception exception)
                        {
                            HandleException(exception);
                        }
                        break;
                    case "GiveCharacterItem":
                        try
                        {
                            Console.WriteLine(dungeonMaster.GiveCharacterItem(input.Skip(1).ToArray()));
                        }
                        catch (Exception exception)
                        {
                            HandleException(exception);
                        }
                        break;
                    case "GetStats":
                        try
                        {

                            Console.WriteLine(dungeonMaster.GetStats());
                        }
                        catch (Exception exception)
                        {
                            HandleException(exception);
                        }
                        break;
                    case "Attack":
                        try
                        {
                            Console.WriteLine(dungeonMaster.Attack(input.Skip(1).ToArray()));
                        }
                        catch (Exception exception)
                        {
                            HandleException(exception);
                        }
                        break;
                    case "Heal":
                        try
                        {
                            Console.WriteLine(dungeonMaster.Heal(input.Skip(1).ToArray()));
                        }
                        catch (Exception exception)
                        {
                            HandleException(exception);
                        }
                        break;
                    case "EndTurn":
                        try
                        {
                            Console.WriteLine(dungeonMaster.EndTurn(input));
                        }
                        catch (Exception exception)
                        {
                            HandleException(exception);
                        }
                        break;
                    case "IsGameOver":
                        break;
                }
            }
            Console.WriteLine($"Final stats:\r\n{dungeonMaster.GetStats()}");
        }

        private static void HandleException(Exception exception)
        {
            if (exception is InvalidOperationException)
            {
                Console.WriteLine($"Invalid Operation: {exception.Message}");
            }
            else if (exception is ArgumentException)
            {
                Console.WriteLine($"Parameter Error: {exception.Message}");
            }
        }
    }
}