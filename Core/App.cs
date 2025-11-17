using LMS.Forms.Welcome;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LMS
{
    public partial class LMS_FORM : Form
    {
        // ===========================
        // 🔹 Fields
        // ===========================
        private Form activeForm;
        private Button currentButton;
        private readonly StaffClass loggedInStaff;
        private const string APP_NAME_SHORT = "LMS";

        // ===========================
        // 🔹 Constructor
        // ===========================
        public LMS_FORM(StaffClass staff)
        {
            InitializeComponent();
            loggedInStaff = staff ?? throw new ArgumentNullException(nameof(staff));

            // Prevent flickering during layout setup
            SuspendLayout();
            ConfigureRoleAccess();
            ResumeLayout();
        }

        // ===========================
        // 🔹 Event Handlers
        // ===========================
        private void LMS_FORM_Load(object sender, EventArgs e)
        {
            Text = $"{APP_NAME_SHORT} - [ID: {loggedInStaff.StaffID} | " +
                   $"Name: {loggedInStaff.FullName} | Role: {loggedInStaff.Role}] " + 
                   $"- {DateTime.Now}";

            // Load default form
            LMS_FORM_SizeChanged(sender, e);
            btnHome_Click(btnHome, EventArgs.Empty);
        }

        private void LMS_FORM_SizeChanged(object sender, EventArgs e)
        {
            CenterTitle();
        }
        private void LMS_FORM_Shown(object sender, EventArgs e)
        {
            CenterTitle();
        }
        private void CenterTitle()
        {
            lblTitle.AutoSize = true;
            lblTitle.Left = (panelTitleBar.ClientSize.Width - lblTitle.Width) / 2;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            panelMenu.Height = Height;
            panelMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        }

        // ===========================
        // 🔹 UI Configuration
        // ===========================
        private void ConfigureRoleAccess()
        {
            // Default: disable all
            btnBook.Enabled = false;
            btnBRW_RTN.Enabled = false;
            btnStaffs.Enabled = false;

            switch (loggedInStaff.Role)
            {
                case "Admin":
                    btnBook.Enabled = true;
                    btnBRW_RTN.Enabled = true;
                    btnStaffs.Enabled = true;
                    break;

                case "Librarian":
                    btnBook.Enabled = true;
                    btnBRW_RTN.Enabled = true;
                    break;
            }
        }

        // ===========================
        // 🔹 Navigation Helpers
        // ===========================
        private void ActivateButton(object sender)
        {
            //if (sender is not Button clickedButton || clickedButton == currentButton)
            //    return;

            if (!(sender is Button))
                return;

            var clickedButton = (Button)sender;
            if (clickedButton == currentButton)
                return;

            ResetButtonStyles();
            currentButton = clickedButton;
            currentButton.BackColor = System.Drawing.Color.DarkBlue;
            currentButton.ForeColor = Color.White;
        }

        private void ResetButtonStyles()
        {
            foreach (Control control in panelMenu_sidbar.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = System.Drawing.Color.SteelBlue;
                    button.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        private void OpenChildForm(Form childForm, object sender)
        {
            activeForm?.Close();
            ActivateButton(sender);

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.AutoScroll = true;
            childForm.Dock = DockStyle.Fill;

            panelDesktopPane.Controls.Clear();
            panelDesktopPane.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();

            lblTitle.Text = childForm.Text;
            CenterTitle();
        }

        // ===========================
        // 🔹 Button Events
        // ===========================
        private void btnHome_Click(object sender, EventArgs e)
            => OpenChildForm(new Welcome(), sender);

        private void btnBook_Click(object sender, EventArgs e)
            => OpenChildForm(new BooksForm(loggedInStaff), sender);

        private void btnBRW_RTN_Click(object sender, EventArgs e)
            => OpenChildForm(new BorrowReturnForm(loggedInStaff), sender);

        private void btnStaffs_Click(object sender, EventArgs e)
            => OpenChildForm(new StaffsForm(loggedInStaff), sender);


    }
}
