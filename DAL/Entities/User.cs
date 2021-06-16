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
        string Sex { get; set; }
        double Weight { get; set; }
        int Height { get; set; }
        int Age { get; set; }
        string Activity { get; set; }
        string Target { get; set; }
    }
}
