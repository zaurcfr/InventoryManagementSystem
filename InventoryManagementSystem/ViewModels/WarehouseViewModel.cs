using InventoryManagementSystem.Command;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WarehouseViewModel : BaseViewModel
    {
        public ObservableCollection<Warehouse> Warehouses { get; set; }
        public Warehouse Warehouse { get; set; }
        public ApplicationContext db { get; set; } = new ApplicationContext();
        public RelayCommand SelectCommand { get; set; }
        public int TotalCountOfProducts { get; set; }
        public double TotalPriceOfProducts { get; set; }
        public int TotalCountOfOrders { get; set; }
        public double TotalPriceOfOrders { get; set; }
        public Company Company { get; set; }

        public WarehouseViewModel()
        {
            Warehouses = new ObservableCollection<Warehouse>(db.Warehouses.Include(w=>w.Company));
            SelectCommand = new RelayCommand(Select);

        }

        private void Select(object obj)
        {
            Company = Warehouse.Company;
            foreach (var item in db.Products)
            {
                if (item.Warehouse == Warehouse)
                {
                    TotalCountOfProducts += item.Quantity;
                    TotalPriceOfProducts += item.Price*item.Quantity;
                }
            }
            foreach (var item in db.Orders)
            {
                if (item.Warehouse == Warehouse)
                {
                    TotalCountOfOrders += item.Quantity;
                    TotalPriceOfOrders += item.Price;
                }
            }
        }

    }
}
