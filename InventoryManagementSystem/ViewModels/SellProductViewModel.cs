using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using InventoryManagementSystem.Command;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using PropertyChanged;

namespace InventoryManagementSystem.ViewModels
{
    public class SellProductViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }
        public Product Product { get; set; } = new Product();
        public ApplicationContext db { get; set; } = new ApplicationContext();
        public float Price { get; set; }
        public double MaximumPrice { get; set; }
        public double MinimumPrice { get; set; }
        public RelayCommand SelectCommand { get; set; }
        public RelayCommand SellCommand { get; set; }
        public SellProductViewModel()
        {
            Products = new ObservableCollection<Product>(db.Products);

            SelectCommand = new RelayCommand(Select);
            SellCommand = new RelayCommand(Sell);
        }

        private void Select(object obj)
        {
            MinimumPrice = Product.Price / 2;
            MaximumPrice = Product.Price * 2;
        }

        private void Sell(object obj)
        {
            db.Products.Remove(Product);
            db.Companies.Find(1).Budget += Price;
            db.SaveChanges();
            MessageBox.Show("Product sold!");
        }
    }
}
