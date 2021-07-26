using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagementSystem.Command;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using PropertyChanged;

namespace InventoryManagementSystem.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class DeleteDialogViewModel : BaseViewModel
    {
        public double MaximumPrice { get; set; } = 0;
        public double MinimumPrice { get; set; } = 10000;
        public double Price { get; set; } = 0;
        ApplicationContext db;

        public DeleteDialogViewModel()
        {
            
        }

        
    }
}
