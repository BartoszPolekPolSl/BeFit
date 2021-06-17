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
        int Id { get; }
        int UserId { get; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Carbohydrates { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Kcal { get; set; }
        
        public Product(MySqlDataReader reader)
        {            
            Id = sbyte.Parse(reader["id"].ToString());
            UserId = sbyte.Parse(reader["userid"].ToString());
            Name = reader["name"].ToString();
            Weight = double.Parse(reader["weight"].ToString());
            Carbohydrates = double.Parse(reader["carbohydrates"].ToString());
            Proteins = double.Parse(reader["proteins"].ToString());
            Fats = double.Parse(reader["fats"].ToString());
            Kcal = double.Parse(reader["kcal"].ToString());
        }

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
