using LMS.Forms.Books;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LMS
{
    public partial class StaffsForm : Form
    {
        private readonly Staff loggedInStaff;
        private int row_selected = -1;

        public StaffsForm(Staff staff)
        {
            InitializeComponent();
            loggedInStaff = staff ?? throw new ArgumentNullException(nameof(staff));

            LoadStaffs();

            // Initialize button states
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            // Show/Hide password toggle
            txtPass.UseSystemPasswordChar = true;
            chPass.CheckedChanged += (s, e) =>
                txtPass.UseSystemPasswordChar = !chPass.Checked;
        }

        #region === Load & Configure Grid ===
        private void LoadStaffs()
        {
            try
            {
                dgvStaff.DataSource = Staffs.GetStaff();
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                ShowError("Error loading staffs", ex);
            }
        }

        // ===================== CONFIGURE GRID =====================
        private void ConfigureDataGridView()
        {
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStaff.ReadOnly = true;
            dgvStaff.MultiSelect = false;
            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.AllowUserToDeleteRows = false;
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvStaff.Columns.Count == 0) return;

            // Same inline rename helper for consistency
            Action<string, string> Rename = (col, header) =>
            {
                if (dgvStaff.Columns[col] != null)
                    dgvStaff.Columns[col].HeaderText = header;
            };

            Rename("StaffID", "Staff ID");
            Rename("FullName", "Full Name");
            Rename("Email", "Email");
            Rename("Phone", "Phone");
            Rename("Username", "Username");
            Rename("Role", "Role");
            Rename("CreatedAt", "Created At");
        }

        #endregion

        #region === Grid Row Selection ===
        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row_selected = e.RowIndex;
            if (row_selected < 0) return; // Ignore header click

            try
            {
                DataGridViewRow row = dgvStaff.Rows[row_selected];
                if (row == null || row.Cells["StaffID"].Value == null) return;

                txtSID.Text = row.Cells["StaffID"].Value?.ToString() ?? "";
                txtFN.Text = row.Cells["FullName"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                txtUser.Text = row.Cells["Username"].Value?.ToString() ?? "";
                txtPass.Text = row.Cells["Password"].Value?.ToString() ?? "";
                txtRole.Text = row.Cells["Role"].Value?.ToString() ?? "";

                if (row.Cells["CreatedAt"].Value != null && row.Cells["CreatedAt"].Value != DBNull.Value)
                    dobCreatedAt.Value = Convert.ToDateTime(row.Cells["CreatedAt"].Value);
                else
                    dobCreatedAt.Value = DateTime.Now;

                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                txtPass.Enabled = true;
                lbSAcc.Text = "Staff Account";
            }
            catch (Exception ex)
            {
                ShowError("Error selecting staff", ex);
            }
        }
        #endregion

        #region === Save / Update / Delete ===
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateFields()) return;

                var newStaff = new Staff
                {
                    FullName = txtFN.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Username = txtUser.Text,
                    Password = txtPass.Text,
                    Role = txtRole.Text
                };

                Staffs.AddStaff(newStaff);
                MessageBox.Show("Staff added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStaffs();
            }
            catch (Exception ex)
            {
                ShowError("Error saving staff", ex);
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
                    Role = txtRole.Text
                };

                Staffs.UpdateStaff(updatedStaff);
                MessageBox.Show("Staff updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStaffs();
            }
            catch (Exception ex)
            {
                ShowError("Error updating staff", ex);
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

                int staffId = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells["StaffID"].Value);
                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete this staff?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    Staffs.DeleteStaff(staffId);
                    LoadStaffs();
                }
            }
            catch (Exception ex)
            {
                ShowError("Error deleting staff", ex);
            }
            finally
            {
                ClearFields();
            }
        }
        #endregion

        #region === Search & Clear ===
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
                var filtered = staffs.Where(s =>
                    (!string.IsNullOrEmpty(s.FullName) && s.FullName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(s.Email) && s.Email.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(s.Username) && s.Username.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0))
                    .ToList();

                dgvStaff.DataSource = filtered;
            }
            catch (Exception ex)
            {
                ShowError("Error searching staff", ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            ClearSearchData();
        }

        private void ClearFields()
        {
            txtSID.Clear();
            txtFN.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtUser.Clear();
            txtPass.Clear();
            txtRole.Clear();

            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            lbSAcc.Text = "Make Staff Account";
        }

        private void ClearSearchData()
        {
            txtSearch.Clear();
            LoadStaffs();
        }
        #endregion

        #region === Helpers ===
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtFN.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUser.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) ||
                string.IsNullOrWhiteSpace(txtRole.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show($"{message}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void r1_Click(object sender, EventArgs e) => txtRole.Text = "Admin";
        private void r2_Click(object sender, EventArgs e) => txtRole.Text = "Librarian";
        #endregion
    }
}
