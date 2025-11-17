using System;
using System.Windows.Forms;

namespace LMS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StaffClass s = new StaffClass
            {
                StaffID = 3,
                FullName = "Vang Sokchheng",
                Username = "sokchheng",
                Password = "123",
                Role = "Admin"
            };

            Application.Run(new LMS_FORM(s));
            //Application.Run(new SplashScreen());
        }
    }
}
