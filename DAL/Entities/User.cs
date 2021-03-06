using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.DAL.Entities
{

    public class User
    {

        public int? Id { get;}
        public string UserName { get; set; }
        public SecureString Password { private get; set; }
        public string Sex { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public string Activity { get; set; }
        public string Target { get; set; }

        public User(string username, SecureString password, string sex, double weight, int height, int age, string activity, string target)
        {
            Id = null;
            UserName = username;
            Password = password;
            Sex = sex;
            Weight = weight;
            Height = height;
            Age = age;
            Activity = activity;
            Target = target;
        }

        public User(int id, string username, SecureString password, string sex, double weight, int height, int age, string activity, string target)
        {
            Id = id;
            UserName = username;
            Password = password;
            Sex = sex;
            Weight = weight;
            Height = height;
            Age = age;
            Activity = activity;
            Target = target;
        }

        public User(MySqlDataReader reader)
        {
            Id = int.Parse(reader["id_user"].ToString());
            UserName = reader["username"].ToString();
            var str = reader["password"].ToString(); ;
            var sc = new SecureString();
            foreach (char c in str) sc.AppendChar(c);
            Password = sc;
            Sex = reader["sex"].ToString();
            Weight = double.Parse(reader["weight"].ToString());
            Height = int.Parse(reader["height"].ToString());
            Age = int.Parse(reader["age"].ToString());
            Activity = reader["activity"].ToString();
            Target = reader["Target"].ToString();
        }

       
    }
}
