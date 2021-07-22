using InventoryManagementSystem.Command;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class HomeViewModel : BaseViewModel
    {
        public Action NavigateToProducts { get; set; }
        public RelayCommand ProductCommand { get; set; }

        public HomeViewModel()
        {
            ProductCommand = new RelayCommand(NavToProduct);
        }

        private void NavToProduct(object obj)
        {
            NavigateToProducts?.Invoke();
        }
    }
}
