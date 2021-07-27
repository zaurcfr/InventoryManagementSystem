using InventoryManagementSystem.Command;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Linq;

namespace InventoryManagementSystem.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class AddProductViewModel : BaseViewModel
    {
        public Product Product { get; set; } = new Product();
        public ObservableCollection<Warehouse> Warehouses { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public Warehouse Warehouse { get; set; }
        public Category Category { get; set; }
        public ApplicationContext db { get; set; } = new ApplicationContext();
        public RelayCommand AddCommand { get; set; }
        public AddProductViewModel()
        {
            Warehouses = new ObservableCollection<Warehouse>(db.Warehouses);
            Categories = new ObservableCollection<Category>(db.Categories);
            
            AddCommand = new RelayCommand(Add);
        }

        private void Add(object obj)
        {
            Product.Warehouse = Warehouse;
            Product.Category = Category;
            var company = db.Companies.Find(1);
            Product.Company = company;
            db.Products.Add(Product);
            db.SaveChanges();
            MessageBox.Show("Product added succesfully!");
        }

    }
}
