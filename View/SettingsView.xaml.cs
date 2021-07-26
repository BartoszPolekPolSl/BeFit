﻿using System;
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

namespace BeFit.View
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsView.xaml
    /// </summary>
    using DAL.Entities;
    using ViewModel;
 
    public partial class SettingsView : UserControl
    {
        public SettingsView(User user)
        {
            InitializeComponent();
            DataContext = new SettingsViewModel(user);
            BindingOperations.SetBinding(buttonEdit, Button.CommandProperty, new Binding() { Path = new PropertyPath(nameof(SettingsViewModel.EditUserInfo)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxActivity, ComboBox.ItemsSourceProperty, new Binding() { Path = new PropertyPath(nameof(SettingsViewModel.ActivtySource)), Source = DataContext });
        }
    }
}
