using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SalonManagementSystem
{
    public partial class ServiceForm : Form
    {
        public ServiceForm()
        {
            InitializeComponent();
        }

        private void ServiceForm_Load(object sender, EventArgs e)
        {
            LoadServices();
        }
        private void LoadServices()
        {
            var conn = DBConnection.GetConnection();
            conn.Open();

            string query = "SELECT * FROM services";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridView1.DataSource = table;

            conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var conn = DBConnection.GetConnection();
            conn.Open();

            string query = "INSERT INTO services (service_name, price) VALUES (@name, @price)";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@name", txtServiceName.Text);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Service Added!");

            LoadServices();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a service first!");
                return;
            }

            var conn = DBConnection.GetConnection();
            conn.Open();

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["service_id"].Value);

            string query = "UPDATE services SET service_name=@name, price=@price WHERE service_id=@id";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@name", txtServiceName.Text);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Service Updated!");

            LoadServices();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a service first!");
                return;
            }

            var conn = DBConnection.GetConnection();
            conn.Open();

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["service_id"].Value);

            string query = "DELETE FROM services WHERE service_id=@id";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Service Deleted!");

            LoadServices();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtServiceName.Text = dataGridView1.Rows[e.RowIndex].Cells["service_name"].Value.ToString();
                txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();

            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
    }
}
