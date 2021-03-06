using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace BeFit.ViewModel
{
    using Model;
    using BaseClass;
    using BeFit.DAL;
    using System.Security;
    using System.Windows.Controls;

    class RegisterViewModel : ViewModel
    {
        // TODO: Data input control

        public string LoginArg { get; set; }
        public SecureString PasswordArg {private get; set; }
        public string SexArg { get; set; }
        public double WeightArg { get; set; }
        public int HeightArg { get; set; }
        public int AgeArg { get; set; }
        public string ActivityArg { get; set; }
        public string TargetArg { get; set; }

        public List<String> ActivtySource { get; set; } = new List<String> { "Brak aktywności, praca siedząca", "Niska aktywność (praca siedząca i 1-2 treningi w tygodniu)", "Średnia aktywność (praca siedząca i treningi 3-4 razy w tygodniu)", "Wysoka aktywność (praca fizyczna i 3-4 treningi w tygodniu)", "Zawodowi sportowcy"};
        public List<String> TargetSource { get; set; } = new List<String> { "Chcę schudnąć", "Chcę utrzymać wagę", "Chcę nabrać masy" };
        public List<String> SexSource { get; set; } = new List<String> { "Kobieta", "Mężczyzna" };

        private ICommand _register;
        public ICommand Register => _register ?? (_register = new RelayCommand((p) => { register(); }, p => checkIfLoginAndPasswordIsNotEmpty()));

        private ICommand _checkIfTextBoxHasInt;
        public ICommand CheckIfTextBoxHasInt => _checkIfTextBoxHasInt ?? (_checkIfTextBoxHasInt = new RelayCommand((p) => { textBoxIntOnly(p); }, p => true));

        private ICommand _checkIfTextBoxHasDouble;
        public ICommand CheckIfTextBoxHasDouble => _checkIfTextBoxHasDouble ?? (_checkIfTextBoxHasDouble = new RelayCommand((p) => { textBoxDoubleOnly(p); }, p => true));

        private ICommand _textBoxLostFocus;
        public ICommand TextBoxLostFocus => _textBoxLostFocus ?? (_textBoxLostFocus = new RelayCommand((p) => { lostFocus(p); }, p => true));

        private void register()
        {
            if(!RegisterSystem.register(LoginArg, PasswordArg, TranslateEnums.TranslteSex(SexArg), WeightArg, HeightArg, AgeArg, TranslateEnums.TranslteActivity(ActivityArg), TranslateEnums.TranslteTarget(TargetArg)))
            {
                MessageBox.Show("Nazwa użytkownika jest już zajęta", "Uwaga!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Pomyślnie zarejestrowano!","", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void textBoxDoubleOnly(Object obj)
        {
            var textBox = (TextBox)obj;
            if (textBox.Text != "")
            {
                char lastChar = textBox.Text.Last<char>();
                if (!char.IsDigit(lastChar) && lastChar != '.')
                {
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
                }
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void textBoxIntOnly(Object obj)
        {
            var textBox = (TextBox)obj;
            if (textBox.Text != "")
            {
                char lastChar = textBox.Text.Last<char>();
                if (!char.IsDigit(lastChar))
                {
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
                }
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private bool checkIfLoginAndPasswordIsNotEmpty()
        {
            if(LoginArg==null || PasswordArg == null || LoginArg=="" || PasswordArg.Length==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void lostFocus(Object obj)
        {
            var textBox = (TextBox)obj;
            if (textBox.Text == "" || string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = 0.ToString();
                textBox.SelectionStart = textBox.Text.Length;
            }
        }
    }
}
