using System;
using System.Windows.Forms;

using SalonManagementSystem.Models;
using SalonManagementSystem.Database;

namespace SalonManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if all fields are filled
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter all fields");
                return;
            }
            // Create a new user object and set its properties
            User u = new User();

            u.Username = txtUsername.Text;
            u.Password = txtPassword.Text;

            UserDB db = new UserDB();

            bool check = db.Login(u);
            // If the login is successful, show the dashboard form
            if (check)
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
        }
    }
}
