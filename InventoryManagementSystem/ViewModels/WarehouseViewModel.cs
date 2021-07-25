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
    public class WarehouseViewModel : BaseViewModel
    {
        public ObservableCollection<Warehouse> Warehouses { get; set; } = new ObservableCollection<Warehouse>();

        public event Action SelectedWarehouseEvent;
        public RelayCommand NavToSelectedWarehouseCommand { get; set; }

        public WarehouseViewModel()
        {
            //Warehouse warehouse1 = new Warehouse() { Name = "Warehouse1" };
            //Warehouse warehouse2 = new Warehouse() { Name = "Warehouse2" };
            //Warehouses.Add(warehouse1);
            //Warehouses.Add(warehouse2);
            using ApplicationContext db = new ApplicationContext();
            foreach (var item in db.Warehouses)
            {
                Warehouses.Add(item);
            }

            NavToSelectedWarehouseCommand = new RelayCommand(SelectedWarehouse);
        }

        private void SelectedWarehouse(object obj)
        {
            SelectedWarehouseEvent?.Invoke();
        }
    }
}
