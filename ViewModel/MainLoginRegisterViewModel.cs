using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.ViewModel
{
    using BaseClass;
    using BeFit.View;
    using System.Windows.Input;

    class MainLoginRegisterViewModel : ViewModel
    {
        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyChange(nameof(CurrentView));
            }
        }
        public RegisterView RegisterV { get; set; }
        public LoginView LoginV { get; set; }

        public MainLoginRegisterViewModel()
        {        
            LoginV = new LoginView();
            LoginV.changeToRegisterView += changeToRegisterView;
            RegisterV = new RegisterView();
            RegisterV.changeToLoginView += changeToLoginView;
            CurrentView = LoginV;

        }
        private void changeToRegisterView()
        {
            CurrentView = RegisterV;
        }
        private void changeToLoginView()
        {
            CurrentView = LoginV;
        }
    }
        
}
