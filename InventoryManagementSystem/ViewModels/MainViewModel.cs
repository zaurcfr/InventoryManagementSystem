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

        private HomeViewModel _homeViewModel { get; set; }
        private ProductViewModel _productsViewModel { get; set; }
        private AddProductViewModel _addProductsViewModel { get; set; }
        private OrderViewModel _ordersViewModel { get; set; }
        private AddOrderViewModel _addOrdersViewModel { get; set; }
        private WarehouseViewModel _warehouseViewModel { get; set; }
        private DeleteDialogViewModel _deleteDialogViewModel { get; set; }
        private EditProductViewModel _editProductViewModel { get; set; }
        private SellProductViewModel _sellProductViewModel { get; set; }
        

        public event Action NavigateToHome;
        public event Action NavigateToProducts;
        public event Action NavigateToOrders;
        public event Action NavigateToWarehouses;
        public RelayCommand NavToHomeCommand { get; set; }
        public RelayCommand NavToProductCommand { get; set; }
        public RelayCommand NavToOrderCommand { get; set; }
        public RelayCommand NavToWarehouseCommand { get; set; }

        public MainViewModel()
        {
            _homeViewModel = new HomeViewModel();
            _productsViewModel = new ProductViewModel();
            _addProductsViewModel = new AddProductViewModel();
            _ordersViewModel = new OrderViewModel();
            _addOrdersViewModel = new AddOrderViewModel();
            _warehouseViewModel = new WarehouseViewModel();
            _deleteDialogViewModel = new DeleteDialogViewModel();
            _editProductViewModel = new EditProductViewModel();
            _sellProductViewModel = new SellProductViewModel();

            _productsViewModel.AddProductEvent += NavigateToAddProductView;
            _productsViewModel.SellProductEvent += NavigateToSellProductView;
            _productsViewModel.EditProductEvent += NavigateToEditProductView;
            
            _ordersViewModel.AddOrderEvent += NavigateToAddOrderView;

            NavigateToHome += NavigateToHomeView;
            NavToHomeCommand = new RelayCommand((e) => { NavigateToHome?.Invoke(); });

            NavigateToProducts += NavigateToProductsView;
            NavToProductCommand = new RelayCommand((e) => { NavigateToProducts?.Invoke(); });

            NavigateToOrders += NavigateToOrdersView;
            NavToOrderCommand = new RelayCommand((e) => { NavigateToOrders?.Invoke(); });

            NavigateToWarehouses += NavigateToWarehousesView;
            NavToWarehouseCommand = new RelayCommand((e) => { NavigateToWarehouses?.Invoke(); });

            CurrentVM = _homeViewModel;
        }

        
        private void NavigateToHomeView()
        {
            CurrentVM = _homeViewModel;
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
        private void NavigateToEditProductView()
        {
            CurrentVM = _editProductViewModel;
        }
        private void NavigateToSellProductView()
        {
            CurrentVM = _sellProductViewModel;
        }



    }
}
