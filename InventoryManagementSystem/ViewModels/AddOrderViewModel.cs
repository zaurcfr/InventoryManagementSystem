using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace InventoryManagementSystem.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class AddOrderViewModel : BaseViewModel
    {
        public ObservableCollection<Warehouse> Warehouses { get; set; } = new ObservableCollection<Warehouse>();
        public Order Order { get; set; }

        public AddOrderViewModel()
        {
            using ApplicationContext db = new ApplicationContext();
            foreach (var item in db.Warehouses)
            {
                Warehouses.Add(item);
            }
        }
    }
}
