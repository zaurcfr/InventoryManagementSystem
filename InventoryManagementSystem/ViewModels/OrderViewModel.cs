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

        public event Action AddOrderEvent;
        public RelayCommand AddOrderCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public OrderViewModel()
        {
            using ApplicationContext db = new ApplicationContext();

            Orders = new ObservableCollection<Order>(db.Orders.Include(o => o.Company).Include(o => o.Warehouse).Include(o => o.Category));

            AddOrderCommand = new RelayCommand(AddOrder);
            DeleteCommand = new RelayCommand(Delete);
        }

        private void AddOrder(object obj)
        {
            AddOrderEvent?.Invoke();
        }

        private void Delete(object obj)
        {
            if (obj is Order order)
            {
                using ApplicationContext db = new ApplicationContext();
                db.Orders.Remove(order);
                Orders.Remove(order);
                db.SaveChanges();
            }
        }
    }
}
