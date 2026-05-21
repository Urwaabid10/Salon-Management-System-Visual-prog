using MySql.Data.MySqlClient;
using SalonManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagementSystem.Database
{
    public class UserDB
    {
        public bool Login(User user)
        {
            var conn = DBConnection.GetConnection();

            conn.Open();

            string query =
            "SELECT * FROM users WHERE username=@u AND password=@p";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@u", user.Username);
            cmd.Parameters.AddWithValue("@p", user.Password);

            MySqlDataReader reader = cmd.ExecuteReader();

            bool check = reader.HasRows;

            conn.Close();

            return check;
        }
    }
}
