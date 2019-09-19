namespace StorageMaster
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var storageMaster = new StorageMaster();

            while (true)
            {
                var input = Console.ReadLine().Split(' ');

                switch (input[0])
                {
                    case "AddProduct":
                        string productType = input[1];
                        double productPrice = double.Parse(input[2]);
                        try
                        {
                            string result = storageMaster.AddProduct(productType, productPrice);
                            Console.WriteLine(result);
                        }
                        catch (Exception e)
                        {
                            PrintException(e.Message);
                        }
                        break;
                    case "RegisterStorage":
                        string storageType = input[1];
                        string storageName = input[2];
                        try
                        {
                            string result = storageMaster.RegisterStorage(storageType, storageName);
                            Console.WriteLine(result);
                        }
                        catch (Exception e)
                        {
                            PrintException(e.Message);
                        }
                        break;
                    case "SelectVehicle":
                        string storageToSearch = input[1];
                        int slot = int.Parse(input[2]);
                        try
                        {
                            string result = storageMaster.SelectVehicle(storageToSearch, slot);
                            Console.WriteLine(result);
                        }
                        catch (Exception e)
                        {
                            PrintException(e.Message);
                        }
                        break;
                    case "LoadVehicle":
                        var productsToLoad = input.Skip(1);
                        try
                        {
                            string result = storageMaster.LoadVehicle(productsToLoad);
                            Console.WriteLine(result);
                        }
                        catch (Exception e)
                        {
                            PrintException(e.Message);
                        }
                        break;
                    case "SendVehicleTo":
                        string source = input[1];
                        int garageSlot = int.Parse(input[2]);
                        string destination = input[3];
                        try
                        {
                            string result = storageMaster.SendVehicleTo(source, garageSlot, destination);
                            Console.WriteLine(result);
                        }
                        catch (Exception e)
                        {
                            PrintException(e.Message);
                        }
                        break;
                    case "UnloadVehicle":
                        string storageNameForUnloading = input[1];
                        int garageSlotToUnload = int.Parse(input[2]);
                        try
                        {
                            string result = storageMaster.UnloadVehicle(storageNameForUnloading, garageSlotToUnload);
                            Console.WriteLine(result);
                        }
                        catch (Exception e)
                        {
                            PrintException(e.Message);
                        }
                        break;
                    case "GetStorageStatus":
                        string statusTarget = input[1];
                        try
                        {
                            string result = storageMaster.GetStorageStatus(statusTarget);
                            Console.WriteLine(result);
                        }
                        catch (Exception e)
                        {
                            PrintException(e.Message);
                        }
                        break;
                    case "END":
                        try
                        {
                            string result = storageMaster.GetSummary();
                            Console.WriteLine(result);
                            Environment.Exit(0);
                        }
                        catch (Exception e)
                        {
                            PrintException(e.Message);
                            Environment.Exit(0);
                        }
                        break;
                }
            }
        }

        public static void PrintException(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
