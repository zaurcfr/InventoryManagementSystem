using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Budget { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
        public List<Warehouse> Warehouses { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
