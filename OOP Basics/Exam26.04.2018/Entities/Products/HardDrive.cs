using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Products
{
    public class HardDrive : Product
    {
        private const double defaultWeight = 1;

        public HardDrive(double price) : base(price, defaultWeight)
        {
        }
    }
}
