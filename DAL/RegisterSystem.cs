using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeFit.DAL
{
    static class RegisterSystem
    {
        private const string REGISTER_USER = "INSERT INTO users (username, password) VALUES (@login, @password)";
        private const string ADD_USERINFO = "INSERT INTO userinfo (id_user, sex, weight, height, age, activity, target) VALUES(@userid, @sex, @weight, @height, @age, @activity, @target)";
        private const string CHECK_USERNAME = "SELECT username FROM users WHERE username=@username";


        public static void register(string login, SecureString password, string sex, double weight, int height, int age, string activity, string target)
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
                        var command = new MySqlCommand(REGISTER_USER, connection);
                        command.CommandText = REGISTER_USER;
                        command.Parameters.AddWithValue("@login", login);
                        string ps= new NetworkCredential("", password).Password;
                        command.Parameters.AddWithValue("@password", ps);
                        connection.Open();
                        var dataReaderNoQuery = command.ExecuteNonQuery();
                        int userid = (int)command.LastInsertedId;      
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
