using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.Model
{
    static class TranslateEnums
    {
        static public string TranslteActivity(string activity)
        {
            if (activity == "Wysoka aktywność (praca fizyczna i 3-4 treningi w tygodniu)")
            {
                return Activity.high.ToString();
            }
            else if(activity == "Brak aktywności, praca siedząca")
            {
                return Activity.lack.ToString();
            }
            else if(activity == "Średnia aktywność (praca siedząca i treningi 3-4 razy w tygodniu)" )
            {
                return Activity.medium.ToString();
            }
            else if(activity == "Niska aktywność (praca siedząca i 1-2 treningi w tygodniu)" )
            {
                return Activity.little.ToString();
            }
            else
            {
                return Activity.professionally.ToString();
            }
        }

        static public string TranslteTarget(string target)
        {
            if (target == "Chcę nabrać masy" )
            {
                return Target.gain.ToString();
            }
            else if(target == "Chcę utrzymać wagę")
            {
                return Target.keep.ToString();
            }
            else
            {
                return Target.lose.ToString();
            }
        }

        static public string TranslteSex(string sex)
        {
            if (sex == "Kobieta")
            {
                return Sex.female.ToString();
            }
            else
            {
                return Sex.male.ToString();
            }
        }
    }
}
