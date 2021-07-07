using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.DAL.Entities
{
    public class Product
    {
        #region Properites

        public int? Id { get; set; }
        public string Name { get; set; }
        public double Carbohydrates { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Kcal { get; set; }
        #endregion Properties

        #region Constructors
        public Product()
        {

        }
        public Product(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Carbohydrates = product.Carbohydrates;
            Proteins = product.Proteins;
            Fats = product.Fats;
            Kcal = product.Kcal;
        }
        public Product(MySqlDataReader reader)
        {            
            Id = int.Parse(reader["id"].ToString());
            Name = reader["name"].ToString();
            Carbohydrates = double.Parse(reader["carbohydrates"].ToString());
            Proteins = double.Parse(reader["proteins"].ToString());
            Fats = double.Parse(reader["fats"].ToString());
            Kcal = double.Parse(reader["kcal"].ToString());
        }

        public Product( string name, double fats, double carbohydrates, double proteins, double kcal) 
        {
            Id = null;
            Name = name;
            Carbohydrates = carbohydrates;
            Proteins = proteins;
            Fats = fats;
            Kcal = kcal;
            
        }
        #endregion Constructors

        #region Methods
        virtual public string ToInsert()
        {
            return $"('NULL', '{Name}', '{Carbohydrates}','{Proteins}','{Fats}','{Kcal}')";
        }


        #endregion Methods
    }
}
