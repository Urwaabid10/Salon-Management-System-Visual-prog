using System;

namespace SalonManagementSystem.Models
{
    // Appointment model class
    public class Appointment
    {
        // Appointment ID
        public int AppointmentID { get; set; }

        // Customer ID
        public int CustomerID { get; set; }

        // Service ID
        public int ServiceID { get; set; }

        // Appointment date
        public DateTime Date { get; set; }

        // Appointment time
        public TimeSpan Time { get; set; }
    }
}