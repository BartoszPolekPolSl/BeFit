using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeFit.DAL
{
    using DAL.Entities;
    static class LoginSystem
    {

        public static void check(string login, string password)
        {

            using (var connection = DBConnection.Instance.Connection)
            {

                string LOGIN_USER = $"select u.id_user, u.username, u.password,i.sex,i.weight,i.height,i.age,i.activity,i.target from users u join userinfo i on u.id_user = i.id_user where  u.username='{login}' and u.password='{password}';";
                MySqlCommand command = new MySqlCommand(LOGIN_USER, connection);
                {
                    try
                    {
                        connection.Open();

                        var dataReader = command.ExecuteReader();
                        if (dataReader.HasRows)
                        {                          
                            dataReader.Read();
                            App.BeFitWindow(new User(dataReader));
                            
                            MessageBox.Show("Zostales zalogowany.");
                        }
                        else
                        {
                            MessageBox.Show("Nazwa uzytkownika bądź hasło są nieprawidłowe.");

                        }
                }
                    catch (MySqlException e)
                {
                    MessageBox.Show(e.ToString());
                }
                connection.Close();
            }
            }
        }
    }
}
