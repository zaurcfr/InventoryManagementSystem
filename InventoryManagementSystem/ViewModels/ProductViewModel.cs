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
        public event Action SellProductEvent;
        public event Action EditProductEvent;
        public RelayCommand AddProductCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand EditProductCommand { get; set; }
        public RelayCommand SellProductCommand { get; set; }
        ApplicationContext db = new ApplicationContext();
        public ProductViewModel()
        {
            Products = new ObservableCollection<Product>(db.Products.Include(p => p.Company).Include(p => p.Warehouse).Include(p=>p.Category));

            AddProductCommand = new RelayCommand(AddProduct);
            EditProductCommand = new RelayCommand(EditProduct);
            SellProductCommand = new RelayCommand(SellProduct);
            DeleteCommand = new RelayCommand(Delete);
        }

        private void AddProduct(object obj)
        {
            AddProductEvent?.Invoke();
        }
        private void EditProduct(object obj)
        {
            EditProductEvent?.Invoke();
        }
        private void SellProduct(object obj)
        {
            SellProductEvent?.Invoke();
        }

        private void Delete(object obj)
        {
            if (obj is Product product)
            {
                //DeleteProductEvent?.Invoke();
                db.Products.Remove(product);
                Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
}
