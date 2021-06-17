using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.DAL.Entities
{
    class User
    {
        public int Id { get;}
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public string Activity { get; set; }
        public string Target { get; set; }

        public User(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id"].ToString());
            UserName = reader["username"].ToString();
            Password = reader["password"].ToString();
            Sex = reader["sex"].ToString();
            Weight = double.Parse(reader["weight"].ToString());
            Height = sbyte.Parse(reader["height"].ToString());
            Age = sbyte.Parse(reader["age"].ToString());
            Activity = reader["activity"].ToString();
            Target = reader["Target"].ToString();
        }
    }
}
