using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagementSystem.Models
{
    public class Customer
    {
        // Customer ID
        public int CustomerID { get; set; }

        // Customer name
        public string Name { get; set; }

        // Customer phone number
        public string Phone { get; set; }

        // Customer email
        public string Email { get; set; }
    }
}
