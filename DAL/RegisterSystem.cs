using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeFit.DAL
{
    static class RegisterSystem
    {
        public static void register(string login, string password, string sex, double weight, int height, int age, string activity, string target)
        {
            using (var connection = DBConnection.Instance.Connection)
            {
                try
                {
                   
                    if (IsUsernameAlreadyExist(login))
                    {
                        MessageBox.Show("Nazwa użytkownika jest już zajęta");
                        connection.Close();
                    }
                    else
                    {                      
                        string REGISTER_USER = $"INSERT INTO users (username, password) VALUES (@login, @password)";
                        var command = new MySqlCommand(REGISTER_USER, connection);
                        command.CommandText = REGISTER_USER;
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", password);
                        connection.Open();
                        var dataReaderNoQuery = command.ExecuteNonQuery();
                        int userid = (int)command.LastInsertedId;
                        string ADD_USERINFO = $"INSERT INTO userinfo (id_user, sex, weight, height, age, activity, target) VALUES(@userid, @sex, @weight, @height, @age, @activity, @target)";
                        command = new MySqlCommand(ADD_USERINFO, connection);
                        command.CommandText = ADD_USERINFO;
                        command.Parameters.AddWithValue("@userid", userid);
                        command.Parameters.AddWithValue("@sex", sex);
                        command.Parameters.AddWithValue("@weight", weight);
                        command.Parameters.AddWithValue("@height", height);
                        command.Parameters.AddWithValue("@age", age);
                        command.Parameters.AddWithValue("@activity", activity);
                        command.Parameters.AddWithValue("@target", target);
                        dataReaderNoQuery = command.ExecuteNonQuery();
                        connection.Close();
                    }                    
                }
                catch(MySqlException e)
                {
                    MessageBox.Show(e.ToString());
                }
                


                MessageBox.Show("Pomyślnie zarejestrowano.");

            }
        }
        private static bool IsUsernameAlreadyExist(string username)
        {
            using (var connection = DBConnection.Instance.Connection)
            {
                string CHECK_USERNAME = $"SELECT username FROM users WHERE username=@username";
                MySqlCommand command = new MySqlCommand(CHECK_USERNAME, connection);
                command.CommandText = CHECK_USERNAME;
                command.Parameters.AddWithValue("@username", username);
                connection.Open();
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
