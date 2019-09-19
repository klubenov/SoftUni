using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Storages
{
    public class DistributionCenter : Storage
    {
        private const int defaultCapacity = 2;
        private const int defaultGarageSlots = 5;

        public DistributionCenter(string name)
            : base(name, defaultCapacity, defaultGarageSlots, new Vehicle[] {
            new Van(),
            new Van(),
            new Van()})
        {

        }
    }
}
