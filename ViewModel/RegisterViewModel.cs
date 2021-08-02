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
        public ICommand Register => _register ?? (_register = new RelayCommand((p) => {  RegisterSystem.register(LoginArg, PasswordArg, TranslateEnums.TranslteSex(SexArg),WeightArg, HeightArg, AgeArg, TranslateEnums.TranslteActivity(ActivityArg), TranslateEnums.TranslteTarget(TargetArg)); }, p => true));

        private ICommand _checkIfTextBoxHasDigit;
        public ICommand CheckIfTextBoxHasDigit => _checkIfTextBoxHasDigit ?? (_checkIfTextBoxHasDigit = new RelayCommand((p) => { textBoxDigitOnly(p); }, p => true));

        private void textBoxDigitOnly(Object obj)
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

    }
}
