using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeFit.Model;
using BeFit.DAL.Entities;

namespace BeFit.ViewModel
{
    class MainViewModel
    {
        public MainLoginRegisterViewModel MainLoginRegisterVM { get; set; }
        public MainViewModel()
        {
            MainLoginRegisterVM = new MainLoginRegisterViewModel();
        }
    }
}
