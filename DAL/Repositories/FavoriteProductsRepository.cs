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
        // TODO: Change to parameterized query
        #region Questions
        private const string ADD_PRODUCT = "INSERT INTO 'favorite_products'('id_favoriteproducts', 'id_product', 'id_user') VALUES ";
        private const string DELETE_PRODUCT = "DELETE FROM 'favorite_products' WHERE id_favoriteproducts=";
        #endregion

        #region CRUD methods
        public static List<Product> GetAllUserFavoriteProducts(User user)
        {
            List<Product> products = new List<Product>();
            using (var connection = DBConnection.Instance.Connection)
            {
                string ALL_PRODUCTS = $"SELECT p.name, p.carbohydrates, p.proteins, p.fats, p.kcal FROM products p JOIN favorite_products f ON f.id_product=p.id_product WHERE f.id_user={user.Id} ORDER BY f.id_favoriteproducts ASC";

                MySqlCommand command = new MySqlCommand(ALL_PRODUCTS, connection);
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
            using (var connection = DBConnection.Instance.Connection)
            {
                ProductsRepository.AddProductDB(ref product);
                MySqlCommand command = new MySqlCommand($"{ADD_PRODUCT} ('null', '{product.IdProduct}', '{user.Id}')", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                product.IdProduct = (int)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        public static bool DeleteProductDB(Product product)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DELETE_PRODUCT} '{product.IdProduct}'", connection);
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
