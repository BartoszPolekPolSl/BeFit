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
    /// Logika interakcji dla klasy AddProductView.xaml
    /// </summary>
    using ViewModel;
    using Model;
    public partial class AddProductView : UserControl
    {
        public AddProductView(BeFitViewModel befitVM)
        {
            InitializeComponent();
            DataContext = befitVM;
            BindingOperations.SetBinding(txtBoxName, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.CurrentProductName)), Source = DataContext });
            BindingOperations.SetBinding(txtBoxProteins, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.CurrentProteins)), Source = DataContext });
            BindingOperations.SetBinding(txtBoxFats, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.CurrentFats)), Source = DataContext });
            BindingOperations.SetBinding(txtBoxCarbohydrates, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.CurrentCarbohydrates)), Source = DataContext });
            BindingOperations.SetBinding(txtBoxKcal, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.CurrentKcal)), Source = DataContext });
            BindingOperations.SetBinding(txtBoxWeight, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.CurrentWeight)), Source = DataContext });
            BindingOperations.SetBinding(btnAddEatenProduct, Button.CommandProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.Add)), Source = DataContext });
            BindingOperations.SetBinding(btnRemoveEatenProduct, Button.CommandProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.Remove)), Source = DataContext });
            BindingOperations.SetBinding(btnEdit, Button.CommandProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.Edit)), Source = DataContext});
        }
    }
}
