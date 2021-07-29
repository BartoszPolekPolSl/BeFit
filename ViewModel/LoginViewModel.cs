using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;




namespace BeFit.ViewModel
{

    using Model;
    using BaseClass;
    using BeFit.DAL;
    using System.Security;

    class LoginViewModel : ViewModel
    {
        // TODO: Data input control

        public string LoginArg { get; set; }
 
        public SecureString PasswordArg {private get; set; }
 
        private ICommand _login;
        public ICommand Login => _login ?? (_login = new RelayCommand((p) => { LoginSystem.Login(LoginArg, PasswordArg); }, p => true));

    }

    

}
