using System.Data;
using SalonManagementSystem.Database;

namespace SalonManagementSystem.Models
{
    // Model acts as middle layer between Form and DB
    public class Service
    {
        private ServicesDB db = new ServicesDB();

        // Get all services
        public DataTable GetServices()
        {
            return db.GetAllServices();
        }

        // Add service
        public void Add(string name, string price)
        {
            db.InsertService(name, price);
        }

        // Update service
        public void Update(int id, string name, string price)
        {
            db.UpdateService(id, name, price);
        }

        // Delete service
        public void Delete(int id)
        {
            db.DeleteService(id);
        }
    }
}