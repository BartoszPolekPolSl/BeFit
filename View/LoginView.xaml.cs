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
    /// Logika interakcji dla klasy LoginControl.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public delegate void ChangeToRegister();
        public event ChangeToRegister changeToRegisterView;
        public LoginView()
        {
            InitializeComponent();
            BindingOperations.SetBinding(textBoxLogin, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(LoginViewModel.LoginArg)), Source=DataContext });
            BindingOperations.SetBinding(textBoxPassword, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(LoginViewModel.PasswordArg)), Source = DataContext });
            BindingOperations.SetBinding(LoginButton, Button.CommandProperty, new Binding() { Path = new PropertyPath(nameof(LoginViewModel.Login)), Source = DataContext });
        }
       
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            changeToRegisterView.Invoke();
        }
    }
}
