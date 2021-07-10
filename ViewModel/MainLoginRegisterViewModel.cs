using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.ViewModel
{
    using BaseClass;
    class MainLoginRegisterViewModel : ViewModel
    {
        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set { currentView = value;
                OnPropertyChange();
            }
        }


        public LoginViewModel LoginVM { get; set; }

        public MainLoginRegisterViewModel()
        {
            LoginVM = new LoginViewModel();
            CurrentView = LoginVM;
        }
    }
}
