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

namespace BeFit.View
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsView.xaml
    /// </summary>
    using DAL.Entities;
    using ViewModel;
    using View;

    public partial class SettingsView : UserControl
    {


        public SettingsView(User user)
        {
            InitializeComponent();
            DataContext = new SettingsViewModel(user);

            BindingOperations.SetBinding(txtBoxWeight, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(SettingsViewModel.WeightArg)), Source = DataContext });
            BindingOperations.SetBinding(txtBoxHeight, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(SettingsViewModel.HeightArg)), Source = DataContext });
            BindingOperations.SetBinding(txtBoxAge, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(SettingsViewModel.AgeArg)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxSex, ComboBox.ItemsSourceProperty, new Binding() { Path = new PropertyPath(nameof(SettingsViewModel.SexSource)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxAcitivity, ComboBox.ItemsSourceProperty, new Binding() { Path = new PropertyPath(nameof(SettingsViewModel.ActivtySource)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxSex, ComboBox.SelectedItemProperty, new Binding() { Path = new PropertyPath(nameof(SettingsViewModel.SexArg)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxAcitivity, ComboBox.SelectedItemProperty, new Binding() { Path = new PropertyPath(nameof(SettingsViewModel.ActivityArg)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxTarget, ComboBox.SelectedItemProperty, new Binding() { Path = new PropertyPath(nameof(SettingsViewModel.TargetArg)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxTarget, ComboBox.ItemsSourceProperty, new Binding() { Path = new PropertyPath(nameof(SettingsViewModel.TargetSource)), Source = DataContext });
            BindingOperations.SetBinding(btnChange, Button.CommandProperty, new Binding() { Path = new PropertyPath(nameof(SettingsViewModel.EditUserInfo)), Source = DataContext });
            comboBoxAcitivity.SelectedIndex = ((SettingsViewModel)DataContext).SetActivity();
            comboBoxSex.SelectedIndex= ((SettingsViewModel)DataContext).SetSex();
            comboBoxTarget.SelectedIndex = ((SettingsViewModel)DataContext).SetTarget();
        }

    }
}
