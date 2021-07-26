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
    using Model;
    static class LoginSystem
    {
        private const string LOGIN_USER = "SELECT u.id_user, u.username, u.password,i.sex,i.weight,i.height,i.age,i.activity,i.target FROM users u JOIN userinfo i ON u.id_user = i.id_user WHERE BINARY u.username=@login AND BINARY u.password=@password;";

        public static void Login(string login, string password)
        {

            using (var connection = DBConnection.Instance.Connection)
            {    
            try
            {
                    MySqlCommand command = new MySqlCommand(LOGIN_USER, connection);
                    command.CommandText = LOGIN_USER;
                    command.Parameters.AddWithValue("@login",login);
                    command.Parameters.AddWithValue("@password", password);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        Model model = new Model(new User(dataReader));
                        App.BeFitWindow(model);              
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
            }
        }
    }
}
