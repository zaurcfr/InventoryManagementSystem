using InventoryManagementSystem.Command;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel : BaseViewModel
    {
        public BaseViewModel CurrentVM { get; set; }

        public HomeViewModel HomeViewModel { get; set; }
        private ProductViewModel _productsViewModel { get; set; }
        private AddProductViewModel _addProductsViewModel { get; set; }
        private OrderViewModel _ordersViewModel { get; set; }
        private AddOrderViewModel _addOrdersViewModel { get; set; }
        private WarehouseViewModel _warehouseViewModel { get; set; }

        public event Action NavigateToProducts;
        public event Action NavigateToOrders;
        public event Action NavigateToWarehouses;
        public RelayCommand NavToProductCommand { get; set; }
        public RelayCommand NavToOrderCommand { get; set; }
        public RelayCommand NavToWarehouseCommand { get; set; }
        public MainViewModel()
        {
            HomeViewModel = new HomeViewModel();
            _productsViewModel = new ProductViewModel();
            _addProductsViewModel = new AddProductViewModel();
            _ordersViewModel = new OrderViewModel();
            _addOrdersViewModel = new AddOrderViewModel();
            _warehouseViewModel = new WarehouseViewModel();

            _productsViewModel.AddProductEvent += NavigateToAddProductView;
            _ordersViewModel.AddOrderEvent += NavigateToAddOrderView;

            NavigateToProducts += NavigateToProductsView;
            NavToProductCommand = new RelayCommand((e) => { NavigateToProducts?.Invoke(); });

            NavigateToOrders += NavigateToOrdersView;
            NavToOrderCommand = new RelayCommand((e) => { NavigateToOrders?.Invoke(); });

            NavigateToWarehouses += NavigateToWarehousesView;
            NavToWarehouseCommand = new RelayCommand((e) => { NavigateToWarehouses?.Invoke(); });
        }

        private void NavigateToWarehousesView()
        {
            CurrentVM = _warehouseViewModel;
        }

        private void NavigateToAddOrderView()
        {
            CurrentVM = _addOrdersViewModel;
        }
        private void NavigateToOrdersView()
        {
            CurrentVM = _ordersViewModel;
        }

        private void NavigateToProductsView()
        {
            CurrentVM = _productsViewModel;
        }
        private void NavigateToAddProductView()
        {
            CurrentVM = _addProductsViewModel;
        }



    }
}
