using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.DAL
{
    static class FunFactsSystem
    {
        private const string GET_RANDOM_FANFUCT = "SELECT funfact FROM fun_facts ORDER BY RAND() LIMIT 1;";

        public static string GetRandomFunFact()
        {
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(GET_RANDOM_FANFUCT, connection);
                command.CommandText = GET_RANDOM_FANFUCT;
                connection.Open();
                var dataReader = command.ExecuteReader();
                dataReader.Read();
                return dataReader["funfact"].ToString();
            }
        }
    }
}
