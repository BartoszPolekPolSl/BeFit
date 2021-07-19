using BeFit.ViewModel;
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
    /// Logika interakcji dla klasy RegisterControl.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        public delegate void ChangeToLogin();
        public event ChangeToLogin changeToLoginView;
        public RegisterView()
        {
            InitializeComponent();
            BindingOperations.SetBinding(textBoxLogin, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.LoginArg)), Source = DataContext });
            BindingOperations.SetBinding(textBoxPassword, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.PasswordArg)), Source = DataContext });
            BindingOperations.SetBinding(textBoxAge, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.AgeArg)), Source = DataContext });
            BindingOperations.SetBinding(textBoxHeight, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.HeightArg)), Source = DataContext });
            BindingOperations.SetBinding(textBoxWeight, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.WeightArg)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxTarget, ComboBox.ItemsSourceProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.TargetSource)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxSex, ComboBox.ItemsSourceProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.SexSource)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxActivity, ComboBox.ItemsSourceProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.ActivtySource)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxTarget, ComboBox.SelectedItemProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.TargetArg)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxActivity, ComboBox.SelectedItemProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.ActivityArg)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxSex, ComboBox.SelectedItemProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.SexArg)), Source = DataContext });
            BindingOperations.SetBinding(RegisterButton, Button.CommandProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.Register)), Source = DataContext });

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            changeToLoginView.Invoke();
        }
    }
}
