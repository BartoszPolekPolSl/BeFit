using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.Model
{
    using DAL.Entities;
    using DAL.Repositories;
    class Model
    {
        public ObservableCollection<Product> EatenProducts { get; set; } = new ObservableCollection<Product>();
    }
}
