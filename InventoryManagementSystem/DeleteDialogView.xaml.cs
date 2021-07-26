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
    /// Interaction logic for DeleteDialogView.xaml
    /// </summary>
    public partial class DeleteDialogView : UserControl
    {
        public DeleteDialogView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PriceSlider.IsEnabled)
            {
                PriceSlider.IsEnabled = false;
                PriceSlider.Foreground = Brushes.Gray;
            }
            else
            {
                PriceSlider.IsEnabled = true;
                PriceSlider.Foreground = Brushes.MidnightBlue;
            }
        }
    }
}
