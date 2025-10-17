using System;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class Login_form : Form
    {
        public Login_form()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
            txtPassword.UseSystemPasswordChar = true;

            // Optimize layout rendering
            this.SuspendLayout();

            cbxShowPass.CheckedChanged += (s, e) =>
            {
                txtPassword.UseSystemPasswordChar = !cbxShowPass.Checked;
                cbxShowPass.Text = cbxShowPass.Checked ? "Hide Password" : "Show Password";
            };

            this.ResumeLayout();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please enter both username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                var staff = await Staffs.GetStaffByLoginAsync(user, pass);

                if (staff != null)
                {
                    MessageBox.Show($"Login successful! Welcome, {staff.Username}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LMS_FORM mainForm = new LMS_FORM(staff);
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Show();

                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        public void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var re = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.Yes)
                Application.Exit();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Login_form_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

       
    }
}
