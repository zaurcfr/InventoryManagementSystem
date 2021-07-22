using InventoryManagementSystem.Command;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class AddProductViewModel : BaseViewModel
    {
        public Product Product { get; set; }

        public RelayCommand AddCommand { get; set; }
        public AddProductViewModel()
        {
            using ApplicationContext db = new ApplicationContext();
            AddCommand = new RelayCommand((e) =>
              {
                  db.Products.Add(Product);
              });
        }

    }
}
