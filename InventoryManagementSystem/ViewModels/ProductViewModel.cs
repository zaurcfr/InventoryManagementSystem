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
    public class ProductViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public Product SelectedProduct { get; set; }

        public event Action AddProductEvent;
        public RelayCommand AddProductCommand { get; set; }

        public ProductViewModel()
        {

            using ApplicationContext db = new ApplicationContext();
            Product product1 = new Product
            {
                Name = "PC",
                Status = "Active",
                Price = 1000,
                Quantity = 50,
                Category = "Technology",
                Description = "G"
            };
            Product product2 = new Product
            {
                Name = "Phone",
                Status = "Active",
                Price = 1500,
                Quantity = 10,
                Category = "Technology",
                Description = "A"
            };
            db.Products.Add(product1);
            db.Products.Add(product2);
            foreach (var item in db.Products)
            {
                Products.Add(item);
            }
            //db.SaveChanges();


            AddProductCommand = new RelayCommand(AddProduct);
        }

        private void AddProduct(object obj)
        {
            AddProductEvent?.Invoke();
        }
    }
}
