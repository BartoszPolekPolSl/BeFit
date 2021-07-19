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
        public int? IdEatenProduct { get; set; }
        public double Weight { get; set; }
        public double EatenProteins { get; set; }
        public double EatenCarbohydrates { get; set; }
        public double EatenFats { get; set; }
        public double EatenKcal { get; set; }

        public EatenProduct()
        {
        }

        public EatenProduct(Product product, double weight):base(product)
        {
            Weight = weight;
            EatenFats = GetEatenMacro(product.Fats);
            EatenCarbohydrates = GetEatenMacro(product.Carbohydrates);
            EatenProteins = GetEatenMacro(product.Proteins);
            EatenKcal = GetEatenMacro(product.Kcal);
        }
        public EatenProduct(Product product) : base(product)
        {

        }

        public EatenProduct(MySqlDataReader reader):base(reader)
        {
            IdEatenProduct = int.Parse(reader["id_eatenproduct"].ToString());
            EatenKcal = double.Parse(reader["kcal"].ToString());
            Weight = double.Parse(reader["weight"].ToString());
            EatenCarbohydrates = GetEatenMacro(double.Parse(reader["carbohydrates"].ToString()));
            EatenProteins = GetEatenMacro(double.Parse(reader["proteins"].ToString()));
            EatenFats = GetEatenMacro(double.Parse(reader["fats"].ToString()));
            EatenKcal = GetEatenMacro(Kcal);
        }

        public EatenProduct(EatenProduct eatenproduct)
        {
            IdProduct = eatenproduct.IdProduct;
            Name = eatenproduct.Name;
            Carbohydrates = eatenproduct.Carbohydrates;
            Proteins = eatenproduct.Proteins;
            Fats = eatenproduct.Fats;
            Kcal = eatenproduct.Kcal;
            IdEatenProduct = eatenproduct.IdEatenProduct;
            Weight = eatenproduct.Weight;
            EatenProteins = eatenproduct.EatenProteins;
            EatenFats = eatenproduct.EatenFats;
            EatenCarbohydrates = eatenproduct.EatenCarbohydrates;
            EatenKcal = eatenproduct.EatenKcal;
        }
        #region Methods
        private double GetEatenMacro(double macro)
        {
            return Math.Round( macro*(Weight / 100),2);
        }

        public override string ToString()
        {
            return $"Nazwa:{Name},Waga:{Weight},Tłuszcze:{EatenFats},Węglowodany:{EatenCarbohydrates},Białko:{EatenProteins},KCAL:{EatenKcal}";
        }
        #endregion Methods
    }
}
