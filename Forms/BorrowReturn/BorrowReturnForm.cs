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
        private Staff currentStaff;
        private int lblBorrowID { set; get; }
        public BorrowReturnForm(Staff staff)
        {
            InitializeComponent();
            // Optimize layout rendering
            this.SuspendLayout();
            currentStaff = staff;

            LoadBorrower();
            LoadBooks();

            btnReturn.Enabled = false;
            txtStatus.Enabled = false;

            //txtStatus.Enabled = false;

            txtBorrowerContact.Enabled = false;
            cbx_contact_check.CheckedChanged += (s, e) =>
            {
                txtBorrowerContact.Enabled = !cbx_contact_check.Checked; // checked means enable textbox
                if (cbx_contact_check.Checked)
                {
                    txtBorrowerContact.Enabled = true;
                }
                else
                {
                    txtBorrowerContact.Enabled = false;
                }
            };

            txtTID.Enabled = false;
            lblStaffName.Text = $"Staff: {currentStaff.FullName}, Role: {currentStaff.Role}";
        }

        private void LoadBooks()
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

      

        // handle LoadBook to show book data on datagrid view
        private void LoadBorrower()
        {
            try
            {
                var borrows = Borrowers.GetBorrowRecords();
                dgvBorrower.DataSource = borrows;
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // handle OnChange to update or reload data when database change 
        public void OnChange(object caller, SqlNotificationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                dgvBorrower.BeginInvoke(new MethodInvoker(LoadBorrower));
            }
            else
            {
                LoadBorrower();
            }
        }


        private void ConfigureDataGridView()
        {
            // Set AutoSizeColumnsMode to Fill to make columns fill the DataGridView width
            dgvBorrower.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Optionally, you can set specific column widths if needed
            if (dgvBorrower.Columns.Count > 0)
            {
                dgvBorrower.Columns["TransactionID"].Visible = false;
                //dgvBorrower.Columns["BookID"].Visible = false;
                dgvBorrower.Columns["BookTitle"].HeaderText = "Title";
                dgvBorrower.Columns["BorrowerName"].HeaderText = "Borrower";
                dgvBorrower.Columns["BorrowDate"].HeaderText = "BorrowDate";
                dgvBorrower.Columns["DueDate"].HeaderText = "DueDate";
                dgvBorrower.Columns["ReturnDate"].HeaderText = "ReturnDate";
                dgvBorrower.Columns["StaffName"].HeaderText = "Handled By";
                dgvBorrower.Columns["Status"].HeaderText = "Status";
            }
            // Set other properties for better appearance
            dgvBorrower.AllowUserToAddRows = false;
            dgvBorrower.AllowUserToDeleteRows = false;
            dgvBorrower.ReadOnly = true;
            dgvBorrower.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBorrower.MultiSelect = false;
        }
        

        private void dgvBorrower_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvBorrower.Rows.Count) return;

                var selectedRow = dgvBorrower.Rows[e.RowIndex];
                txtTID.Text = selectedRow.Cells["TransactionID"].Value.ToString();
                txtBorrowerName.Text = selectedRow.Cells["BorrowerName"].Value.ToString();
                dtpBorrowDate.Value = Convert.ToDateTime(selectedRow.Cells["BorrowDate"].Value);
                txtStatus.Text = selectedRow.Cells["Status"].Value.ToString();
                string selectedBookTitle = selectedRow.Cells["BookTitle"].Value.ToString();
                int index = cbBook.FindStringExact(selectedBookTitle);
                if (index >= 0)
                {
                    cbBook.SelectedIndex = index;
                }
                cbBook.SelectedValue = selectedRow.Cells["BookID"].Value;

                string status = selectedRow.Cells["Status"].Value.ToString();
                //btnReturn.Enabled = status == "Borrowed";


                btnBorrow.Enabled = false;
                btnReturn.Enabled = true;

                //dtpDueDate.Value = Convert.ToDateTime(selectedRow.Cells["DueDate"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbBook.SelectedValue == null || string.IsNullOrWhiteSpace(txtBorrowerName.Text))
                {
                    MessageBox.Show("Please select a book and enter borrower name.");
                    return;
                }

                int bookId = Convert.ToInt32(cbBook.SelectedValue);
                string borrowerName = txtBorrowerName.Text.Trim();
                string borrowerContact = txtBorrowerContact.Text.Trim();
                DateTime dueDate = Convert.ToDateTime(dtpBorrowDate.Value);
                int staffId = currentStaff.StaffID;

                //MessageBox.Show($"{bookId},{borrowerName},{borrowerContact},{dueDate},{staffId}");

                Borrowers.BorrowBook(bookId, borrowerName, borrowerContact, dueDate, staffId);
                MessageBox.Show("Book borrowed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBorrower(); // refresh grid
                
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

        

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblBorrowID.ToString()))
            {
                MessageBox.Show("Please select a record to return.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to mark this book as returned?",
                "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                int transactionId = Convert.ToInt32(txtTID.Text);
                Borrowers.ReturnBook(transactionId);

                MessageBox.Show("Book returned successfully ✅");

                LoadBorrower();
                ClearForm();

            }
        }

        private void ClearForm()
        {
            lblBorrowID = 0;
            txtTID.Clear();
            txtBorrowerName.Clear();
            txtBorrowerContact.Clear();
            cbBook.SelectedIndex = -1;
            dtpBorrowDate.Value = DateTime.Now;
            //btnBorrow.Text = "Add New Borrower";

            btnBorrow.Enabled = true;
            btnReturn.Enabled = false;
            //dtpBorrowDate.Value = DateTime.Now;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }



        //private void btnBorrow_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnReturn_Click(object sender, EventArgs e)
        //{

        //}
    }
}
