using StorageMaster.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Products
{
    public abstract class Product : IProduct
    {
        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        private double price;

        public double Price
        {
            get { return this.price; }
            private set
            {
                if (value<0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                this.price = value;
            }
        }

        public double Weight { get; }
    }
}
