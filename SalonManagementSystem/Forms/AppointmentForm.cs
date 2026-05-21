using Mysqlx.Crud;
using SalonManagementSystem.Database;
using SalonManagementSystem.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace SalonManagementSystem.Forms
{
    // Appointment management form
    public partial class AppointmentForm : Form
    {
        // Database object
        AppointmentDB db = new AppointmentDB();

        // Constructor
        public AppointmentForm()
        {
            InitializeComponent();
        }

        // Form load event
        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            // Load customer dropdown
            LoadCustomers();

            // Load service dropdown
            LoadServices();

            // Load appointments table
            LoadAppointments();
        }

        // Load customers into ComboBox
        private void LoadCustomers()
        {
            cmbCustomer.DataSource = db.GetCustomers();

            cmbCustomer.DisplayMember = "name";
            cmbCustomer.ValueMember = "customer_id";
        }

        // Load services into ComboBox
        private void LoadServices()
        {
            cmbService.DataSource = db.GetServices();

            cmbService.DisplayMember = "service_name";
            cmbService.ValueMember = "service_id";
        }

        // Book appointment button
        private void btnBook_Click(object sender, EventArgs e)
        {
            // Validation
            if (cmbCustomer.SelectedIndex == -1 ||
                cmbService.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select customer and service!");

                return;
            }

            // Create appointment object
            Appointment appointment = new Appointment();

            appointment.CustomerID =
            Convert.ToInt32(cmbCustomer.SelectedValue);

            appointment.ServiceID =
            Convert.ToInt32(cmbService.SelectedValue);

            appointment.Date =
            dtpDate.Value.Date;

            appointment.Time =
            dtpTime.Value.TimeOfDay;

            // Save appointment
            db.AddAppointment(appointment);

            MessageBox.Show(
                "Appointment Booked Successfully!");

            // Reload appointments
            LoadAppointments();
        }

        // Load appointments into DataGridView
        private void LoadAppointments()
        {
            dataGridView1.DataSource =
            db.GetAppointments();

            // Sort appointments by ID
            dataGridView1.Sort(
                dataGridView1.Columns["appointment_id"],
                System.ComponentModel.ListSortDirection
                .Ascending);
        }

        // Delete appointment button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Validation
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Select an appointment first!");

                return;
            }

            // Get selected appointment ID
            int id = Convert.ToInt32(
                dataGridView1.SelectedRows[0]
                .Cells["appointment_id"].Value);

            // Delete appointment
            db.DeleteAppointment(id);

            MessageBox.Show(
                "Appointment Deleted!");

            // Reload appointments
            LoadAppointments();
        }

        // Back button
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Hide current form
            this.Hide();

            // Open dashboard
            Dashboard dashboard = new Dashboard();

            dashboard.Show();
        }
    }
}
