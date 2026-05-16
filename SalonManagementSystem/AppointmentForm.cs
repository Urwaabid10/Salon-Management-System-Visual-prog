using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SalonManagementSystem
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadServices();
            LoadAppointments();
        }
        private void LoadCustomers()
        {
            var conn = DBConnection.GetConnection();
            conn.Open();

            string query = "SELECT customer_id, name FROM customers";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            cmbCustomer.DataSource = dt;
            cmbCustomer.DisplayMember = "name";
            cmbCustomer.ValueMember = "customer_id";

            conn.Close();
        }

        private void LoadServices()
        {
            var conn = DBConnection.GetConnection();
            conn.Open();

            string query = "SELECT service_id, service_name FROM services";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            cmbService.DataSource = dt;
            cmbService.DisplayMember = "service_name";
            cmbService.ValueMember = "service_id";

            conn.Close();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex == -1 || cmbService.SelectedIndex == -1)
            {
                MessageBox.Show("Please select customer and service!");
                return;
            }

            var conn = DBConnection.GetConnection();
            conn.Open();

            string query = @"
        INSERT INTO appointments 
        (customer_id, service_id, date, time) 
        VALUES (@c, @s, @d, @t)";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@c", cmbCustomer.SelectedValue);
            cmd.Parameters.AddWithValue("@s", cmbService.SelectedValue);
            cmd.Parameters.AddWithValue("@d", dtpDate.Value.Date);
            cmd.Parameters.AddWithValue("@t", dtpTime.Value.TimeOfDay);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Appointment Booked Successfully!");

            LoadAppointments();
        }
        private void LoadAppointments()
        {
            var conn = DBConnection.GetConnection();
            conn.Open();

            string query = @"
    SELECT a.appointment_id, 
           c.name AS customer_name, 
           s.service_name, 
           a.date, 
           a.time
    FROM appointments a
    JOIN customers c ON a.customer_id = c.customer_id
    JOIN services s ON a.service_id = s.service_id";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridView1.DataSource = table;

            dataGridView1.Sort(
    dataGridView1.Columns["appointment_id"],
    System.ComponentModel.ListSortDirection.Ascending);
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an appointment first!");
                return;
            }

            var conn = DBConnection.GetConnection();
            conn.Open();

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["appointment_id"].Value);

            string query = "DELETE FROM appointments WHERE appointment_id=@id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Appointment Deleted!");

            LoadAppointments();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();

            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
    }
}
