using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace BeFit.DAL.Entities
{
    using Repositories;
    public class EatenProduct : Product
    {
        public double Weight { get; set; }
        public double EatenKcal { get; set; }

        public EatenProduct(Product product, double weight)
        {
            Name = product.Name;
            Weight = weight;
            Fats = GetEatenMacro(product.Fats);
            Carbohydrates = GetEatenMacro(product.Carbohydrates); 
            Proteins = GetEatenMacro(product.Proteins);
            Kcal = product.Kcal;
            EatenKcal = GetEatenMacro(Kcal);
        }

        public EatenProduct(MySqlDataReader reader):base(reader)
        {
            Weight = double.Parse(reader["weight"].ToString());
            Carbohydrates = double.Parse(reader["carbohydrates"].ToString())*(Weight/100);
            Proteins = double.Parse(reader["proteins"].ToString()) * (Weight / 100);
            Fats = double.Parse(reader["fats"].ToString()) * (Weight / 100);
            EatenKcal = double.Parse(reader["kcal"].ToString());
        }


        #region Methods
        private double GetEatenMacro(double macro)
        {
            return macro*(Weight / 100);
        }
        override public string ToInsert()
        {
            return $"'{Id}', '{Weight}', '{EatenKcal}', current_timestamp()";
        }

        public string ToInsertFavourite()
        {
            return $"('{Name}','0','{Carbohydrates}','{Proteins}','{Fats}','{Kcal}')";
        }

        #endregion Methods
    }
}
