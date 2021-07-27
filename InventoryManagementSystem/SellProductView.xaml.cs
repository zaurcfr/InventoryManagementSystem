using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryManagementSystem
{
    /// <summary>
    /// Interaction logic for SellProductView.xaml
    /// </summary>
    public partial class SellProductView : UserControl
    {
        public SellProductView()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null)
            {
                PriceSlider.IsEnabled = true;
                PriceSlider.Foreground = Brushes.MidnightBlue;
            }
        }
    }
}
