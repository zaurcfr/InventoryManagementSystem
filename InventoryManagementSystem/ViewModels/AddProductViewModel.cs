using InventoryManagementSystem.Command;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace InventoryManagementSystem.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class AddProductViewModel : BaseViewModel
    {
        public Product Product { get; set; }
        public ObservableCollection<Warehouse> Warehouses { get; set; } = new ObservableCollection<Warehouse>();

        public RelayCommand AddCommand { get; set; }
        public AddProductViewModel()
        {
            using ApplicationContext db = new ApplicationContext();
            foreach (var item in db.Warehouses) Warehouses.Add(item);

            AddCommand = new RelayCommand((e) =>
              {
                  db.Products.Add(Product);
                  db.SaveChanges();
              });
        }

    }
}
