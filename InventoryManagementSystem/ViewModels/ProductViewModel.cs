using InventoryManagementSystem.Command;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace InventoryManagementSystem.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProductViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }

        public event Action AddProductEvent;
        public RelayCommand AddProductCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        public ProductViewModel()
        {
            using ApplicationContext db = new ApplicationContext();
            
            Products = new ObservableCollection<Product>(db.Products.Include(p => p.Company).Include(p => p.Warehouse));
            //db.SaveChanges();

            AddProductCommand = new RelayCommand(AddProduct);
            DeleteCommand = new RelayCommand(Delete);
        }

        private void AddProduct(object obj)
        {
            AddProductEvent?.Invoke();
        }

        private void Delete(object obj)
        {
            if (obj is Product product)
            {
                using ApplicationContext db = new ApplicationContext();
                db.Products.Remove(product);
                Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
}
