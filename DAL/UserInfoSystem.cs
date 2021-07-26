using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.DAL
{
    using Entities;
    static class UserInfoSystem
    {
        private const string EDIT_USERINFO = "UPDATE userinfo SET sex=@sex, weight=@weight, height=@height, age=@age, activity=@activity, target=@target WHERE id_user=@iduser";
        public static bool EditUserInfoDB(int? userid, string sex, double weight, int height, int age, string activity, string target)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(EDIT_USERINFO, connection);
                command.CommandText = EDIT_USERINFO;
                command.Parameters.AddWithValue("@iduser", userid);
                command.Parameters.AddWithValue("@sex", sex);
                command.Parameters.AddWithValue("@weight", weight);
                command.Parameters.AddWithValue("@height", height);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@activity", activity);
                command.Parameters.AddWithValue("@target", target);
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;
                connection.Close();
            }
            return state;
        }
    }
}
