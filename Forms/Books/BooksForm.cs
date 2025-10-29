using LMS.Forms.Books;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LMS
{
    public partial class BooksForm : Form
    {
        private readonly Staff loggedInStaff;
        private int selectedRowIndex = -1;
        private int selectedBookId;

        public BooksForm(Staff staff)
        {
            InitializeComponent();
            loggedInStaff = staff;

            LoadBooks();
            SetButtonState(isEditing: false);
        }

        // ===================== LOAD BOOKS =====================
        private void LoadBooks()
        {
            try
            {
                dgvBooks.DataSource = Books.GetBooks();
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== CONFIGURE GRID =====================
        private void ConfigureDataGridView()
        {
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.ReadOnly = true;
            dgvBooks.MultiSelect = false;
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Column headers
            void Rename(string col, string header)
            {
                if (dgvBooks.Columns[col] != null)
                    dgvBooks.Columns[col].HeaderText = header;
            }


            // Hide unnecessary columns
            if (dgvBooks.Columns["BookID"] != null) dgvBooks.Columns["BookID"].Visible = false;


            //Rename("BookID", "Book ID");
            Rename("ISBN", "ISBN");
            Rename("Title", "Book Title");
            Rename("Author", "Author");
            Rename("Publisher", "Publisher");
            Rename("PublishedYear", "Published Year");
            Rename("Category", "Category");
            Rename("Quantity", "Total Quantity");
            Rename("AvailableQuantity", "Available Quantity");
            Rename("CreatedAt", "Created At");
        }

        // ===================== SQL CHANGE EVENT =====================
        public void OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (InvokeRequired)
                dgvBooks.BeginInvoke(new MethodInvoker(LoadBooks));
            else
                LoadBooks();
        }

        // ===================== SAVE BUTTON =====================
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                {
                    MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newBook = CreateBookFromInputs();
                Books.AddBook(newBook);
                MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // ===================== DELETE BUTTON =====================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBooks.SelectedRows.Count == 0) return;

                var confirm = MessageBox.Show("Are you sure you want to delete this book?",
                    "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["BookID"].Value);
                    Books.DeleteBook(bookId);
                    MessageBox.Show("Book deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ClearForm();
            }
        }

        // ===================== EDIT BUTTON =====================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedRowIndex < 0) return;

                var updatedBook = CreateBookFromInputs();
                updatedBook.BookID = selectedBookId;

                Books.UpdateBook(updatedBook);
                MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBooks();
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
            selectedRowIndex = e.RowIndex;
            if (selectedRowIndex < 0) return; // header

            try
            {
                var row = dgvBooks.Rows[selectedRowIndex];
                if (IsRowEmpty(row))
                {
                    MessageBox.Show("This row is empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedBookId = Convert.ToInt32(row.Cells["BookID"].Value);
                txtISBN.Text = row.Cells["ISBN"].Value?.ToString() ?? "";
                txtTitle.Text = row.Cells["Title"].Value?.ToString() ?? "";
                txtAuthor.Text = row.Cells["Author"].Value?.ToString() ?? "";
                txtPublisher.Text = row.Cells["Publisher"].Value?.ToString() ?? "";
                numYear.Text = row.Cells["PublishedYear"].Value?.ToString() ?? "";
                txtCategory.Text = row.Cells["Category"].Value?.ToString() ?? "";
                numQty.Text = row.Cells["Quantity"].Value?.ToString() ?? "";
                txtAvailableQuantity.Text = row.Cells["AvailableQuantity"].Value?.ToString() ?? "";
                dobCreatedAt.Value = Convert.ToDateTime(row.Cells["CreatedAt"].Value ?? DateTime.Now);

                SetButtonState(isEditing: true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var filtered = books.FindAll(b =>
                    (b.Title?.ToLower().Contains(keyword) ?? false) ||
                    (b.Author?.ToLower().Contains(keyword) ?? false) ||
                    (b.ISBN?.ToLower().Contains(keyword) ?? false) ||
                    (b.Category?.ToLower().Contains(keyword) ?? false) ||
                    (b.Publisher?.ToLower().Contains(keyword) ?? false));

                dgvBooks.DataSource = filtered;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== CLEAR BUTTON =====================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadBooks();
        }

        // ===================== UTILITIES =====================
        private void ClearForm()
        {
            txtISBN.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtPublisher.Clear();
            txtCategory.Clear();
            numQty.Clear();
            numYear.Clear();
            txtAvailableQuantity.Clear();
            dobCreatedAt.Value = DateTime.Now;
            txtSearch.Clear();

            selectedRowIndex = -1;
            SetButtonState(isEditing: false);
        }

        private void SetButtonState(bool isEditing)
        {
            txtISBN.Enabled = !isEditing;
            btnSave.Enabled = !isEditing;
            btnEdit.Enabled = isEditing;
            btnDelete.Enabled = isEditing && loggedInStaff.Role == "Admin";
        }

        private bool ValidateInputs()
        {
            return !string.IsNullOrWhiteSpace(txtISBN.Text) &&
                   !string.IsNullOrWhiteSpace(txtTitle.Text) &&
                   !string.IsNullOrWhiteSpace(txtAuthor.Text) &&
                   !string.IsNullOrWhiteSpace(txtPublisher.Text) &&
                   !string.IsNullOrWhiteSpace(txtCategory.Text) &&
                   !string.IsNullOrWhiteSpace(numQty.Text);
        }

        private Book CreateBookFromInputs() => new Book
        {
            ISBN = txtISBN.Text.Trim(),
            Title = txtTitle.Text.Trim(),
            Author = txtAuthor.Text.Trim(),
            Publisher = txtPublisher.Text.Trim(),
            PublishedYear = int.TryParse(numYear.Text, out int year) ? year : 0,
            Category = txtCategory.Text.Trim(),
            Quantity = int.TryParse(numQty.Text, out int qty) ? qty : 0,
            AvailableQuantity = int.TryParse(txtAvailableQuantity.Text, out int avail) ? avail : 0,
            CreatedAt = dobCreatedAt.Value
        };

        private bool IsRowEmpty(DataGridViewRow row)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    return false;
            }
            return true;
        }
    }
}
