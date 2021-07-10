using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.DAL.Repositories
{
    using Entities;
    using MySqlConnector;
    using ViewModel;
    static class EatenProductsRepository
    {
        #region Questions
        private const string ADD_PRODUCT = "INSERT INTO 'eaten_products'('id_eatenproduct', 'id_user', 'id_product', 'weight','kcal','date') VALUES ";
        private const string DELETE_PRODUCT = "DELETE FROM 'eaten_products' WHERE id=";
        #endregion

        #region CRUD methods
        public static List<EatenProduct> GetAllUserEatenProducts(User user)
        {
            List<EatenProduct> products = new List<EatenProduct>();
            using (var connection = DBConnection.Instance.Connection)
            {
                string ALL_PRODUCTS = $"SELECT e.id_eatenproduct, p.name, p.carbohydrates, p.proteins, p.fats, e.weight, e.kcal FROM products p JOIN eaten_products e ON p.id_product=e.id_product WHERE e.id_user={user.Id} AND DATE(date)=DATE(CURRENT_DATE()) ORDER BY e.date ASC";

                MySqlCommand command = new MySqlCommand(ALL_PRODUCTS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    products.Add(new EatenProduct(reader));
                connection.Close();
            }
            return products;
        }

        public static bool EditProductDB(EatenProduct eatenproduct, Product product)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                ProductsRepository.EditProductDB(product);
                string EDIT_PRODUCT = $"UPDATE eaten_products SET weight='{eatenproduct.Weight}', kcal='{eatenproduct.EatenKcal}' WHERE id={eatenproduct.Id}";

                MySqlCommand command = new MySqlCommand(EDIT_PRODUCT, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;

                connection.Close();
            }
            return state;
        }

 

        public static bool AddProductDB(EatenProduct eatenproduct, Product product, User user)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                ProductsRepository.AddProductDB(product);
                MySqlCommand command = new MySqlCommand($"{ADD_PRODUCT} ('NULL', '{user.Id}' {eatenproduct.ToInsert()})", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                eatenproduct.Id = (int)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        public static bool DeleteProductDB(EatenProduct product)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DELETE_PRODUCT} '{product.Id}'", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                connection.Close();
            }
            return state;
        }
        #endregion
    }
}
