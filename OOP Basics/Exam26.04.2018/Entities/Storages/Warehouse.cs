using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Storages
{
    public class Warehouse : Storage
    {
        private const int defaultCapacity = 10;
        private const int defaultGarageSlots = 10;

        public Warehouse(string name)
            : base(name, defaultCapacity, defaultGarageSlots, new Vehicle[] {
            new Semi(),
            new Semi(),
            new Semi()})
        {

        }
    }
}
