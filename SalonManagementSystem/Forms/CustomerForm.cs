using SalonManagementSystem.Database;
using SalonManagementSystem.Models;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SalonManagementSystem.Forms
{
    // Customer management form
    public partial class CustomerForm : Form
    {
        // Database object
        CustomerDB db = new CustomerDB();

        // Constructor
        public CustomerForm()
        {
            InitializeComponent();
        }

        // Form load event
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            // DataGridView settings
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            // Load customer data
            LoadCustomers();
        }

        // Load customers into DataGridView
        private void LoadCustomers()
        {
            try
            {
                dataGridView1.DataSource = db.GetCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading customers: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Display selected row data in textboxes
        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                dataGridView1.Rows[e.RowIndex];

                txtName.Text =
                row.Cells["name"].Value?.ToString() ?? "";

                txtPhone.Text =
                row.Cells["phone"].Value?.ToString() ?? "";

                txtEmail.Text =
                row.Cells["email"].Value?.ToString() ?? "";
            }
        }

        // Add customer button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(
                    "Please enter a customer name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                // Create customer object
                Customer customer = new Customer();

                customer.Name = txtName.Text.Trim();
                customer.Phone = txtPhone.Text.Trim();
                customer.Email = txtEmail.Text.Trim();

                // Add customer
                db.AddCustomer(customer);

                MessageBox.Show(
                    "Customer added successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Refresh data
                ClearInputs();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error adding customer: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Update customer button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Check selected row
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a customer row first.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Validate name
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(
                    "Please enter a customer name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                // Create customer object
                Customer customer = new Customer();

                customer.CustomerID =
                Convert.ToInt32(
                dataGridView1.SelectedRows[0]
                .Cells["customer_id"].Value);

                customer.Name = txtName.Text.Trim();
                customer.Phone = txtPhone.Text.Trim();
                customer.Email = txtEmail.Text.Trim();

                // Update customer
                db.UpdateCustomer(customer);

                MessageBox.Show(
                    "Customer updated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Refresh data
                ClearInputs();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating customer: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Delete customer button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check selected row
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a customer first!");

                return;
            }

            // Confirmation dialog
            DialogResult confirm = MessageBox.Show(
                "Delete this customer?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                // Get selected customer ID
                int id = Convert.ToInt32(
                    dataGridView1.SelectedRows[0]
                    .Cells["customer_id"].Value);

                // Delete customer
                db.DeleteCustomer(id);

                MessageBox.Show(
                    "Customer deleted successfully!");

                // Refresh data
                LoadCustomers();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message);
            }
        }

        // Clear input fields
        private void ClearInputs()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
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