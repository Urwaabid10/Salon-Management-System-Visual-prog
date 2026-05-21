using System;
using System.Windows.Forms;
using SalonManagementSystem.Models;

namespace SalonManagementSystem.Forms
{
    public partial class ServiceForm : Form
    {
        // Model object
        private Service service = new Service();

        public ServiceForm()
        {
            InitializeComponent();
        }

        private void ServiceForm_Load(object sender, EventArgs e)
        {
            LoadServices();
        }

        // Load data into grid
        private void LoadServices()
        {
            dataGridView1.DataSource = service.GetServices();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            service.Add(txtServiceName.Text, txtPrice.Text);

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

            int id = Convert.ToInt32(
                dataGridView1.SelectedRows[0].Cells["service_id"].Value
            );

            service.Update(id, txtServiceName.Text, txtPrice.Text);

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

            int id = Convert.ToInt32(
                dataGridView1.SelectedRows[0].Cells["service_id"].Value
            );

            service.Delete(id);

            MessageBox.Show("Service Deleted!");
            LoadServices();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtServiceName.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["service_name"].Value.ToString();

                txtPrice.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString();
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