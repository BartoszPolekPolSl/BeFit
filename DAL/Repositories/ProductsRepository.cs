using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.DAL.Repositories
{
    using Entities;
    using MySqlConnector;

    static class ProductsRepository
    {
        public static List<Product> GetAllUserEatenProducts(User user)
        {
            List<Product> products = new List<Product>();
            using (var connection = DBConnection.Instance.Connection)
            {
                string ALL_PRODUCTS = $"SELECT * FROM 'eaten_products' WHERE userid='{user.Id}'";

                MySqlCommand command = new MySqlCommand(ALL_PRODUCTS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    products.Add(new Product(reader));
                connection.Close();
            }
            return products;
        }
    }
}
