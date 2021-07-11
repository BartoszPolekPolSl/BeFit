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
        public ChangeToLogin changeToLoginView;
        public RegisterView()
        {
            InitializeComponent();
            BindingOperations.SetBinding(textBoxLogin, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.LoginArg)), Source = DataContext });
            BindingOperations.SetBinding(textBoxPassword, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.PasswordArg)), Source = DataContext });
            BindingOperations.SetBinding(textBoxAge, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.AgeArg)), Source = DataContext });
            BindingOperations.SetBinding(textBoxHeight, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.HeightArg)), Source = DataContext });
            BindingOperations.SetBinding(textBoxWeight, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.WeightArg)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxTarget, ComboBox.SelectedItemProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.TargetArg)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxActivity, ComboBox.SelectedItemProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.ActivityArg)), Source = DataContext });
            BindingOperations.SetBinding(comboBoxSex, ComboBox.SelectedItemProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.SexArg)), Source = DataContext });
            BindingOperations.SetBinding(RegisterButton, Button.CommandProperty, new Binding() { Path = new PropertyPath(nameof(RegisterViewModel.Register)), Source = DataContext });

        }
        public List<String> ActivtySource { get; set; } = new List<String> { Model.Activity.little.ToString(), Model.Activity.medium.ToString(), Model.Activity.high.ToString() };
        public List<String> TargetSource { get; set; } = new List<String> { Model.Target.lose.ToString(), Model.Target.keep.ToString(), Model.Target.gain.ToString() };
        public List<String> SexSource { get; set; } = new List<String> { Model.Sex.male.ToString(), Model.Sex.female.ToString(), };
        //  public static readonly DependencyProperty RegisterButtonProp =
        //     DependencyProperty.Register(
        //             nameof(Register),
        //             typeof(ICommand),
        //             typeof(RegisterView)
        //         );
        //  public ICommand Register
        //  {
        //      get { return (ICommand)GetValue(RegisterButtonProp); }
        //      set
        //      {
        //          SetValue(RegisterButtonProp, value);
        //      }
        //  }
        //  public static readonly DependencyProperty LoginButtonProp =
        //     DependencyProperty.Register(
        //             nameof(Login),
        //             typeof(ICommand),
        //             typeof(RegisterView)
        //         );
        //  public ICommand Login
        //  {
        //      get { return (ICommand)GetValue(LoginButtonProp); }
        //      set
        //      {
        //          SetValue(LoginButtonProp, value);
        //      }
        //  }
        //  public static readonly DependencyProperty LoginArgProp =
        //             DependencyProperty.Register(
        //                     nameof(LoginArg),
        //                     typeof(string),
        //                     typeof(RegisterView)
        //                 );
        //  public string LoginArg
        //  {
        //      get { return (string)GetValue(LoginArgProp); }
        //      set
        //      {
        //          SetValue(LoginArgProp, value);
        //      }
        //  }
        //  public static readonly DependencyProperty PasswordArgProp =
        //      DependencyProperty.Register(
        //              nameof(PasswordArg),
        //              typeof(string),
        //              typeof(RegisterView)
        //          );
        //  public string PasswordArg
        //  {
        //      get { return (string)GetValue(PasswordArgProp); }
        //      set
        //      {
        //          SetValue(PasswordArgProp, value);
        //      }
        //  }
        //  public static readonly DependencyProperty WeightArgProp =
        //     DependencyProperty.Register(
        //             nameof(WeightArg),
        //             typeof(double),
        //             typeof(RegisterView)
        //         );
        //  public double WeightArg
        //  {
        //      get { return (double)GetValue(WeightArgProp); }
        //      set
        //      {
        //          SetValue(WeightArgProp, value);
        //      }
        //  }
        //public static readonly DependencyProperty SexArgProp =
        //    DependencyProperty.Register(
        //            nameof(SexArg),
        //            typeof(string),
        //            typeof(RegisterView)
        //        );
        //public string SexArg
        //{
        //    get { return (string)GetValue(SexArgProp); }
        //    set
        //    {
        //        SetValue(SexArgProp, value);
        //    }
        //}

        //  public static readonly DependencyProperty HeightArgProp =
        //DependencyProperty.Register(
        //        nameof(HeightArg),
        //        typeof(int),
        //        typeof(RegisterView)
        //    );
        //  public int HeightArg
        //  {
        //      get { return (int)GetValue(HeightArgProp); }
        //      set
        //      {
        //          SetValue(HeightArgProp, value);
        //      }
        //  }

        //  public static readonly DependencyProperty AgeArgProp =
        //DependencyProperty.Register(
        //        nameof(AgeArg),
        //        typeof(int),
        //        typeof(RegisterView)
        //    );
        //  public int AgeArg
        //  {
        //      get { return (int)GetValue(AgeArgProp); }
        //      set
        //      {
        //          SetValue(AgeArgProp, value);
        //      }
        //  }

        //public static readonly DependencyProperty ActivityArgProp =
        //   DependencyProperty.Register(
        //           nameof(ActivityArg),
        //           typeof(string),
        //           typeof(RegisterView)
        //       );
        //public string ActivityArg
        //{
        //    get { return (string)GetValue(ActivityArgProp); }
        //    set
        //    {
        //        SetValue(ActivityArgProp, value);
        //    }
        //}
        //  public static readonly DependencyProperty TargetArgProp =
        //      DependencyProperty.Register(
        //          nameof(TargetArg),
        //          typeof(string),
        //          typeof(RegisterView)
        //  );
        //  public string TargetArg
        //  {
        //      get { return (string)GetValue(TargetArgProp); }
        //      set
        //      {
        //          SetValue(TargetArgProp, value);
        //      }
        //  }






        //private void WhichActivityChecked(object sender, RoutedEventArgs e)
        //{
        //    ActivityArg = (sender as ComboBox).SelectedItem.ToString();
        //}
        //private void WhichTargetChecked(object sender, RoutedEventArgs e)
        //{
        //    TargetArg = (sender as ComboBox).SelectedItem.ToString();
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            changeToLoginView.Invoke();
        }
    }
}
