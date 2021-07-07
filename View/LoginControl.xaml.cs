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
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty LoginButtonProp =
            DependencyProperty.Register(
                    nameof(Login),
                    typeof(ICommand),
                    typeof(LoginControl)
                );
        public ICommand Login
        {
            get { return (ICommand)GetValue(LoginButtonProp); }
            set
            {
                SetValue(LoginButtonProp, value);
            }
        }

        public static readonly DependencyProperty LoginArgProp =
            DependencyProperty.Register(
                    nameof(LoginArg),
                    typeof(string),
                    typeof(LoginControl)
                );
        public string LoginArg
        {
            get { return (string)GetValue(LoginArgProp); }
            set
            {
                SetValue(LoginArgProp, value);
            }
        }

        public static readonly DependencyProperty PasswordArgProp =
            DependencyProperty.Register(
                    nameof(PasswordArg),
                    typeof(string),
                    typeof(LoginControl)
                );
        public string PasswordArg
        {
            get { return (string)GetValue(PasswordArgProp); }
            set
            {
                SetValue(PasswordArgProp, value);
            }
        }

    }
}
