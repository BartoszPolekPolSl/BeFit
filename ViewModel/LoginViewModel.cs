﻿using System;
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

    class LoginViewModel : ViewModel
    {
        // TODO: Data input control

        public string LoginArg { get; set; }
 
        public string PasswordArg { get; set; }
 
        private ICommand _login;
        public ICommand Login => _login ?? (_login = new RelayCommand((p) => { LoginSystem.Login(LoginArg, PasswordArg); }, p => true));

    }

    

}
