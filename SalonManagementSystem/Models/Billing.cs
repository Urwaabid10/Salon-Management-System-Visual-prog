using System.Data;
using MySql.Data.MySqlClient;
using SalonManagementSystem.Database;

namespace SalonManagementSystem.Models
{
    // Model acts as bridge between Form and DB layer
    public class Billing
    {
        private BillingDB db = new BillingDB();

        // Load appointments
        public DataTable LoadAppointments()
        {
            return db.GetAppointments();
        }

        // Get bill details
        public MySqlDataReader GetDetails(MySqlConnection conn, int appointmentId)
        {
            return db.GetBillDetails(conn, appointmentId);
        }

        // Insert bill
        public void CreateBill(int appointmentId, string total)
        {
            db.InsertBill(appointmentId, total);
        }
    }
}