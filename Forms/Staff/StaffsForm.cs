using LMS.Forms.Books;
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

            MessageBox.Show($"Logged in as: {loggedInStaff.StaffID} | {loggedInStaff.Username} ({loggedInStaff.Role})", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Optimize layout rendering
            this.SuspendLayout();

            txtPass.UseSystemPasswordChar = true;
            txtSID.Enabled = false;

            LoadStaffs();
            LoadRoles();

            if (loggedInStaff.Role != "Admin")
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
            }

            // Handle show password checkbox
            txtPass.Enabled = false;
            chPass.CheckedChanged += (s, e) =>
            {
                txtPass.UseSystemPasswordChar = !chPass.Checked;
                //txtPass.Enabled = chPass.Checked;
            };

            this.ResumeLayout();
        }

        // ===================== LOAD METHODS =====================
        private void LoadRoles()
        {
            // Define available roles (you can modify these)
            var roles = new List<string> { "Admin", "Librarian", "Assistant", "Staff" };
            cbRole.DataSource = roles;
            cbRole.SelectedIndex = -1;
        }

        private void LoadStaffs()
        {
            try
            {
                var staffs = Staffs.GetStaff();
                dgvStaff.DataSource = staffs;
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading staffs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvStaff.Columns.Count > 0)
            {
                if (dgvStaff.Columns["StaffID"] != null) dgvStaff.Columns["StaffID"].HeaderText = "Staff ID";
                if (dgvStaff.Columns["FullName"] != null) dgvStaff.Columns["FullName"].HeaderText = "Full Name";
                if (dgvStaff.Columns["Email"] != null) dgvStaff.Columns["Email"].HeaderText = "Email";
                if (dgvStaff.Columns["Phone"] != null) dgvStaff.Columns["Phone"].HeaderText = "Phone";
                if (dgvStaff.Columns["Username"] != null) dgvStaff.Columns["Username"].HeaderText = "Username";

                if (dgvStaff.Columns["Password"] != null)
                {
                    dgvStaff.Columns["Password"].HeaderText = "Password";
                    dgvStaff.Columns["Password"].Visible = false;
                }

                if (dgvStaff.Columns["Role"] != null) dgvStaff.Columns["Role"].HeaderText = "Role";
                if (dgvStaff.Columns["CreatedAt"] != null) dgvStaff.Columns["CreatedAt"].HeaderText = "Created At";
            }

            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.AllowUserToDeleteRows = false;
            dgvStaff.ReadOnly = true;
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStaff.MultiSelect = false;
        }

        // ===================== GRID CLICK =====================
        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row_selected = e.RowIndex;
            try
            {
                if (row_selected < 0) return; // header clicked

                DataGridViewRow row = dgvStaff.Rows[row_selected];
                if (row == null || row.Cells["StaffID"].Value == null) return;

                txtSID.Text = row.Cells["StaffID"].Value?.ToString() ?? "";
                txtFN.Text = row.Cells["FullName"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                txtUser.Text = row.Cells["Username"].Value?.ToString() ?? "";
                txtPass.Text = row.Cells["Password"].Value?.ToString() ?? "";

                cbRole.SelectedItem = row.Cells["Role"].Value?.ToString();

                dobCreatedAt.Value = row.Cells["CreatedAt"].Value != null && row.Cells["CreatedAt"].Value != DBNull.Value
                    ? Convert.ToDateTime(row.Cells["CreatedAt"].Value)
                    : DateTime.Now;

                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = loggedInStaff.Role == "Admin";
                txtPass.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting staff: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== BUTTON EVENTS =====================
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFN.Text != "" && txtEmail.Text != "" && txtUser.Text != "" && txtPass.Text != "" && cbRole.SelectedIndex != -1)
                {
                    var newStaff = new Staff
                    {
                        FullName = txtFN.Text,
                        Email = txtEmail.Text,
                        Phone = txtPhone.Text,
                        Username = txtUser.Text,
                        Password = txtPass.Text,
                        Role = cbRole.SelectedItem.ToString(),
                        //CreatedAt = dobCreatedAt.Value
                    };

                    Staffs.AddStaff(newStaff);
                    MessageBox.Show("Staff added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStaffs();
                }
                else
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                if (string.IsNullOrWhiteSpace(txtSID.Text))
                {
                    MessageBox.Show("Please select a staff record to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var updatedStaff = new Staff
                {
                    StaffID = Convert.ToInt32(txtSID.Text),
                    FullName = txtFN.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Username = txtUser.Text,
                    Password = txtPass.Text,
                    Role = cbRole.SelectedItem?.ToString() ?? "",
                    //CreatedAt = dobCreatedAt.Value
                };

                Staffs.UpdateStaff(updatedStaff);

                MessageBox.Show("Staff updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStaffs();
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
                if (dgvStaff.SelectedRows.Count == 0) return;

                int staff_id = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells["StaffID"].Value);

                var confirm = MessageBox.Show("Are you sure you want to delete this staff?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    Staffs.DeleteStaff(staff_id);
                    LoadStaffs();
                }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();

                if (string.IsNullOrEmpty(keyword))
                {
                    LoadStaffs();
                    return;
                }

                var staffs = Staffs.GetStaff();
                //var filtered = staffs
                //    .Where(s =>
                //        s.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                //        s.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                //        s.Username.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                //    .ToList();

                var filtered = staffs
                    .Where(s =>
                        (!string.IsNullOrEmpty(s.FullName) && s.FullName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (!string.IsNullOrEmpty(s.Email) && s.Email.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (!string.IsNullOrEmpty(s.Username) && s.Username.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0))
                    .ToList();

                dgvStaff.DataSource = filtered;
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

        // ===================== HELPERS =====================
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
            btnDelete.Enabled = loggedInStaff.Role == "Admin";
        }
    }
}
