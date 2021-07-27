using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PropertyChanged;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public partial class App : Application
    {
        public App()
        {

        }

    }
}
