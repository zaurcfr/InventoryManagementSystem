using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using InventoryManagementSystem.Command;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using Microsoft.EntityFrameworkCore;
using PropertyChanged;

namespace InventoryManagementSystem.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class EditProductViewModel : BaseViewModel
    {
        public ApplicationContext db { get; set; } = new ApplicationContext();
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Warehouse> Warehouses { get; set; }
        public Product Product { get; set; }
        public RelayCommand EditCommand { get; set; }
        public EditProductViewModel()
        {
            Products = new ObservableCollection<Product>(db.Products.Include(p => p.Warehouse).Include(p => p.Company));
            Warehouses = new ObservableCollection<Warehouse>(db.Warehouses);
            EditCommand = new RelayCommand(Edit);
        }

        private void Edit(object obj)
        {
            var company = db.Companies.Find(1);
            Product.Company = company;
            db.Products.Update(Product);
            db.SaveChanges();
            MessageBox.Show("Product updated succesfully!");
        }
    }
}
