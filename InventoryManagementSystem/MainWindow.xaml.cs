﻿using InventoryManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (MenuPanel.Visibility == Visibility.Visible) MenuPanel.Visibility = Visibility.Collapsed;
            else MenuPanel.Visibility = Visibility.Visible;
        }
    }
}
