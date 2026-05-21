using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SalonManagementSystem.Models;
using SalonManagementSystem.Database;

namespace SalonManagementSystem.Forms
{
    public partial class BillingForm : Form
    {
        // Model object
        private Billing billing = new Billing();

        public BillingForm()
        {
            InitializeComponent();
        }

        private void BillingForm_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        // Load appointments into combo box
        private void LoadAppointments()
        {
            cmbAppointment.DataSource = billing.LoadAppointments();
            cmbAppointment.DisplayMember = "display_text";
            cmbAppointment.ValueMember = "appointment_id";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbAppointment.SelectedValue == null)
            {
                MessageBox.Show("Please select an appointment!");
                return;
            }

            int appointmentId = Convert.ToInt32(cmbAppointment.SelectedValue);

            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();

            string price = "0";

            // Get appointment billing details
            MySqlDataReader reader = billing.GetDetails(conn, appointmentId);

            if (reader.Read())
            {
                txtCustomer.Text = reader["name"].ToString();
                txtService.Text = reader["service_name"].ToString();
                txtPrice.Text = reader["price"].ToString();
                txtTotal.Text = reader["price"].ToString();

                price = reader["price"].ToString();
            }

            reader.Close();
            conn.Close();

            // Insert bill record
            billing.CreateBill(appointmentId, price);

            MessageBox.Show("Bill Generated Successfully!");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
    }
}