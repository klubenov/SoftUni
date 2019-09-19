using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Storages
{
    public abstract class Storage
    {
        private Vehicle[] garage;
        private List<Product> products;
        private double totalMoney => this.products.Sum(p => p.Price);

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.products = new List<Product>();
            this.garage = new Vehicle[garageSlots];

            int capacityCounter = 0;

            foreach (var vehicle in vehicles)
            {
                this.garage[capacityCounter] = vehicle;
                capacityCounter++;
            }
        }

        public string Name { get; }

        public int Capacity { get; }

        public int GarageSlots { get; }

        public bool IsFull => this.Products.Sum(p => p.Weight) >= this.Capacity;

        public bool HasFreeSlots => this.garage.Any(s => s == null);

        public IReadOnlyCollection<Vehicle> Garage => this.garage.ToList().AsReadOnly();

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();


        //public int AddVehicle(Vehicle vehicle)
        //{
        //    int slot = 0;

        //    for (int i = 0; i < GarageSlots; i++)
        //    {
        //        if (garage[i] == null)
        //        {
        //            garage[i] = vehicle;
        //            slot = i;
        //            break;
        //        }
        //    }

        //    return slot;
        //}

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = this.GetVehicle(garageSlot);

            if (!deliveryLocation.Garage.Any(v => v == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;

            int slot = 0;

            for (int i = 0; i < deliveryLocation.Garage.Count; i++)
            {
                if (deliveryLocation.garage[i] == null)
                {
                    deliveryLocation.garage[i] = vehicle;
                    slot = i;
                    break;
                }
            }

            return slot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var vehicle = this.GetVehicle(garageSlot);

            int unloadCounter = 0;

            while (!IsFull)
            {
                try
                {
                    var product = vehicle.Unload();

                    this.products.Add(product);
                    unloadCounter++;
                }
                catch (Exception e)
                {
                    break;
                }
            }

            return unloadCounter;
        }

        public override string ToString()
        {
            return $"{this.Name}:{Environment.NewLine}Storage worth: ${totalMoney:f2}";
        }
    }
}
