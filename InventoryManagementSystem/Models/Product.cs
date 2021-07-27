using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public Warehouse Warehouse { get; set; }
        public Company Company { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
