using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SalonManagementSystem
{
    public partial class BillingForm : Form
    {


        public BillingForm()
        {
            InitializeComponent();
        }


        private void BillingForm_Load(object sender, EventArgs e)
        {


            LoadAppointments();


        }


        private void LoadAppointments()
        {
            cmbAppointment.DataSource = null;

            var conn = DBConnection.GetConnection();
            conn.Open();

            string query = @"
                SELECT appointment_id,
                       CONCAT('Appointment #', appointment_id) AS display_text
                FROM appointments
                ORDER BY appointment_id ASC";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            cmbAppointment.DataSource = dt;
            cmbAppointment.DisplayMember = "display_text";
            cmbAppointment.ValueMember = "appointment_id";

            conn.Close();
        }





        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbAppointment.SelectedValue == null)
            {
                MessageBox.Show("Please select an appointment!");
                return;
            }

            var conn = DBConnection.GetConnection();
            conn.Open();

            string query = @"
        SELECT c.name, s.service_name, s.price
        FROM appointments a
        JOIN customers c ON a.customer_id = c.customer_id
        JOIN services s ON a.service_id = s.service_id
        WHERE a.appointment_id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", cmbAppointment.SelectedValue);

            MySqlDataReader reader = cmd.ExecuteReader();

            string price = "0";

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

            // INSERT BILL
            conn.Open();

            string insert = @"
        INSERT INTO bills (appointment_id, total_amount)
        VALUES (@id, @total)";

            MySqlCommand cmd2 = new MySqlCommand(insert, conn);
            cmd2.Parameters.AddWithValue("@id", cmbAppointment.SelectedValue);
            cmd2.Parameters.AddWithValue("@total", price);

            cmd2.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Bill Generated Successfully!");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            this.Hide();
        }
    }
}