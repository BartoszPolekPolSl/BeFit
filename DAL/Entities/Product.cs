using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.Model
{
    public class Product
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Carbohydrates { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Kcal { get; set; }
        public Product(string name, double weight, double fats, double carbohydrates, double proteins) 
        {
            Name = name;
            Weight = weight;
            Carbohydrates = carbohydrates;
            Proteins = proteins;
            Fats = fats;
            Kcal= Math.Round((Weight / 100) * Carbohydrates * 4 + (Weight / 100) * Fats * 9 + (Weight / 100) * Proteins * 4);
        }
    }
}
