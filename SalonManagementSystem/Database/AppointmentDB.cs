using MySql.Data.MySqlClient;
using SalonManagementSystem.Models;
using System;
using System.Data;

namespace SalonManagementSystem.Database
{
    // Handles all appointment database operations
    public class AppointmentDB
    {
        // Load customer list
        public DataTable GetCustomers()
        {
            DataTable dt = new DataTable();

            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                string query =
                "SELECT customer_id, name FROM customers";

                MySqlDataAdapter adapter =
                new MySqlDataAdapter(query, conn);

                adapter.Fill(dt);
            }

            return dt;
        }

        // Load services list
        public DataTable GetServices()
        {
            DataTable dt = new DataTable();

            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                string query =
                "SELECT service_id, service_name FROM services";

                MySqlDataAdapter adapter =
                new MySqlDataAdapter(query, conn);

                adapter.Fill(dt);
            }

            return dt;
        }

        // Book appointment
        public void AddAppointment(Appointment appointment)
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                string query = @"
                INSERT INTO appointments
                (customer_id, service_id, date, time)
                VALUES (@c, @s, @d, @t)";

                MySqlCommand cmd =
                new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@c",
                    appointment.CustomerID);

                cmd.Parameters.AddWithValue(
                    "@s",
                    appointment.ServiceID);

                cmd.Parameters.AddWithValue(
                    "@d",
                    appointment.Date);

                cmd.Parameters.AddWithValue(
                    "@t",
                    appointment.Time);

                cmd.ExecuteNonQuery();
            }
        }

        // Load all appointments
        public DataTable GetAppointments()
        {
            DataTable table = new DataTable();

            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                string query = @"
                SELECT a.appointment_id,
                       c.name AS customer_name,
                       s.service_name,
                       a.date,
                       a.time
                FROM appointments a
                JOIN customers c
                ON a.customer_id = c.customer_id
                JOIN services s
                ON a.service_id = s.service_id";

                MySqlDataAdapter adapter =
                new MySqlDataAdapter(query, conn);

                adapter.Fill(table);
            }

            return table;
        }

        // Delete appointment
        public void DeleteAppointment(int id)
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                string query =
                "DELETE FROM appointments WHERE appointment_id=@id";

                MySqlCommand cmd =
                new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}