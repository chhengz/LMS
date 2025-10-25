using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Staff loggedInStaff = new Staff
            {
                StaffID = 2,
                FullName = "Admin",
                Role = "Admin" // "Admin", "Librarian", "User", etc.
            };
            //Application.Run(new Login_form());
            Application.Run(new LMS_FORM(loggedInStaff));
        }
    }
}
