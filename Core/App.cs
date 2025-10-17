using LMS.Class;
using LMS.Forms.Staff;

//using LMS.Controls.BookControl;
using LMS.Forms.Welcome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class LMS_FORM : Form
    {

        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        private Panel contentPanel;
        private Staff loggedInStaff;
        private String APP_NAME_SHORT = "LMS";
        private String APP_NAME_LONG = "Library Management System";


        public LMS_FORM(Staff staff)
        {
            InitializeComponent();
            //this.ControlBox = false;
            
            // Optimize layout rendering
            this.SuspendLayout();


            loggedInStaff = staff;

            // 🔹 Example of role-based access
            if (loggedInStaff.Role == "Admin")
            {
                // Admin can access everything
                btnBook.Enabled = true;
                btnBRW_RTN.Enabled = true;
                btnStaffs.Enabled = true;
            }
            else if (loggedInStaff.Role == "Librarian")
            {
                // Librarian can access borrow/return but not book management
                btnBook.Enabled = true;
                btnBRW_RTN.Enabled = true;
                btnStaffs.Enabled = false;
            }
            else
            {
                // Other roles — limited
                btnBook.Enabled = false;
                btnBRW_RTN.Enabled = false;
                btnStaffs.Enabled = false;
            }
        }


        private void LMS_FORM_Load(object sender, EventArgs e)
        {
            this.Text = $"{APP_NAME_SHORT} - {loggedInStaff.FullName} [{loggedInStaff.Role}] - {DateTime.Now.ToString()}";
            //this.Tag = $"Library Management System";
            //lblWelcome.Text = $"{loggedInStaff.FullName} [{loggedInStaff.Role}]";

            btnHome_Click(btnHome, EventArgs.Empty);
        }


        // handle form resizing to adjust sidebar height
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            panelMenu.Height = this.Height;
            panelMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;

        }


        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.Gray;
                    currentButton.ForeColor = Color.White;
                }
            }
        }


        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu_sidbar.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.DarkGray;
                    previousBtn.ForeColor = Color.White;
                }
            }
        }


        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null) activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.AutoScroll = true;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Welcome(), sender);
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BooksForm(loggedInStaff), sender);
        }

        private void btnBRW_RTN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BorrowReturnForm(loggedInStaff), sender);
        }

        private void btnStaffs_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StaffsForm(), sender);
        }
    }
}
