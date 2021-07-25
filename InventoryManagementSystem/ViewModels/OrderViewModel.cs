using InventoryManagementSystem.Command;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace InventoryManagementSystem.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrderViewModel : BaseViewModel
    {
        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
        public Order SelectedOrder { get; set; }
        public RelayCommand AddOrderCommand { get; set; }
        public event Action AddOrderEvent;
        public OrderViewModel()
        {
            using ApplicationContext db = new ApplicationContext();
            Order order1 = new Order
            {
                Name = "PC",
                Price = 1000,
                Quantity = 50,
                IsDelivered = false,
                Category = "Technology",
                Description = "G"
            };
            Order order2 = new Order
            {
                Name = "Phone",
                Price = 1000,
                Quantity = 10,
                IsDelivered = true,
                Category = "Technology",
                Description = "G"
            };
            db.Orders.Add(order1);
            db.Orders.Add(order2);
            foreach (var item in db.Orders.Include(o => o.Company).Include(o => o.Warehouse))
            {
                Orders.Add(item);
            }
            //db.SaveChanges();

            AddOrderCommand = new RelayCommand(AddOrder);
        }

        private void AddOrder(object obj)
        {
            AddOrderEvent?.Invoke();
        }
    }
}
