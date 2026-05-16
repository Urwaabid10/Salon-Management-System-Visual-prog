using System;
using System.Windows.Forms;

namespace SalonManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            BillingForm form = new BillingForm();
            form.Show();
            this.Hide();

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomerForm form = new CustomerForm();
            form.Show();
            this.Hide();

        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            ServiceForm form = new ServiceForm();
            form.Show();
            this.Hide();

        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            AppointmentForm form = new AppointmentForm();
            form.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
      "Are you sure you want to logout?",
      "Logout Confirmation",
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide(); 

                LoginForm login = new LoginForm(); 
                login.Show();
            }
        }
    }
}
