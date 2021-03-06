using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public Company Company { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
