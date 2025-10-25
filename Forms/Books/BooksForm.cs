
using LMS.Forms.Books;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace LMS
{
    public partial class BooksForm : Form
    {
        private Staff loggedInStaff;
        private int row_selected = -1;

        public BooksForm(Staff staff)
        {
            InitializeComponent();
            loggedInStaff = staff;
            LoadBooks();


            txtISBN.Enabled = false;
            txtAvailableQuantity.Enabled = false; // Disable Available Quantity textbox for manual editing

            if (loggedInStaff.Role != "Admin")
            {
                btnDelete.Enabled = false; // Disable delete button for non-admin users
            }
        }


        // handle LoadBook to show book data on datagrid view
        private void LoadBooks()
        {
            try
            {
                // call static class of Connection that have members GetBooks()
                var books = Books.GetBooks(); 

                // store books data in dgvBooks (DataGridView for Books)
                dgvBooks.DataSource = books;
       
                // call configuration to setup style for datagridview
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        // cconfiguration for datagrid veiw
        private void ConfigureDataGridView()
        {
            // Optional: Customize column headers and visibility
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Automatically generate columns based on Book properties

            if (dgvBooks.Columns.Count > 0)
            {

                if (dgvBooks.Columns["BookID"] != null) dgvBooks.Columns["BookID"].HeaderText = "Book ID";
                if (dgvBooks.Columns["ISBN"] != null) dgvBooks.Columns["ISBN"].HeaderText = "ISBN";
                if (dgvBooks.Columns["Title"] != null) dgvBooks.Columns["Title"].HeaderText = "Book Title";
                if (dgvBooks.Columns["Author"] != null) dgvBooks.Columns["Author"].HeaderText = "Author";
                if (dgvBooks.Columns["Publisher"] != null) dgvBooks.Columns["Publisher"].HeaderText = "Publisher";
                if (dgvBooks.Columns["PublishedYear"] != null) dgvBooks.Columns["PublishedYear"].HeaderText = "Published Year";
                if (dgvBooks.Columns["Category"] != null) dgvBooks.Columns["Category"].HeaderText = "Category";
                if (dgvBooks.Columns["Quantity"] != null) dgvBooks.Columns["Quantity"].HeaderText = "Total Quantity";
                if (dgvBooks.Columns["AvailableQuantity"] != null) dgvBooks.Columns["AvailableQuantity"].HeaderText = "Available Quantity";
                if (dgvBooks.Columns["CreatedAt"] != null) dgvBooks.Columns["CreatedAt"].HeaderText = "Created At";
                
                // if (dgvBooks.Columns["CreatedAt"] != null) dgvBooks.Columns["CreatedAt"].Visible = false;
            }
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.MultiSelect = false;
        }


        // handle OnChange to update data when database change 
        public void OnChange(object caller, SqlNotificationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                dgvBooks.BeginInvoke(new MethodInvoker(LoadBooks));
            }
            else
            {
                LoadBooks();
            }
        }

        // btn save book (one by one) into the database (INSERT) 
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtISBN.Text != "" ) 
                {
                    var newBook = new Book
                    {
                        ISBN = string.IsNullOrWhiteSpace(txtISBN.Text) ? null : txtISBN.Text,
                        Title = string.IsNullOrWhiteSpace(txtTitle.Text) ? null : txtTitle.Text,
                        Author = string.IsNullOrWhiteSpace(txtAuthor.Text) ? null : txtAuthor.Text,
                        Publisher = string.IsNullOrWhiteSpace(txtPublisher.Text) ? null : txtPublisher.Text,
                        //PublishedYear = int.TryParse(numYear.Value.ToString(), out int year) ? (int?)year : null,
                        PublishedYear = int.TryParse(numYear.Text, out int year) ? (int?)year : 0,
                        Category = string.IsNullOrWhiteSpace(txtCategory.Text) ? null : txtCategory.Text,
                        Quantity = int.TryParse(numQty.Text, out int qty) ? qty : 0,
                        AvailableQuantity = int.TryParse(txtAvailableQuantity.Text, out int availQty) ? availQty : 0,
                        CreatedAt = Convert.ToDateTime(dobCreatedAt.Value),
                    };
                    Books.AddBook(newBook);
                    MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks(); // Refresh the book list
                } else
                {
                    MessageBox.Show("ISBN is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // btn Delete book from database
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBooks.SelectedRows.Count == 0) return;
                int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["BookID"].Value);
                Books.DeleteBook(bookId);
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // btn edit/update book (UPDATE)
        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtISBN.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtPublisher.Clear();
            numYear.Clear();
            txtCategory.Clear();
            numQty.Clear();
            txtAvailableQuantity.Clear();
            dobCreatedAt.Value = DateTime.Now;
            row_selected = -1; // Reset selected row index
            btnSave.Text = "Add New";


            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row_selected = e.RowIndex;
            try
            {
                if (row_selected < 0) return; // Header clicked
                DataGridViewRow row = dgvBooks.Rows[row_selected];
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
                txtISBN.Text = row.Cells["ISBN"].Value?.ToString() ?? "";
                txtTitle.Text = row.Cells["Title"].Value?.ToString() ?? "";
                txtAuthor.Text = row.Cells["Author"].Value?.ToString() ?? "";
                txtPublisher.Text = row.Cells["Publisher"].Value?.ToString() ?? "";
                numYear.Text = row.Cells["PublishedYear"].Value?.ToString() ?? "";
                txtCategory.Text = row.Cells["Category"].Value?.ToString() ?? "";
                numQty.Text = row.Cells["Quantity"].Value?.ToString() ?? "";
                txtAvailableQuantity.Text = row.Cells["AvailableQuantity"].Value?.ToString() ?? "";
                //dobCreatedAt.Value = Convert.ToDateTime(row.Cells["CreatedAt"].Value);
                dobCreatedAt.Value = row.Cells["CreatedAt"].Value != null && row.Cells["CreatedAt"].Value != DBNull.Value
                    ? Convert.ToDateTime(row.Cells["CreatedAt"].Value)
                    : DateTime.Now;


                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }







        // handle searchbox to search with ID and Name




}