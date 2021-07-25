using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagementSystem.Models;
using PropertyChanged;

namespace InventoryManagementSystem.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SelectedWarehouseViewModel : BaseViewModel
    {
        public Warehouse Warehouse { get; set; }
    }
}
