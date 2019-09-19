using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
    public abstract class Vehicle
    {
        private List<Product> products;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.products = new List<Product>();
        }

        public int Capacity { get; }

        public IReadOnlyCollection<Product> Trunk => this.products.AsReadOnly();

        public bool IsFull => this.Trunk.Sum(p => p.Weight) >= Capacity;

        public bool IsEmpty => this.Trunk.Count == 0;

        public void LoadProduct(Product product)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }
            this.products.Add(product);
        }

        public Product Unload()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }
            int lastIndex = products.Count - 1;
            var productToReturn = this.products[lastIndex];
            this.products.RemoveAt(lastIndex);

            return productToReturn;
        }
    }
}
