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
        public RegisterView()
        {
            InitializeComponent();
        }
        public List<String> ActivtySource { get; set; } = new List<String> { Model.UserInfo.Activity.little.ToString(), Model.UserInfo.Activity.medium.ToString(), Model.UserInfo.Activity.high.ToString() };
        public List<String> TargetSource { get; set; } = new List<String> { Model.UserInfo.Target.lose.ToString(), Model.UserInfo.Target.keep.ToString(), Model.UserInfo.Target.gain.ToString() };
        public static readonly DependencyProperty RegisterButtonProp =
           DependencyProperty.Register(
                   nameof(Register),
                   typeof(ICommand),
                   typeof(RegisterView)
               );
        public ICommand Register
        {
            get { return (ICommand)GetValue(RegisterButtonProp); }
            set
            {
                SetValue(RegisterButtonProp, value);
            }
        }
        public static readonly DependencyProperty LoginArgProp =
                   DependencyProperty.Register(
                           nameof(LoginArg),
                           typeof(string),
                           typeof(RegisterView)
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
                    typeof(RegisterView)
                );
        public string PasswordArg
        {
            get { return (string)GetValue(PasswordArgProp); }
            set
            {
                SetValue(PasswordArgProp, value);
            }
        }
        public static readonly DependencyProperty WeightArgProp =
           DependencyProperty.Register(
                   nameof(WeightArg),
                   typeof(double),
                   typeof(RegisterView)
               );
        public double WeightArg
        {
            get { return (double)GetValue(WeightArgProp); }
            set
            {
                SetValue(WeightArgProp, value);
            }
        }
        public static readonly DependencyProperty SexArgProp =
            DependencyProperty.Register(
                    nameof(SexArg),
                    typeof(string),
                    typeof(RegisterView)
                );
        public string SexArg
        {
            get { return (string)GetValue(SexArgProp); }
            set
            {
                SetValue(SexArgProp, value);
            }
        }

        public static readonly DependencyProperty HeightArgProp =
      DependencyProperty.Register(
              nameof(HeightArg),
              typeof(int),
              typeof(RegisterView)
          );
        public int HeightArg
        {
            get { return (int)GetValue(HeightArgProp); }
            set
            {
                SetValue(HeightArgProp, value);
            }
        }

        public static readonly DependencyProperty AgeArgProp =
      DependencyProperty.Register(
              nameof(AgeArg),
              typeof(int),
              typeof(RegisterView)
          );
        public int AgeArg
        {
            get { return (int)GetValue(AgeArgProp); }
            set
            {
                SetValue(AgeArgProp, value);
            }
        }

        public static readonly DependencyProperty ActivityArgProp =
           DependencyProperty.Register(
                   nameof(ActivityArg),
                   typeof(string),
                   typeof(RegisterView)
               );
        public string ActivityArg
        {
            get { return (string)GetValue(ActivityArgProp); }
            set
            {
                SetValue(ActivityArgProp, value);
            }
        }
        public static readonly DependencyProperty TargetArgProp =
            DependencyProperty.Register(
                nameof(TargetArg),
                typeof(string),
                typeof(RegisterView)
        );
        public string TargetArg
        {
            get { return (string)GetValue(TargetArgProp); }
            set
            {
                SetValue(TargetArgProp, value);
            }
        }






        private void WhichActivityChecked(object sender, RoutedEventArgs e)
        {
            ActivityArg = (sender as ComboBox).SelectedItem.ToString();
        }
        private void WhichTargetChecked(object sender, RoutedEventArgs e)
        {
            TargetArg = (sender as ComboBox).SelectedItem.ToString();
        }
        private void WhichSexChecked(object sender, RoutedEventArgs e)
        {
            SexArg = (sender as RadioButton).Tag.ToString();
        }

    }
}
