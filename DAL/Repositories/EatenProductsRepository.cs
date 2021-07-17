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
        // TODO: Change to parameterized query
        #region Queries
        private const string ALL_PRODUCTS = "SELECT e.id_eatenproduct, p.id_product, p.name, p.carbohydrates, p.proteins, p.fats, e.weight, p.kcal FROM products p JOIN eaten_products e ON p.id_product=e.id_product WHERE e.id_user=@iduser AND DATE(date)=DATE(NOW()) ORDER BY e.date ASC";
        private const string EDIT_PRODUCT = "UPDATE eaten_products SET weight=@weight WHERE id_eatenproduct=@idproduct";
        private const string ADD_PRODUCT = "INSERT INTO eaten_products (id_eatenproduct, id_user, id_product, weight, date) VALUES (@ideatenproduct, @iduser, @idproduct, @weight, @date)";
        private const string REMOVE_PRODUCT = "DELETE FROM eaten_products WHERE id_eatenproduct=@idproduct";
        #endregion

        #region CRUD methods
        public static List<EatenProduct> GetAllUserEatenProducts(User user)
        {
            List<EatenProduct> products = new List<EatenProduct>();
            using (var connection = DBConnection.Instance.Connection)
            {           
                MySqlCommand command = new MySqlCommand(ALL_PRODUCTS, connection);
                command.CommandText = ALL_PRODUCTS;
                command.Parameters.AddWithValue("@iduser", user.Id);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    products.Add(new EatenProduct(reader));
                connection.Close();
            }
            return products;
        }

        public static bool EditProductDB(EatenProduct eatenproduct)
        {
            Product product = eatenproduct;
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                if (ProductsRepository.EditProductDB(product))
                {  
                    MySqlCommand command = new MySqlCommand(EDIT_PRODUCT, connection);
                    command.CommandText = EDIT_PRODUCT;
                    command.Parameters.AddWithValue("@weight", eatenproduct.Weight);
                    command.Parameters.AddWithValue("@idproduct", eatenproduct.IdEatenProduct);
                    connection.Open();
                    var n = command.ExecuteNonQuery();
                    state = true;
                    connection.Close();
                }
                else
                {
                    state = false;
                }
            }
            return state;
        }



        public static bool AddProductDB(EatenProduct eatenproduct, User user)
        {
            Product product = eatenproduct;
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {  
                ProductsRepository.AddProductDB(ref product);
                MySqlCommand command = new MySqlCommand(ADD_PRODUCT, connection);
                command.CommandText = ADD_PRODUCT;
                command.Parameters.AddWithValue("@ideatenproduct",null);
                command.Parameters.AddWithValue("@iduser", user.Id);
                command.Parameters.AddWithValue("@idproduct", product.IdProduct);
                command.Parameters.AddWithValue("@weight", eatenproduct.Weight);
                command.Parameters.AddWithValue("@date", DateTime.Now);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                eatenproduct.IdEatenProduct = (int)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        public static bool RemoveProductDB(EatenProduct eatenproduct)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {              
                MySqlCommand command = new MySqlCommand(REMOVE_PRODUCT, connection);
                command.CommandText = REMOVE_PRODUCT;
                command.Parameters.AddWithValue("@idproduct", eatenproduct.IdEatenProduct);
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
