using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using InventoryManagementSystem.Command;
using System.Windows;

namespace InventoryManagementSystem.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class AddOrderViewModel : BaseViewModel
    {
        public Order Order { get; set; } = new Order();
        public ObservableCollection<Warehouse> Warehouses { get; set; } = new ObservableCollection<Warehouse>();
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
        public Warehouse Warehouse { get; set; }
        public Category Category { get; set; }
        public ApplicationContext db { get; set; } = new ApplicationContext();
        public RelayCommand AddCommand { get; set; }
        public AddOrderViewModel()
        {
            Warehouses = new ObservableCollection<Warehouse>(db.Warehouses);
            Categories = new ObservableCollection<Category>(db.Categories);

            AddCommand = new RelayCommand(Add);
        }
        private void Add(object obj)
        {
            Order.Warehouse = Warehouse;
            Order.Category = Category;
            var company = db.Companies.Find(1);
            Order.Company = company;
            db.Orders.Add(Order);
            db.SaveChanges();
            MessageBox.Show("Order added succesfully!");
        }

    }
}
