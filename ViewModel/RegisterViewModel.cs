using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace BeFit.ViewModel
{
    using BaseClass;
    using BeFit.DAL;
    class RegisterViewModel : ViewModel
    {
        // TODO: Data input control

        public string LoginArg { get; set; }
        public string PasswordArg { get; set; }
        public string SexArg { get; set; }
        public double WeightArg { get; set; }
        public int HeightArg { get; set; }
        public int AgeArg { get; set; }
        public string ActivityArg { get; set; }
        public string TargetArg { get; set; }

        private ICommand _register;
        public ICommand Register => _register ?? (_register = new RelayCommand((p) => { test(); }, p => true));

        private void RegisterShowMB()
        {
            MessageBox.Show("Pomyślnie zarejestrowano.");
        }
        private void test()
        {
            RegisterSystem.register(LoginArg, PasswordArg, SexArg, WeightArg, HeightArg, AgeArg, ActivityArg, TargetArg);
        } 
    }
}
