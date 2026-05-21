using System;
using System.Windows.Forms;

namespace SalonManagementSystem.Forms
{
    public partial class Dashboard : Form
    {
        // Constructor
        public Dashboard()
        {
            InitializeComponent();
        }

        // Open Billing Form
        private void btnBilling_Click(object sender, EventArgs e)
        {
            BillingForm form = new BillingForm();

            form.Show();

            // Hide current dashboard
            this.Hide();
        }

        // Open Customer Management Form
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomerForm form = new CustomerForm();

            form.Show();

            // Hide current dashboard
            this.Hide();
        }

        // Open Service Management Form
        private void btnServices_Click(object sender, EventArgs e)
        {
            ServiceForm form = new ServiceForm();

            form.Show();

            // Hide current dashboard
            this.Hide();
        }

        // Open Appointment Management Form
        private void btnAppointments_Click(object sender, EventArgs e)
        {
            AppointmentForm form = new AppointmentForm();

            form.Show();

            // Hide current dashboard
            this.Hide();
        }

        // Logout button functionality
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Confirmation message before logout
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // If user clicks Yes
            if (result == DialogResult.Yes)
            {
                // Hide dashboard
                this.Hide();

                // Open login form
                LoginForm login = new LoginForm();

                login.Show();
            }
        }
    }
}