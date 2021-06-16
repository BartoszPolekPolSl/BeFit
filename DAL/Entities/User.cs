using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.Model
{
    class User
    {
        int Id { get; set; }
        string UserName { get; set; }
        ProductsList productList;
    }
}
