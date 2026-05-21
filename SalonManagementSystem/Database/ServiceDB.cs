using MySql.Data.MySqlClient;
using System.Data;

namespace SalonManagementSystem.Database
{
    // This class contains ONLY database queries for Services table
    public class ServicesDB
    {
        // Get all services
        public DataTable GetAllServices()
        {
            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();

            string query = "SELECT * FROM services";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);

            DataTable table = new DataTable();
            adapter.Fill(table);

            conn.Close();
            return table;
        }

        // Insert service
        public void InsertService(string name, string price)
        {
            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();

            string query = "INSERT INTO services (service_name, price) VALUES (@name, @price)";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        // Update service
        public void UpdateService(int id, string name, string price)
        {
            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();

            string query = "UPDATE services SET service_name=@name, price=@price WHERE service_id=@id";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        // Delete service
        public void DeleteService(int id)
        {
            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();

            string query = "DELETE FROM services WHERE service_id=@id";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}