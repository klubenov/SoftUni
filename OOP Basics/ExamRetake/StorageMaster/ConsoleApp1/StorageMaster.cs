using StorageMaster.Entities.Factories;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storages;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StorageMaster
{
    public class StorageMaster
    {
        private Vehicle currentVehicle;
        private List<Product> producPool;
        private List<Storage> storageRegister;
        private ProductFactory productFactory;
        private StorageFactory storageFactory;

        public StorageMaster()
        {
            this.producPool = new List<Product>();
            this.storageRegister = new List<Storage>();
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            var product = this.productFactory.CreateProduct(type,price);

            this.producPool.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.CreateStorage(type, name);

            this.storageRegister.Add(storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegister.FirstOrDefault(s => s.Name == storageName);

            var vehicle = storage.GetVehicle(garageSlot);

            this.currentVehicle = vehicle;

            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int successfullyLoadedProducts = 0;
            

            foreach (var productName in productNames)
            {
                if (!this.producPool.Any(p => p.GetType().Name == productName))
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                int currentQty = this.producPool.Count;
                try
                {
                    for (int i = currentQty - 1; i >= 0; i--)
                    {
                        if (producPool[i].GetType().Name == productName)
                        {
                            this.currentVehicle.LoadProduct(producPool[i]);
                            successfullyLoadedProducts++;
                            producPool.RemoveAt(i);
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    break;
                }
                
            }

            return $"Loaded {successfullyLoadedProducts}/{productNames.Count()} products into {currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storageRegister.Any(s => s.Name == sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            if (!this.storageRegister.Any(s => s.Name == destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            var source = this.storageRegister.First(s => s.Name == sourceName);
            var destination = this.storageRegister.First(s => s.Name == destinationName);

            int destinationSlot = source.SendVehicleTo(sourceGarageSlot, destination);
            string vehicleType = destination.GetVehicle(destinationSlot).GetType().Name;

            return $"Sent {vehicleType} to {destination.Name} (slot {destinationSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegister.First(s => s.Name == storageName);
            var vehicle = storage.GetVehicle(garageSlot);
            int productsInVehicle = vehicle.Trunk.Count;

            var unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = this.storageRegister.First(s => s.Name == storageName);

            var productWeight = storage.Products.Sum(p => p.Weight);

            var productDict = new Dictionary<string, int>();

            foreach (var product in storage.Products)
            {
                string productName = product.GetType().Name;

                if (!productDict.ContainsKey(productName))
                {
                    productDict.Add(productName, 1);
                }
                else
                {
                    productDict[productName]++;
                }
            }

            var productSb = new StringBuilder();

            foreach (var productGroup in productDict.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
            {
                productSb.Append($"{productGroup.Key} ({productGroup.Value}), ");
            }

            string aggregateProductString = $"({productWeight}/{storage.Capacity}): [{productSb.ToString().TrimEnd(new char[] { ',', ' ' })}]";

            var garageSb = new StringBuilder();
            foreach (var vehicle in storage.Garage)
            {
                if (vehicle!=null)
                {
                    garageSb.Append($"{vehicle.GetType().Name}|");
                }
                else
                {
                    garageSb.Append("empty|");
                }
            }

            string aggregateVehicleString = garageSb.ToString().TrimEnd('|');

            return $"Stock {aggregateProductString}{Environment.NewLine}Garage: [{aggregateVehicleString}]";
        }

        public string GetSummary()
        {
            var summarySb = new StringBuilder();

            foreach (var storage in storageRegister.OrderByDescending(s => s.Products.Sum(p => p.Price)))
            {
                summarySb.AppendLine(storage.ToString());
            }

            return summarySb.ToString().TrimEnd();
        }
    }
}
