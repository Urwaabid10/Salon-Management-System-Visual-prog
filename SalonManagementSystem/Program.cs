using System;
using System.Windows.Forms;
using SalonManagementSystem.Forms;

namespace SalonManagementSystem
{
    internal static class Program
    {
        // The main entry point for the application.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start application with Login Form
            Application.Run(new LoginForm());
        }
    }
}