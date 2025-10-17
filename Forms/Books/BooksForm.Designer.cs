namespace LMS
{
    partial class BooksForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.numQty = new System.Windows.Forms.TextBox();
            this.txtAvailableQuantity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numYear = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBooks
            // 
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(12, 263);
            this.dgvBooks.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(820, 251);
            this.dgvBooks.TabIndex = 0;
            this.dgvBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooks_CellClick);
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(104, 14);
            this.txtISBN.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(200, 28);
            this.txtISBN.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "ISBN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Author";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Publisher";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "PublishedYear";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(310, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Category";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "Quantity";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(104, 46);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 28);
            this.txtTitle.TabIndex = 2;
            // 
            // txtPublisher
            // 
            this.txtPublisher.Location = new System.Drawing.Point(104, 110);
            this.txtPublisher.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(200, 28);
            this.txtPublisher.TabIndex = 4;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(104, 78);
            this.txtAuthor.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(200, 28);
            this.txtAuthor.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(702, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 28);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(702, 45);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(130, 28);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(702, 83);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 28);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // numQty
            // 
            this.numQty.Location = new System.Drawing.Point(427, 46);
            this.numQty.Name = "numQty";
            this.numQty.Size = new System.Drawing.Size(218, 28);
            this.numQty.TabIndex = 7;
            // 
            // txtAvailableQuantity
            // 
            this.txtAvailableQuantity.Location = new System.Drawing.Point(427, 78);
            this.txtAvailableQuantity.Name = "txtAvailableQuantity";
            this.txtAvailableQuantity.Size = new System.Drawing.Size(218, 28);
            this.txtAvailableQuantity.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(309, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 19);
            this.label8.TabIndex = 20;
            this.label8.Text = "AvailableQuantity";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 227);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(409, 28);
            this.textBox1.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(427, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 28);
            this.button1.TabIndex = 13;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(104, 141);
            this.numYear.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(200, 28);
            this.numYear.TabIndex = 5;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(427, 12);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(218, 28);
            this.txtCategory.TabIndex = 6;
            // 
            // BooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 575);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtAvailableQuantity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numQty);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPublisher);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.dgvBooks);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "BooksForm";
            this.Text = "Books Form";
            this.Load += new System.EventHandler(this.BooksForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox numQty;
        private System.Windows.Forms.TextBox txtAvailableQuantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox numYear;
        private System.Windows.Forms.TextBox txtCategory;
    }
}