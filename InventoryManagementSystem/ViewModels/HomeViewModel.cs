using InventoryManagementSystem.Command;
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
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> MostUsedProducts { get; set; }
        public Company Company { get; set; }
        public int TotalProductsCount { get; set; }
        public double TotalProductsPrice { get; set; }
        public ApplicationContext db { get; set; } = new ApplicationContext();
        public HomeViewModel()
        {
            Categories = new ObservableCollection<Category>(db.Categories);
            MostUsedProducts = new ObservableCollection<Product>(db.Products.OrderByDescending(p => p.Quantity).Take(10));
            foreach (var item in db.Products)
            {
                TotalProductsCount += item.Quantity;
                TotalProductsPrice += item.Price;
            }
            Company = db.Companies.Find(1);
        }
    }
}
