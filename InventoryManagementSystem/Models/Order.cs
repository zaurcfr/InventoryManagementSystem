using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public bool IsDelivered { get; set; }
        public Warehouse Warehouse { get; set; }
        public Company Company { get; set; }
    }
}
