using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.Model
{
    using DAL.Entities;
    class Calculator
    {
        Model model;
        public Calculator(Model model)
        {
            this.model = model;
        }
        public double GetEatenKcal()
        {
            double sum = 0;
            foreach (EatenProduct product in model.EatenProducts)
            {
                sum += product.EatenKcal;
            }
            return sum;
        }

        public double GetEatenProteins()
        {
            double sum = 0;
            foreach (EatenProduct product in model.EatenProducts)
            {
                sum += product.EatenProteins;
            }
            return sum;
        }

        public double GetEatenCarbohydrates()
        {
            double sum = 0;
            foreach (EatenProduct product in model.EatenProducts)
            {
                sum += product.EatenCarbohydrates;
            }
            return sum;
        }

        public double GetEatenFats()
        {
            double sum = 0;
            foreach (EatenProduct product in model.EatenProducts)
            {
                sum += product.EatenFats;
            }
            return sum;
        }

        public double GetProteinsTarget()
        {
            double target = 0;
            target = Math.Round(GetKcalTarget() * 0.2 / 4, 1);
            return target;
        }

        public double GetCarbohydratesTarget()
        {
            double target = 0;
            target = Math.Round(GetKcalTarget() * 0.5 / 4, 1);
            return target;
        }

        public double GetFatsTarget()
        {
            double target = 0;
            target = Math.Round(GetKcalTarget() * 0.25 / 9, 1);
            return target;
        }

        public double GetKcalTarget()
        {
            double target = 0;
            if (model.User.Sex == Sex.male.ToString())
            {
                target = Math.Round((((9.99 * model.User.Weight) + (6.25 * model.User.Height) - (4.92 * model.User.Age) + 5) * getActivityDoubleValue(model.User.Activity)) + getTargetDoubleValue(model.User.Target), 1);
            }
            else
            {
                target = Math.Round((((9.99 * model.User.Weight) + (6.25 * model.User.Height) - (4.92 * model.User.Age) - 161) * getActivityDoubleValue(model.User.Activity)) + getTargetDoubleValue(model.User.Target), 1);
            }
            return target;
        }



        private double getActivityDoubleValue(string activity)
        {
            if (activity == Activity.brak.ToString())
            {
                return 1.2;
            }
            else if (activity == Activity.mało.ToString())
            {
                return 1.3;
            }
            else if (activity == Activity.średnio.ToString())
            {
                return 1.5;
            }
            else if (activity == Activity.dużo.ToString())
            {
                return 1.7;
            }
            else
            {
                return 2;
            }
        }

        private int getTargetDoubleValue(string target)
        {
            if (target == Target.keep.ToString())
            {
                return 0;
            }
            else if (target == Target.lose.ToString())
            {
                return -200;
            }
            else
            {
                return 200;
            }
        }
    }
}
