using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class StaffsForm : Form
    {
        private Staff loggedInStaff;
        private int row_selected = -1;
        public StaffsForm(Staff staff)
        {
            InitializeComponent();
            loggedInStaff = staff;

            // Optimize layout rendering
            this.SuspendLayout();

            txtPass.UseSystemPasswordChar = true;
            txtSID.Enabled = false;

            LoadStaffs();

            if (loggedInStaff.Role != "Admin")
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
            }

            // handle show password checkbox
            txtPass.Enabled = false;
            chPass.CheckedChanged += (s, e) =>
            {
                txtPass.UseSystemPasswordChar = !chPass.Checked;
                if (chPass.Checked)
                {
                    txtPass.Enabled = true;
                }
                else
                {
                    txtPass.Enabled = false;
                }
            };


            this.ResumeLayout();
        }

        private void LoadStaffs()
        {
            try
            {
                // call static class of Connection that have members GetBooks()
                var staffs = Staffs.GetStaff();
                // store books data in dgvBooks (DataGridView for Books)
                dgvStaff.DataSource = staffs;
                // call configuration to setup style for datagridview
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading staffs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            // Optional: Customize column headers and visibility
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Automatically generate columns based on Book properties

            if( dgvStaff.Columns.Count > 0)
            {
                if (dgvStaff.Columns["StaffID"] != null) dgvStaff.Columns["StaffID"].HeaderText = "Staff ID";
                if (dgvStaff.Columns["FullName"] != null) dgvStaff.Columns["FullName"].HeaderText = "Full Name";
                if (dgvStaff.Columns["Email"] != null) dgvStaff.Columns["Email"].HeaderText = "Email";
                if (dgvStaff.Columns["Phone"] != null) dgvStaff.Columns["Phone"].HeaderText = "Phone";
                if (dgvStaff.Columns["Username"] != null) dgvStaff.Columns["Username"].HeaderText = "Username";

                if (dgvStaff.Columns["Password"] != null) dgvStaff.Columns["Password"].HeaderText = "Password";
                // Hide password column for security
                dgvStaff.Columns["Password"].Visible = false;

                if (dgvStaff.Columns["Role"] != null) dgvStaff.Columns["Role"].HeaderText = "Role";
                if (dgvStaff.Columns["CreatedAt"] != null) dgvStaff.Columns["CreatedAt"].HeaderText = "Created At";
            }

            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.AllowUserToDeleteRows = false;
            dgvStaff.ReadOnly = true;
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStaff.MultiSelect = false;


        }



        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row_selected = e.RowIndex;
            try
            {
                if (row_selected < 0) return; // Header clicked
                DataGridViewRow row = dgvStaff.Rows[row_selected];
                bool isRowEmpty = true;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value != DBNull.Value && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        isRowEmpty = false;
                        break;
                    }
                }
                if (isRowEmpty)
                {
                    MessageBox.Show("This row is empty.");
                    return;
                }
                // Safe to proceed

                txtSID.Text = row.Cells["StaffID"].Value?.ToString() ?? "";
                txtFN.Text = row.Cells["FullName"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                txtUser.Text = row.Cells["Username"].Value?.ToString() ?? "";
                txtPass.Text = row.Cells["Password"].Value?.ToString() ?? "";

                cbRole.SelectedValue = row.Cells["Role"].Value?.ToString() ?? "";


                //dobCreatedAt.Value = Convert.ToDateTime(row.Cells["CreatedAt"].Value);
                dobCreatedAt.Value = row.Cells["CreatedAt"].Value != null && row.Cells["CreatedAt"].Value != DBNull.Value
                    ? Convert.ToDateTime(row.Cells["CreatedAt"].Value)
                    : DateTime.Now;
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                txtPass.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving staff: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ClearFields();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating staff: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting staff: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ClearFields();
            }
        }


        private void ClearFields()
        {
            txtSID.Clear();
            txtFN.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtUser.Clear();
            txtPass.Clear();
            cbRole.SelectedIndex = -1;

            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching staff: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
