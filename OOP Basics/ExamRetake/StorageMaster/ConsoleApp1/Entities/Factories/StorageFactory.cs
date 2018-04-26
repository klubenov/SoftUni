using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Storages;

namespace StorageMaster.Entities.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            switch (type)
            {
                case "AutomatedWarehouse":
                    return new AutomatedWarehouse(name);
                case "DistributionCenter":
                    return new DistributionCenter(name);
                case "Warehouse":
                    return new Warehouse(name);
            }

            throw new InvalidOperationException("Invalid storage type!");
        }
    }
}
