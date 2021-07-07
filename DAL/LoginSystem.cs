using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeFit.DAL
{
    static class LoginSystem
    {

        public static void check(string login, string password)
        {

            using (var connection = DBConnection.Instance.Connection)
            {

                string LOGIN_USER = $"select * from users where username = '{login}' and password = '{password}' ";
                MySqlCommand command = new MySqlCommand(LOGIN_USER, connection);
                {
                    try
                    {
                        connection.Open();

                        var dataReader = command.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {


                            }

                            MessageBox.Show("Zostales zalogowany.");

                        }
                        else
                        {
                            MessageBox.Show("Nazwa uzytkownika bądź hasło są nieprawidłowe.");

                        }
                    }
                    catch (MySqlException)
                    {
                        MessageBox.Show("Brak połączenia z serwerem.");
                    }
                    connection.Close();
                }
            }
        }

        public static void register(string login, string password)
        {
            using (var connection = DBConnection.Instance.Connection)
            {
                string REGISTER_USER = $"insert into users (username, password) VALUES ('{login}', '{password}')";
                MySqlCommand command = new MySqlCommand(REGISTER_USER, connection);
                connection.Open();
                var dataReader = command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
