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
        #region Queries
        private const string DELETE_PRODUCT = "DELETE FROM products WHERE id_product=@idproduct";
        private const string ADD_PRODUCT = "INSERT INTO products (name, carbohydrates, proteins, fats, kcal) VALUES( @name, @carbohydrates, @proteins, @fats, @kcal)";
        private const string EDIT_PRODUCT = "UPDATE products SET name=@name, carbohydrates=@carbohydrates, proteins=@proteins, fats=@fats, kcal=@kcal WHERE id_product=@idproduct";
        private const string GET_PRODUCT = "SELECT * FROM products WHERE name=@name AND carbohydrates=@carbohydrates AND proteins=@proteins AND fats=@fats AND kcal=@kcal";
        #endregion

        #region CRUD methods
        public static bool AddProductDB(ref Product product)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                if (!ifProductAlreadyExist(ref product))
                {                 
                    MySqlCommand command = new MySqlCommand(ADD_PRODUCT, connection);
                    command.CommandText = ADD_PRODUCT;
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@carbohydrates", product.Carbohydrates);
                    command.Parameters.AddWithValue("@proteins", product.Proteins);
                    command.Parameters.AddWithValue("@fats", product.Fats);
                    command.Parameters.AddWithValue("@kcal", product.Kcal);
                    connection.Open();
                    var id = command.ExecuteNonQuery();
                    state = true;
                    product.IdProduct = (int)command.LastInsertedId;
                    connection.Close();
                }   
            }
            return state;
        }
        public static bool RemoveProductDB(Product product)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(DELETE_PRODUCT, connection);
                command.CommandText = DELETE_PRODUCT;
                command.Parameters.AddWithValue("@idproduct", product.IdProduct);
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
                MySqlCommand command = new MySqlCommand(EDIT_PRODUCT, connection);
                command.CommandText = EDIT_PRODUCT;
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@carbohydrates", product.Carbohydrates);
                command.Parameters.AddWithValue("@proteins", product.Proteins);
                command.Parameters.AddWithValue("@fats", product.Fats);
                command.Parameters.AddWithValue("@kcal", product.Kcal);
                command.Parameters.AddWithValue("@idproduct", product.IdProduct);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;

                connection.Close();
            }
            return state;
        }

        private static bool ifProductAlreadyExist(ref Product product)
        {
            
            using (var connection = DBConnection.Instance.Connection)
            {           
                MySqlCommand command = new MySqlCommand(GET_PRODUCT, connection);
                command.CommandText = GET_PRODUCT;
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@carbohydrates", product.Carbohydrates);
                command.Parameters.AddWithValue("@proteins", product.Proteins);
                command.Parameters.AddWithValue("@fats", product.Fats);
                command.Parameters.AddWithValue("@kcal", product.Kcal);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    product = new Product(reader);
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
