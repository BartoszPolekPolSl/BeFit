using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.ViewModel
{
    using BeFit.DAL;
    using BeFit.DAL.Entities;
    using BeFit.ViewModel.BaseClass;
    using System.Windows.Input;

    class SettingsViewModel
    {
        User user;

        public string SexArg { get; set; }
        public double WeightArg { get; set; }
        public int HeightArg { get; set; }
        public int AgeArg { get; set; }
        public string ActivityArg { get; set; }
        public string TargetArg { get; set; }

        public SettingsViewModel(User user)
        {
            this.user = user;
        }

        public List<String> ActivtySource { get; set; } = new List<String> { Model.Activity.lack.ToString(), Model.Activity.little.ToString(), Model.Activity.medium.ToString(), Model.Activity.high.ToString(), Model.Activity.professionally.ToString() };

        private ICommand _editUserInfo;
        public ICommand EditUserInfo => _editUserInfo ?? (_editUserInfo = new RelayCommand((p) => { UserInfoSystem.EditUserInfoDB(user.Id, SexArg, WeightArg, HeightArg, AgeArg, ActivityArg, TargetArg); }, p => true));
    }
}
