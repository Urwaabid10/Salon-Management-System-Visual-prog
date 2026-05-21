using MySql.Data.MySqlClient;
using System.Data;

namespace SalonManagementSystem.Database
{
    // This class contains ONLY database operations for billing
    public class BillingDB
    {
        // Load appointments for dropdown
        public DataTable GetAppointments()
        {
            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();

            string query = @"
                SELECT appointment_id,
                       CONCAT('Appointment #', appointment_id) AS display_text
                FROM appointments
                ORDER BY appointment_id ASC";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            conn.Close();
            return dt;
        }

        // Get billing details for selected appointment
        public MySqlDataReader GetBillDetails(MySqlConnection conn, int appointmentId)
        {
            string query = @"
                SELECT c.name, s.service_name, s.price
                FROM appointments a
                JOIN customers c ON a.customer_id = c.customer_id
                JOIN services s ON a.service_id = s.service_id
                WHERE a.appointment_id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", appointmentId);

            return cmd.ExecuteReader();
        }

        // Insert bill record
        public void InsertBill(int appointmentId, string total)
        {
            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();

            string insert = @"
                INSERT INTO bills (appointment_id, total_amount)
                VALUES (@id, @total)";

            MySqlCommand cmd = new MySqlCommand(insert, conn);
            cmd.Parameters.AddWithValue("@id", appointmentId);
            cmd.Parameters.AddWithValue("@total", total);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}