using InventoryManagementSystem.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class AddOrderViewModel : BaseViewModel
    {
        public Order Order { get; set; }
    }
}
