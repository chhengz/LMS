
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
        private int book_id;
        public BooksForm(Staff staff)
        {
            InitializeComponent();
            this.SuspendLayout();
            loggedInStaff = staff;

            LoadBooks();
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            //txtAvailableQuantity.Enabled = false;
            this.ResumeLayout();
        }

        private void LoadBooks()
        {
            try
            {
                var books = Books.GetBooks(); 
                dgvBooks.DataSource = books;
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            dgvBooks.ReadOnly = true;
            dgvBooks.MultiSelect = false;
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

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

        // ===================== SAVE BUTTON =====================
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ( txtISBN.Text != "" && txtTitle.Text != "" && txtAuthor.Text != "" && txtCategory.Text != "" && txtPublisher.Text != "" && numQty.Text != "") 
                {
                    var newBook = new Book
                    {
                        ISBN = string.IsNullOrWhiteSpace(txtISBN.Text) ? null : txtISBN.Text,
                        Title = string.IsNullOrWhiteSpace(txtTitle.Text) ? null : txtTitle.Text,
                        Author = string.IsNullOrWhiteSpace(txtAuthor.Text) ? null : txtAuthor.Text,
                        Publisher = string.IsNullOrWhiteSpace(txtPublisher.Text) ? null : txtPublisher.Text,
                        PublishedYear = int.TryParse(numYear.Text, out int year) ? (int?)year : 0,
                        Category = string.IsNullOrWhiteSpace(txtCategory.Text) ? null : txtCategory.Text,
                        Quantity = int.TryParse(numQty.Text, out int qty) ? qty : 0,
                        AvailableQuantity = int.TryParse(txtAvailableQuantity.Text, out int availQty) ? availQty : 0,
                        CreatedAt = Convert.ToDateTime(dobCreatedAt.Value),
                    };
                    Books.AddBook(newBook);
                    MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks(); 
                } else
                {
                    MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ClearForm();
            }
        }

        // ===================== DELETE BUTTON =====================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBooks.SelectedRows.Count == 0) return;
                var re = MessageBox.Show("Are you sure you want to delete this book?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (re == DialogResult.Yes)
                {
                    int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["BookID"].Value);
                    Books.DeleteBook(bookId);
                }
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ClearForm();
            }
        }

        // ===================== UPDATE BUTTON =====================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (row_selected < 0) return; // No row selected
                var updatedBook = new Book
                {
                    BookID = book_id,
                    ISBN = string.IsNullOrWhiteSpace(txtISBN.Text) ? null : txtISBN.Text,
                    Title = string.IsNullOrWhiteSpace(txtTitle.Text) ? null : txtTitle.Text,
                    Author = string.IsNullOrWhiteSpace(txtAuthor.Text) ? null : txtAuthor.Text,
                    Publisher = string.IsNullOrWhiteSpace(txtPublisher.Text) ? null : txtPublisher.Text,
                    PublishedYear = int.TryParse(numYear.Text, out int year) ? (int?)year : 0,
                    Category = string.IsNullOrWhiteSpace(txtCategory.Text) ? null : txtCategory.Text,
                    Quantity = int.TryParse(numQty.Text, out int qty) ? qty : 0,
                    AvailableQuantity = int.TryParse(txtAvailableQuantity.Text, out int availQty) ? availQty : 0,
                    CreatedAt = Convert.ToDateTime(dobCreatedAt.Value),
                };

                Books.UpdateBook(updatedBook);
                MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBooks(); // Refresh the book list
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ClearForm();
            }
        }

       

        // ===================== GRID CLICK =====================
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

                book_id = Convert.ToInt32(row.Cells["BookID"].Value);
                txtISBN.Text = row.Cells["ISBN"].Value?.ToString() ?? "";
                txtTitle.Text = row.Cells["Title"].Value?.ToString() ?? "";
                txtAuthor.Text = row.Cells["Author"].Value?.ToString() ?? "";
                txtPublisher.Text = row.Cells["Publisher"].Value?.ToString() ?? "";
                numYear.Text = row.Cells["PublishedYear"].Value?.ToString() ?? "";
                txtCategory.Text = row.Cells["Category"].Value?.ToString() ?? "";
                numQty.Text = row.Cells["Quantity"].Value?.ToString() ?? "";
                txtAvailableQuantity.Text = row.Cells["AvailableQuantity"].Value?.ToString() ?? "";
                dobCreatedAt.Value = row.Cells["CreatedAt"].Value != null && row.Cells["CreatedAt"].Value != DBNull.Value
                    ? Convert.ToDateTime(row.Cells["CreatedAt"].Value)
                    : DateTime.Now;

                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = loggedInStaff.Role == "Admin";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ===================== SEARCH BUTTON =====================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadBooks();
                    return;
                }

                var books = Books.GetBooks();
                var filteredBooks = books.FindAll(b => (b.Title != null && b.Title.ToLower().Contains(keyword)) ||
                                                       (b.Author != null && b.Author.ToLower().Contains(keyword)) ||
                                                       (b.ISBN != null && b.ISBN.ToLower().Contains(keyword)) ||
                                                       (b.Category != null && b.Category.ToLower().Contains(keyword)) ||
                                                       (b.Publisher != null && b.Publisher.ToLower().Contains(keyword)));

                dgvBooks.DataSource = filteredBooks;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            ClearSearchData();
        }

        // ===================== CLEAR FIELDS =====================
        private void ClearForm()
        {
            numQty.Clear();
            txtISBN.Clear();
            numYear.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtCategory.Clear();
            txtPublisher.Clear();
            txtAvailableQuantity.Clear();
            dobCreatedAt.Value = DateTime.Now;
            row_selected = -1;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtSearch.Text = string.Empty;
            //btnDelete.Enabled = loggedInStaff.Role == "Admin";
        }

        private void ClearSearchData()
        {
            txtSearch.Text = string.Empty;
            LoadBooks();
        }
    }
    
}