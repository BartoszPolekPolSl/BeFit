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
        public ChangeToRegister changeToRegisterView;
        public LoginView()
        {
            InitializeComponent();
            BindingOperations.SetBinding(textBoxLogin, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(LoginViewModel.LoginArg)), Source=DataContext });
            BindingOperations.SetBinding(textBoxPassword, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(LoginViewModel.PasswordArg)), Source = DataContext });
            BindingOperations.SetBinding(LoginButton, Button.CommandProperty, new Binding() { Path = new PropertyPath(nameof(LoginViewModel.Login)), Source = DataContext });
        }
        //public static readonly DependencyProperty LoginButtonProp =
        //    DependencyProperty.Register(
        //            nameof(Login),
        //            typeof(ICommand),
        //            typeof(LoginView)
        //        );
        //public ICommand Login
        //{
        //    get { return (ICommand)GetValue(LoginButtonProp); }
        //    set
        //    {
        //        SetValue(LoginButtonProp, value);
        //    }
        //}
        //public static readonly DependencyProperty RegisterButtonProp =
        //    DependencyProperty.Register(
        //            nameof(Register),
        //            typeof(ICommand),
        //            typeof(LoginView)
        //        );
        //public ICommand Register
        //{
        //    get { return (ICommand)GetValue(RegisterButtonProp); }
        //    set
        //    {
        //        SetValue(RegisterButtonProp, value);
        //    }
        //}

        //public static readonly DependencyProperty LoginArgProp =
        //    DependencyProperty.Register(
        //            nameof(LoginArg),
        //            typeof(string),
        //            typeof(LoginView)
        //        );
        //public string LoginArg
        //{
        //    get { return (string)GetValue(LoginArgProp); }
        //    set
        //    {
        //        SetValue(LoginArgProp, value);
        //    }
        //}

        //public static readonly DependencyProperty PasswordArgProp =
        //    DependencyProperty.Register(
        //            nameof(PasswordArg),
        //            typeof(string),
        //            typeof(LoginView)
        //        );
        //public string PasswordArg
        //{
        //    get { return (string)GetValue(PasswordArgProp); }
        //    set
        //    {
        //        SetValue(PasswordArgProp, value);
        //    }
        //}

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            changeToRegisterView.Invoke();
        }
    }
}
