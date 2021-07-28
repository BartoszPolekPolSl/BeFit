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
    using System.Security;

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

        public List<String> ActivtySource { get; set; } = new List<String> { Model.Activity.lack.ToString(), Model.Activity.little.ToString(), Model.Activity.medium.ToString(), Model.Activity.high.ToString(), Model.Activity.professionally.ToString() };
        public List<String> TargetSource { get; set; } = new List<String> { Model.Target.lose.ToString(), Model.Target.keep.ToString(), Model.Target.gain.ToString() };
        public List<String> SexSource { get; set; } = new List<String> { Model.Sex.male.ToString(), Model.Sex.female.ToString(), };

        private ICommand _register;
        public ICommand Register => _register ?? (_register = new RelayCommand((p) => {  RegisterSystem.register(LoginArg, PasswordArg, SexArg, WeightArg, HeightArg, AgeArg, ActivityArg, TargetArg); }, p => true));
     
    }
}
