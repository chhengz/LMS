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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBorrowerName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cbx_contact_check = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBorrowerContact = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTID = new System.Windows.Forms.TextBox();
            this.cbBook = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrower)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBorrower
            // 
            this.dgvBorrower.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrower.Location = new System.Drawing.Point(11, 233);
            this.dgvBorrower.Margin = new System.Windows.Forms.Padding(4);
            this.dgvBorrower.Name = "dgvBorrower";
            this.dgvBorrower.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBorrower.Size = new System.Drawing.Size(821, 271);
            this.dgvBorrower.TabIndex = 1;
            this.dgvBorrower.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBorrower_CellClick);
            // 
            // dtpBorrowDate
            // 
            this.dtpBorrowDate.Location = new System.Drawing.Point(11, 31);
            this.dtpBorrowDate.Name = "dtpBorrowDate";
            this.dtpBorrowDate.Size = new System.Drawing.Size(283, 28);
            this.dtpBorrowDate.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(610, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(623, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Staff Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "Borrower name";
            // 
            // txtBorrowerName
            // 
            this.txtBorrowerName.Location = new System.Drawing.Point(11, 88);
            this.txtBorrowerName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtBorrowerName.Name = "txtBorrowerName";
            this.txtBorrowerName.Size = new System.Drawing.Size(283, 28);
            this.txtBorrowerName.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 28);
            this.button1.TabIndex = 25;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(11, 198);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(419, 28);
            this.textBox2.TabIndex = 24;
            // 
            // cbx_contact_check
            // 
            this.cbx_contact_check.AutoSize = true;
            this.cbx_contact_check.Location = new System.Drawing.Point(300, 66);
            this.cbx_contact_check.Name = "cbx_contact_check";
            this.cbx_contact_check.Size = new System.Drawing.Size(96, 23);
            this.cbx_contact_check.TabIndex = 26;
            this.cbx_contact_check.Text = "Contact info";
            this.cbx_contact_check.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(702, 141);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(130, 28);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "Delete";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(436, 143);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(130, 28);
            this.btnReturn.TabIndex = 30;
            this.btnReturn.Text = "Make as Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnBorrow
            // 
            this.btnBorrow.Location = new System.Drawing.Point(300, 143);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(130, 28);
            this.btnBorrow.TabIndex = 29;
            this.btnBorrow.Text = "Add Borrow";
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.Location = new System.Drawing.Point(644, 34);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(90, 19);
            this.lblStaffName.TabIndex = 37;
            this.lblStaffName.Text = "{lblStaffName}";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(614, 88);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(218, 28);
            this.txtStatus.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 19);
            this.label6.TabIndex = 35;
            this.label6.Text = "Transaction ID";
            // 
            // txtBorrowerContact
            // 
            this.txtBorrowerContact.Location = new System.Drawing.Point(300, 88);
            this.txtBorrowerContact.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtBorrowerContact.Name = "txtBorrowerContact";
            this.txtBorrowerContact.Size = new System.Drawing.Size(308, 28);
            this.txtBorrowerContact.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 19);
            this.label7.TabIndex = 33;
            this.label7.Text = "Select book title";
            // 
            // txtTID
            // 
            this.txtTID.Location = new System.Drawing.Point(300, 31);
            this.txtTID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTID.Name = "txtTID";
            this.txtTID.Size = new System.Drawing.Size(308, 28);
            this.txtTID.TabIndex = 32;
            // 
            // cbBook
            // 
            this.cbBook.FormattingEnabled = true;
            this.cbBook.Location = new System.Drawing.Point(11, 143);
            this.cbBook.Name = "cbBook";
            this.cbBook.Size = new System.Drawing.Size(283, 27);
            this.cbBook.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 39;
            this.label3.Text = "Choose Date";
            // 
            // BorrowReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 727);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbBook);
            this.Controls.Add(this.lblStaffName);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBorrowerContact);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTID);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.cbx_contact_check);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBorrowerName);
            this.Controls.Add(this.dtpBorrowDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBorrower);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BorrowReturnForm";
            this.Text = "Borrow/Return Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrower)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBorrower;
        private System.Windows.Forms.DateTimePicker dtpBorrowDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBorrowerName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox cbx_contact_check;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBorrowerContact;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTID;
        private System.Windows.Forms.ComboBox cbBook;
        private System.Windows.Forms.Label label3;
    }
}