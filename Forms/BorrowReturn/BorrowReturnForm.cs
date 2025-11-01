using LMS.Forms.Books;
using LMS.Forms.BorrowReturn;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LMS
{
    public partial class BorrowReturnForm : Form
    {
        // ===========================
        // 🔹 Fields
        // ===========================
        private int selectedTransactionId;
        private readonly StaffClass currentStaff;

        // ===========================
        // 🔹 Constructor
        // ===========================
        public BorrowReturnForm(StaffClass staff)
        {
            InitializeComponent();
            currentStaff = staff;

            LoadBooks();
            LoadBorrowers();

            SetupUI();
            SetupEventHandlers();

            lblStaffName.Text = $"Staff: {currentStaff.FullName}, Role: {currentStaff.Role}";
        }

        // ===================== INITIAL SETUP =====================
        private void SetupUI()
        {
            txtTID.Enabled = false;
            txtStatus.Enabled = false;
            txtBContact.Enabled = false;
            btnReturn.Enabled = false;
        }

        private void SetupEventHandlers()
        {
            cbx_contact_check.CheckedChanged += (s, e) =>
                txtBContact.Enabled = cbx_contact_check.Checked;
        }

        // ===================== LOAD BOOKS =====================
        private void LoadBooks()
        {
            try
            {
                using (var conn = Connection.GetConn())
                using (var cmd = new SqlCommand("SELECT BookID, Title FROM Books WHERE AvailableQuantity > 0", conn))
                {
                    conn.Open();
                    var dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    cbBook.DataSource = dt;
                    cbBook.DisplayMember = "Title";
                    cbBook.ValueMember = "BookID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BorrowReturnForm_Load(object sender, EventArgs e)
        {
            rbtnAll.Checked = true; // shows all borrowers on start
        }

        // ===================== LOAD BORROWERS =====================
        private void LoadBorrowers(string status = null)
        {
            try
            {
                dgvBorrower.DataSource = Borrowers.GetBorrowRecords(status);
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading borrow records: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== SQL CHANGE HANDLER =====================
        public void OnChange(object sender, SqlNotificationEventArgs e)
        {
            // Determine current filter based on which radio button is checked
            string status = null;

            if (rbtnBorrowed.Checked)
                status = "Borrowed";
            else if (rbtnReturned.Checked)
                status = "Returned";
            else if (rbtnAll.Checked)
                status = null; // show all

            // Refresh UI safely from the correct thread
            if (InvokeRequired)
                dgvBorrower.BeginInvoke(new MethodInvoker(() => LoadBorrowers(status)));
            else
                LoadBorrowers(status);


            //string status = rbtnBorrowed.Checked ? "Borrowed" :
            //                rbtnReturned.Checked ? "Returned" : null;

            //if (InvokeRequired)
            //    dgvBorrower.BeginInvoke(new MethodInvoker(() => LoadBorrowers(status)));
            //else
            //    LoadBorrowers(status);
        }


        // ===================== CONFIGURE GRID =====================
        private void ConfigureDataGridView()
        {
            dgvBorrower.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBorrower.ReadOnly = true;
            dgvBorrower.MultiSelect = false;
            dgvBorrower.AllowUserToAddRows = false;
            dgvBorrower.AllowUserToDeleteRows = false;
            dgvBorrower.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvBorrower.Columns.Count == 0) return;

            // Unified rename helper
            Action<string, string> Rename = (col, header) =>
            {
                if (dgvBorrower.Columns[col] != null)
                    dgvBorrower.Columns[col].HeaderText = header;
            };

            // Hide unnecessary columns
            if (dgvBorrower.Columns["BookID"] != null) dgvBorrower.Columns["BookID"].Visible = false;
            if (dgvBorrower.Columns["StaffID"] != null) dgvBorrower.Columns["StaffID"].Visible = false;
            if (dgvBorrower.Columns["TransactionID"] != null) dgvBorrower.Columns["TransactionID"].Visible = false;

            Rename("BookTitle", "Title");
            Rename("BorrowerName", "Borrower");
            Rename("BorrowerContact", "Contact");
            Rename("BorrowDate", "Borrow Date");
            Rename("DueDate", "Due Date");
            Rename("ReturnDate", "Return Date");
            Rename("StaffName", "Handled By");
            Rename("Status", "Status");
        }


        // ===================== GRID CLICK =====================
        private void dgvBorrower_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvBorrower.Rows.Count) return;

            try
            {
                var row = dgvBorrower.Rows[e.RowIndex];

                selectedTransactionId = Convert.ToInt32(row.Cells["TransactionID"].Value);
                txtTID.Text = selectedTransactionId.ToString();
                txtBorrowerName.Text = row.Cells["BorrowerName"].Value?.ToString() ?? "";
                txtBContact.Text = row.Cells["BorrowerContact"].Value?.ToString() ?? "";
                txtStatus.Text = row.Cells["Status"].Value?.ToString() ?? "";
                dtpBorrowDate.Value = Convert.ToDateTime(row.Cells["BorrowDate"].Value);

                string title = row.Cells["BookTitle"].Value?.ToString() ?? "";
                int index = cbBook.FindStringExact(title);
                if (index >= 0) cbBook.SelectedIndex = index;

                btnBorrow.Enabled = false;
                btnReturn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== BORROW BUTTON =====================
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbBook.SelectedValue == null || string.IsNullOrWhiteSpace(txtBorrowerName.Text))
                {
                    MessageBox.Show("Please select a book and enter the borrower name.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int bookId = Convert.ToInt32(cbBook.SelectedValue);
                string borrowerName = txtBorrowerName.Text.Trim();
                string borrowerContact = "";

                if (txtBContact.Text != "")
                {
                    borrowerContact = txtBContact.Text.Trim();
                }

                DateTime dueDate = dtpBorrowDate.Value;
                int staffId = currentStaff.StaffID;

                Borrowers.BorrowBook(bookId, borrowerName, borrowerContact, dueDate, staffId);

                MessageBox.Show("Book borrowed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBorrowers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error borrowing book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ClearForm();
            }
        }

        // ===================== RETURN BUTTON =====================
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (selectedTransactionId == 0)
            {
                MessageBox.Show("Please select a record to return.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to mark this book as returned?",
                "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    Borrowers.ReturnBook(selectedTransactionId);
                    MessageBox.Show("Book returned successfully ✅", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBorrowers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error returning book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ClearForm();
                }
            }
        }

        // ===================== CLEAR / SEARCH =====================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadBorrowers();
        }

        private void ClearForm()
        {
            selectedTransactionId = 0;
            txtTID.Clear();
            txtBorrowerName.Clear();
            txtBContact.Clear();
            txtStatus.Clear();
            cbBook.SelectedIndex = -1;
            dtpBorrowDate.Value = DateTime.Now;
            txtSearch.Clear();

            btnBorrow.Enabled = true;
            btnReturn.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadBorrowers();
                    return;
                }

                var borrowers = Borrowers.GetBorrowRecords();
                var filtered = borrowers.FindAll(b =>
                    (b.BorrowerName?.ToLower().Contains(keyword) ?? false) ||
                    (b.BookTitle?.ToLower().Contains(keyword) ?? false) ||
                    (b.Status?.ToLower().Contains(keyword) ?? false));

                dgvBorrower.DataSource = filtered;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching records: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnBorrowed_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBorrowed.Checked)
                LoadBorrowers("Borrowed");
        }

        private void rbtnReturned_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnReturned.Checked)
                LoadBorrowers("Returned");
        }

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAll.Checked)
                LoadBorrowers(); // NULL → show all
        }

        
    }
}
