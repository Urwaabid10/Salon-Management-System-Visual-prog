using MySql.Data.MySqlClient;
using SalonManagementSystem.Models;
using System;
using System.Data;

namespace SalonManagementSystem.Database
{
    // Handles all customer database operations
    public class CustomerDB
    {
        // Load all customers from database
        public DataTable GetCustomers()
        {
            DataTable table = new DataTable();

            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                string query =
                "SELECT customer_id, name, phone, email FROM customers ORDER BY customer_id";

                MySqlDataAdapter adapter =
                new MySqlDataAdapter(query, conn);

                adapter.Fill(table);
            }

            return table;
        }

        // Add new customer
        public void AddCustomer(Customer customer)
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                string query =
                "INSERT INTO customers (name, phone, email) VALUES (@name, @phone, @email)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", customer.Name);
                    cmd.Parameters.AddWithValue("@phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@email", customer.Email);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update customer
        public void UpdateCustomer(Customer customer)
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                string query =
                "UPDATE customers SET name=@name, phone=@phone, email=@email WHERE customer_id=@id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", customer.Name);
                    cmd.Parameters.AddWithValue("@phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@email", customer.Email);
                    cmd.Parameters.AddWithValue("@id", customer.CustomerID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete customer
        public void DeleteCustomer(int id)
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                string query =
                "DELETE FROM customers WHERE customer_id=@id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
