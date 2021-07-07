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
        #region Questions
        private const string ADD_PRODUCT = "INSERT INTO 'products'('id_product', 'name', 'carbohydrates','proteins','fats','kcal') VALUES ";
        private const string DELETE_PRODUCT = "DELETE FROM 'products' WHERE id_product=";
        #endregion

        #region CRUD methods
        public static bool AddProductDB(Product product)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_PRODUCT} {product.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                product.Id = (int)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }
        public static bool DeleteProductDB(Product product)
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
        public static bool EditProductDB(Product product)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDIT_PRODUCT = $"UPDATE products SET name='{product.Name}', " +
                    $"carbohydrates={product.Carbohydrates}, proteins='{product.Proteins}', fats='{product.Fats}', kcal='{product.Kcal}' WHERE id={product.Id}";

                MySqlCommand command = new MySqlCommand(EDIT_PRODUCT, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;

                connection.Close();
            }
            return state;
        }

        #endregion
    }
}
