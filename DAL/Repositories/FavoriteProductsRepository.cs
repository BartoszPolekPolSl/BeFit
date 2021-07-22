using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.DAL.Repositories
{
    using Entities;
    using MySqlConnector;
    static class FavoriteProductsRepository
    {
        #region Questions
        private const string ADD_PRODUCT = "INSERT INTO favorite_products (id_product, id_user) VALUES (@idproduct, @iduser) ";
        private const string REMOVE_PRODUCT = "DELETE FROM favorite_products WHERE id_product=@idproduct";
        private const string ALL_PRODUCTS = "SELECT p.id_product, p.name, p.carbohydrates, p.proteins, p.fats, p.kcal FROM products p JOIN favorite_products f ON f.id_product=p.id_product WHERE f.id_user=@iduser ORDER BY f.id_favoriteproduct ASC";
        private const string GET_PRODUCT = "SELECT * FROM favorite_products f JOIN products p ON f.id_product=p.id_product WHERE id_user=@iduser AND p.name=@name AND p.carbohydrates=@carbohydrates AND p.proteins=@proteins AND p.fats=@fats AND p.kcal=@kcal";
        #endregion

        #region CRUD methods
        public static List<Product> GetAllUserFavoriteProducts(User user)
        {
            List<Product> products = new List<Product>();
            using (var connection = DBConnection.Instance.Connection)
            {             
                MySqlCommand command = new MySqlCommand(ALL_PRODUCTS, connection);
                command.CommandText = ALL_PRODUCTS;
                command.Parameters.AddWithValue("@iduser", user.Id);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    products.Add(new Product(reader));
                connection.Close();
            }
            return products;
        }

        public static bool EditProductDB(Product product)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                state=ProductsRepository.EditProductDB(product);
            }
            return state;
        }

        public static bool AddProductDB(Product product, User user)
        {
            bool state = false;
            if(!ifFavoriteProductAlreadyExist(product, user))
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    ProductsRepository.AddProductDB(ref product);
                    MySqlCommand command = new MySqlCommand(ADD_PRODUCT, connection);
                    command.CommandText = ADD_PRODUCT;
                    command.Parameters.AddWithValue("@idproduct", product.IdProduct);
                    command.Parameters.AddWithValue("@iduser", user.Id);
                    connection.Open();
                    var id = command.ExecuteNonQuery();
                    state = true;
                    product.IdProduct = (int)command.LastInsertedId;
                    connection.Close();
                }
                return state;
            }
            return false;
        }

        public static bool RemoveProductDB(Product product)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(REMOVE_PRODUCT, connection);
                command.CommandText = REMOVE_PRODUCT;
                command.Parameters.AddWithValue("@idproduct",product.IdProduct);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                connection.Close();
            }
            return state;
        }

        private static bool ifFavoriteProductAlreadyExist(Product product, User user)
        {

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(GET_PRODUCT, connection);
                command.CommandText = GET_PRODUCT;
                command.Parameters.AddWithValue("@iduser", user.Id);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@carbohydrates", product.Carbohydrates);
                command.Parameters.AddWithValue("@proteins", product.Proteins);
                command.Parameters.AddWithValue("@fats", product.Fats);
                command.Parameters.AddWithValue("@kcal", product.Kcal);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion
    }
}
