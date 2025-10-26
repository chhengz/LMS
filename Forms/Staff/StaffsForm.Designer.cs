namespace LMS
{
    partial class StaffsForm
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtFN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.r1 = new System.Windows.Forms.Button();
            this.r2 = new System.Windows.Forms.Button();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.chPass = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbSAcc = new System.Windows.Forms.Label();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dobCreatedAt = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(368, 19);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(218, 28);
            this.txtEmail.TabIndex = 2;
            // 
            // txtFN
            // 
            this.txtFN.Location = new System.Drawing.Point(146, 19);
            this.txtFN.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtFN.Name = "txtFN";
            this.txtFN.Size = new System.Drawing.Size(216, 28);
            this.txtFN.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "FullName";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFN);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Location = new System.Drawing.Point(12, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 56);
            this.panel1.TabIndex = 19;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(592, 19);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(218, 28);
            this.txtPhone.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 19);
            this.label9.TabIndex = 24;
            this.label9.Text = "Staff ID";
            // 
            // txtSID
            // 
            this.txtSID.Location = new System.Drawing.Point(8, 19);
            this.txtSID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSID.Name = "txtSID";
            this.txtSID.ReadOnly = true;
            this.txtSID.Size = new System.Drawing.Size(132, 28);
            this.txtSID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(588, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Phone";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.r1);
            this.panel2.Controls.Add(this.r2);
            this.panel2.Controls.Add(this.txtRole);
            this.panel2.Controls.Add(this.txtPass);
            this.panel2.Controls.Add(this.chPass);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtUser);
            this.panel2.Location = new System.Drawing.Point(13, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(683, 56);
            this.panel2.TabIndex = 23;
            // 
            // r1
            // 
            this.r1.Location = new System.Drawing.Point(618, 19);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(28, 28);
            this.r1.TabIndex = 6;
            this.r1.Text = "1";
            this.r1.UseVisualStyleBackColor = true;
            this.r1.Click += new System.EventHandler(this.r1_Click);
            // 
            // r2
            // 
            this.r2.Location = new System.Drawing.Point(649, 19);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(28, 28);
            this.r2.TabIndex = 7;
            this.r2.Text = "2";
            this.r2.UseVisualStyleBackColor = true;
            this.r2.Click += new System.EventHandler(this.r2_Click);
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(453, 19);
            this.txtRole.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtRole.Name = "txtRole";
            this.txtRole.ReadOnly = true;
            this.txtRole.Size = new System.Drawing.Size(159, 28);
            this.txtRole.TabIndex = 0;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(229, 19);
            this.txtPass.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(218, 28);
            this.txtPass.TabIndex = 5;
            // 
            // chPass
            // 
            this.chPass.AutoSize = true;
            this.chPass.Location = new System.Drawing.Point(229, 0);
            this.chPass.Name = "chPass";
            this.chPass.Size = new System.Drawing.Size(81, 23);
            this.chPass.TabIndex = 30;
            this.chPass.Text = "Password";
            this.chPass.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(449, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 19);
            this.label5.TabIndex = 22;
            this.label5.Text = "Role";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(7, 19);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(216, 28);
            this.txtUser.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Khmer OS Battambang", 12F);
            this.label7.Location = new System.Drawing.Point(8, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 29);
            this.label7.TabIndex = 23;
            this.label7.Text = "Staff\'s Infomation";
            // 
            // lbSAcc
            // 
            this.lbSAcc.AutoSize = true;
            this.lbSAcc.Font = new System.Drawing.Font("Khmer OS Battambang", 12F);
            this.lbSAcc.Location = new System.Drawing.Point(8, 105);
            this.lbSAcc.Name = "lbSAcc";
            this.lbSAcc.Size = new System.Drawing.Size(152, 29);
            this.lbSAcc.TabIndex = 24;
            this.lbSAcc.Text = "Make Staff Account";
            // 
            // dgvStaff
            // 
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.Location = new System.Drawing.Point(0, 240);
            this.dgvStaff.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.Size = new System.Drawing.Size(844, 238);
            this.dgvStaff.TabIndex = 14;
            this.dgvStaff.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(562, 204);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(230, 28);
            this.txtSearch.TabIndex = 12;
            // 
            // dobCreatedAt
            // 
            this.dobCreatedAt.CustomFormat = "dd-MM-yyyy";
            this.dobCreatedAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dobCreatedAt.Location = new System.Drawing.Point(702, 12);
            this.dobCreatedAt.Name = "dobCreatedAt";
            this.dobCreatedAt.Size = new System.Drawing.Size(120, 28);
            this.dobCreatedAt.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Image = global::LMS.Properties.Resources.broom_32px;
            this.btnClear.Location = new System.Drawing.Point(338, 199);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(34, 34);
            this.btnClear.TabIndex = 11;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::LMS.Properties.Resources.search_30px;
            this.btnSearch.Location = new System.Drawing.Point(798, 199);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 34);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::LMS.Properties.Resources.delete_bin_30px;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(232, 199);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 34);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::LMS.Properties.Resources.edit_file_30px;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(126, 199);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 34);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Update";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::LMS.Properties.Resources.add_30px;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(20, 199);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 34);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // StaffsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 480);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dobCreatedAt);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvStaff);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbSAcc);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StaffsForm";
            this.Text = "Staffs Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtFN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbSAcc;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSID;
        private System.Windows.Forms.DateTimePicker dobCreatedAt;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chPass;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Button r1;
        private System.Windows.Forms.Button r2;
    }
}