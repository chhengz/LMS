namespace LMS
{
    partial class BorrowReturnForm
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
            this.dgvBorrower = new System.Windows.Forms.DataGridView();
            this.dtpBorrowDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBorrowerName = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cbx_contact_check = new System.Windows.Forms.CheckBox();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBorrowerContact = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTID = new System.Windows.Forms.TextBox();
            this.cbBook = new System.Windows.Forms.ComboBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrower)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBorrower
            // 
            this.dgvBorrower.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrower.Location = new System.Drawing.Point(0, 205);
            this.dgvBorrower.Margin = new System.Windows.Forms.Padding(4);
            this.dgvBorrower.Name = "dgvBorrower";
            this.dgvBorrower.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBorrower.Size = new System.Drawing.Size(844, 273);
            this.dgvBorrower.TabIndex = 9;
            this.dgvBorrower.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBorrower_CellClick);
            // 
            // dtpBorrowDate
            // 
            this.dtpBorrowDate.CustomFormat = "dd-MM-yyyy";
            this.dtpBorrowDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBorrowDate.Location = new System.Drawing.Point(702, 12);
            this.dtpBorrowDate.Name = "dtpBorrowDate";
            this.dtpBorrowDate.Size = new System.Drawing.Size(120, 28);
            this.dtpBorrowDate.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(627, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "Borrower name";
            // 
            // txtBorrowerName
            // 
            this.txtBorrowerName.Location = new System.Drawing.Point(107, 19);
            this.txtBorrowerName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtBorrowerName.Name = "txtBorrowerName";
            this.txtBorrowerName.Size = new System.Drawing.Size(254, 28);
            this.txtBorrowerName.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(564, 168);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(230, 28);
            this.textBox2.TabIndex = 7;
            // 
            // cbx_contact_check
            // 
            this.cbx_contact_check.AutoSize = true;
            this.cbx_contact_check.Location = new System.Drawing.Point(367, -1);
            this.cbx_contact_check.Name = "cbx_contact_check";
            this.cbx_contact_check.Size = new System.Drawing.Size(96, 23);
            this.cbx_contact_check.TabIndex = 2;
            this.cbx_contact_check.Text = "Contact info";
            this.cbx_contact_check.UseVisualStyleBackColor = true;
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.Location = new System.Drawing.Point(367, 75);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(90, 19);
            this.lblStaffName.TabIndex = 37;
            this.lblStaffName.Text = "{lblStaffName}";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 19);
            this.label6.TabIndex = 35;
            this.label6.Text = "Transaction ID";
            // 
            // txtBorrowerContact
            // 
            this.txtBorrowerContact.Location = new System.Drawing.Point(367, 19);
            this.txtBorrowerContact.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtBorrowerContact.Name = "txtBorrowerContact";
            this.txtBorrowerContact.Size = new System.Drawing.Size(254, 28);
            this.txtBorrowerContact.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 19);
            this.label7.TabIndex = 33;
            this.label7.Text = "Select book title";
            // 
            // txtTID
            // 
            this.txtTID.Location = new System.Drawing.Point(6, 19);
            this.txtTID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTID.Name = "txtTID";
            this.txtTID.ReadOnly = true;
            this.txtTID.Size = new System.Drawing.Size(95, 28);
            this.txtTID.TabIndex = 0;
            // 
            // cbBook
            // 
            this.cbBook.FormattingEnabled = true;
            this.cbBook.Location = new System.Drawing.Point(6, 72);
            this.cbBook.Name = "cbBook";
            this.cbBook.Size = new System.Drawing.Size(355, 27);
            this.cbBook.TabIndex = 3;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(631, 19);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(181, 28);
            this.txtStatus.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::LMS.Properties.Resources.search_30px;
            this.btnSearch.Location = new System.Drawing.Point(800, 164);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 34);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Image = global::LMS.Properties.Resources.broom_32px;
            this.btnClear.Location = new System.Drawing.Point(230, 164);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(34, 33);
            this.btnClear.TabIndex = 6;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Image = global::LMS.Properties.Resources.ok_30px;
            this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.Location = new System.Drawing.Point(124, 164);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(100, 34);
            this.btnReturn.TabIndex = 5;
            this.btnReturn.Text = "Return";
            this.btnReturn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnBorrow
            // 
            this.btnBorrow.Image = global::LMS.Properties.Resources.add_30px;
            this.btnBorrow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrow.Location = new System.Drawing.Point(18, 164);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(100, 34);
            this.btnBorrow.TabIndex = 4;
            this.btnBorrow.Text = "Add New";
            this.btnBorrow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Khmer OS Battambang", 12F);
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 29);
            this.label1.TabIndex = 43;
            this.label1.Text = "Borrower\'s Infomation";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.txtBorrowerContact);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtBorrowerName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbBook);
            this.panel1.Controls.Add(this.lblStaffName);
            this.panel1.Controls.Add(this.cbx_contact_check);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtTID);
            this.panel1.Location = new System.Drawing.Point(12, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 112);
            this.panel1.TabIndex = 44;
            // 
            // BorrowReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 480);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dtpBorrowDate);
            this.Controls.Add(this.dgvBorrower);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BorrowReturnForm";
            this.Text = "Borrow/Return Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrower)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBorrower;
        private System.Windows.Forms.DateTimePicker dtpBorrowDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBorrowerName;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox cbx_contact_check;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBorrowerContact;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTID;
        private System.Windows.Forms.ComboBox cbBook;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}