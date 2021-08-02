using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.ViewModel
{
    using Model;
    using BeFit.DAL;
    using BeFit.DAL.Entities;
    using BeFit.ViewModel.BaseClass;
    using System.Windows.Controls;
    using System.Windows.Input;

    class SettingsViewModel
    {
        public delegate void UpdateUserInfoDelegate(string sex, double weight, int height, int age, string adctivity, string target);
        public event UpdateUserInfoDelegate UpdateUserInfo;


        public string SexArg { get; set; }
        public double WeightArg { get; set; }
        public int HeightArg { get; set; }
        public int AgeArg { get; set; }
        public string ActivityArg { get; set; }
        public string TargetArg { get; set; }

        private User user;

        public SettingsViewModel(User user)
        {
            this.user = user;
            SexArg = user.Sex;
            WeightArg = user.Weight;
            AgeArg = user.Age;
            HeightArg = user.Height;
            ActivityArg = user.Activity;
            TargetArg = user.Target;
        }

        public List<String> ActivtySource { get; set; } = new List<String> { "Brak aktywności, praca siedząca", "Niska aktywność (praca siedząca i 1-2 treningi w tygodniu)", "Średnia aktywność (praca siedząca i treningi 3-4 razy w tygodniu)", "Wysoka aktywność (praca fizyczna i 3-4 treningi w tygodniu)", "Zawodowi sportowcy" };
        public List<String> TargetSource { get; set; } = new List<String> { "Chcę schudnąć", "Chcę utrzymać wagę", "Chcę nabrać masy" };
        public List<String> SexSource { get; set; } = new List<String> { "Mężczyzna","Kobieta"};

        private ICommand _editUserInfo;
        public ICommand EditUserInfo => _editUserInfo ?? (_editUserInfo = new RelayCommand((p) => { editUserInfo(); }, p => true));

        private ICommand _checkedTargetRadioBtn;
        public ICommand CheckedTargetRadioBtn => _checkedTargetRadioBtn ?? (_checkedTargetRadioBtn = new RelayCommand((p) => { whichTargetRadioBtnChecked(p); }, p => true));


        private ICommand _textBoxLostFocus;
        public ICommand TextBoxLostFocus => _textBoxLostFocus ?? (_textBoxLostFocus = new RelayCommand((p) => { lostFocus(p); }, p => true));

        private ICommand _checkIfTextBoxHasInt;
        public ICommand CheckIfTextBoxHasInt => _checkIfTextBoxHasInt ?? (_checkIfTextBoxHasInt = new RelayCommand((p) => { textBoxIntOnly(p); }, p => true));

        private ICommand _checkIfTextBoxHasDouble;
        public ICommand CheckIfTextBoxHasDouble => _checkIfTextBoxHasDouble ?? (_checkIfTextBoxHasDouble = new RelayCommand((p) => { textBoxDoubleOnly(p); }, p => true));

        public int SetTarget()
        {
            if (TargetArg == Target.keep.ToString())
            {
                return 1;
            }
            else if(TargetArg == Target.lose.ToString())
            {
                return 0;
            }
            else
            {
                return 2;
            }
        }

        public int SetSex()
        {
            if (SexArg == Sex.male.ToString())
            {
                return (int)Sex.male;
            }
            else { return (int)Sex.female; }
        }
        public int SetActivity()
        {
            if (ActivityArg == Activity.lack.ToString())
            {
                return (int)Activity.lack;
            }
            else if(ActivityArg == Activity.little.ToString())
            {
                return (int)Activity.little;
            }
            else if (ActivityArg == Activity.medium.ToString())
            {
                return (int)Activity.medium;
            }
            else if (ActivityArg == Activity.high.ToString())
            {
                return (int)Activity.high;
            }
            else
            {
                return (int)Activity.professionally;
            }
        }

        private void editUserInfo()
        {
            UserInfoSystem.EditUserInfoDB(user.Id, TranslateEnums.TranslteSex(SexArg), WeightArg, HeightArg, AgeArg, TranslateEnums.TranslteActivity(ActivityArg), TranslateEnums.TranslteTarget(TargetArg));
            UpdateUserInfo.Invoke(TranslateEnums.TranslteSex(SexArg), WeightArg, HeightArg, AgeArg, TranslateEnums.TranslteActivity(ActivityArg), TranslateEnums.TranslteTarget(TargetArg));
        }

        private void whichTargetRadioBtnChecked(object obj)
        {
            string target = (string)obj;
            if (target == "Chcę schudnąć")
            {
                TargetArg = "Chcę schudnąć";
            }
            else if (target == "Chcę utrzymać wagę")
            {
                TargetArg = "Chcę utrzymać wagę";
            }
            else
            {
                TargetArg = "Chcę utrzymać wagę";
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

    }
}
