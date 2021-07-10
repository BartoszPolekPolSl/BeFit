using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.ViewModel
{
    using Model.UserInfo;
    using DAL.Entities;

    class MainViewModel
    {
        public MainLoginRegisterViewModel MainLoginRegisterVM { get; set; }
        public MainViewModel()
        {
            MainLoginRegisterVM = new MainLoginRegisterViewModel();
        }
    }
}
