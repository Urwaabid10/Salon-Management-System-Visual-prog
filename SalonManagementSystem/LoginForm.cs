using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace SalonManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter all fields");
                return;
            }

            var conn = DBConnection.GetConnection();
            conn.Open();

            string query = "SELECT * FROM users WHERE username=@u AND password=@p";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@u", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p", txtPassword.Text);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                MessageBox.Show("Login Successful!");

                Dashboard d = new Dashboard();
                d.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }

            conn.Close();
        }
    }
}
