using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeFit.ViewModel
{
    using BaseClass;
    using DAL.Entities;
    using Model;
    using System.Collections.ObjectModel;

    class BeFitViewModel : ViewModel
    {
        private Model model;
        public User user { get; set; }
        public ObservableCollection<EatenProduct> EatenProducts { get; set; }
        public BeFitViewModel(User user)
        {
            this.user = user;
            this.model = new Model(user);
            EatenProducts = model.EatenProducts;
        }
    }


}
