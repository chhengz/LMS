namespace LMS
{
    partial class LMS_FORM
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
            this.btnBook = new System.Windows.Forms.Button();
            this.btnBRW_RTN = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelMenu_sidbar = new System.Windows.Forms.Panel();
            this.btnStaffs = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelMenu_sidbar.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.DarkGray;
            this.btnBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBook.FlatAppearance.BorderSize = 0;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBook.Location = new System.Drawing.Point(0, 115);
            this.btnBook.Margin = new System.Windows.Forms.Padding(0);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(200, 48);
            this.btnBook.TabIndex = 0;
            this.btnBook.Text = "Books";
            this.btnBook.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnBRW_RTN
            // 
            this.btnBRW_RTN.BackColor = System.Drawing.Color.DarkGray;
            this.btnBRW_RTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBRW_RTN.FlatAppearance.BorderSize = 0;
            this.btnBRW_RTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBRW_RTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBRW_RTN.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBRW_RTN.Location = new System.Drawing.Point(0, 163);
            this.btnBRW_RTN.Margin = new System.Windows.Forms.Padding(0);
            this.btnBRW_RTN.Name = "btnBRW_RTN";
            this.btnBRW_RTN.Size = new System.Drawing.Size(200, 48);
            this.btnBRW_RTN.TabIndex = 1;
            this.btnBRW_RTN.Text = "Borrow/Return";
            this.btnBRW_RTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBRW_RTN.UseVisualStyleBackColor = false;
            this.btnBRW_RTN.Click += new System.EventHandler(this.btnBRW_RTN_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelMenu.Controls.Add(this.panelMenu_sidbar);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 555);
            this.panelMenu.TabIndex = 4;
            // 
            // panelMenu_sidbar
            // 
            this.panelMenu_sidbar.Controls.Add(this.btnStaffs);
            this.panelMenu_sidbar.Controls.Add(this.btnBRW_RTN);
            this.panelMenu_sidbar.Controls.Add(this.btnBook);
            this.panelMenu_sidbar.Controls.Add(this.btnHome);
            this.panelMenu_sidbar.Controls.Add(this.panel2);
            this.panelMenu_sidbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu_sidbar.Location = new System.Drawing.Point(0, 70);
            this.panelMenu_sidbar.Margin = new System.Windows.Forms.Padding(0);
            this.panelMenu_sidbar.Name = "panelMenu_sidbar";
            this.panelMenu_sidbar.Size = new System.Drawing.Size(200, 383);
            this.panelMenu_sidbar.TabIndex = 6;
            // 
            // btnStaffs
            // 
            this.btnStaffs.BackColor = System.Drawing.Color.DarkGray;
            this.btnStaffs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStaffs.FlatAppearance.BorderSize = 0;
            this.btnStaffs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaffs.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffs.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStaffs.Location = new System.Drawing.Point(0, 211);
            this.btnStaffs.Margin = new System.Windows.Forms.Padding(0);
            this.btnStaffs.Name = "btnStaffs";
            this.btnStaffs.Size = new System.Drawing.Size(200, 48);
            this.btnStaffs.TabIndex = 3;
            this.btnStaffs.Text = "Staffs";
            this.btnStaffs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaffs.UseVisualStyleBackColor = false;
            this.btnStaffs.Click += new System.EventHandler(this.btnStaffs_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.DarkGray;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHome.Location = new System.Drawing.Point(0, 67);
            this.btnHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(200, 48);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 67);
            this.panel2.TabIndex = 4;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 70);
            this.panelLogo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Library";
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.AutoScroll = true;
            this.panelDesktopPane.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDesktopPane.Location = new System.Drawing.Point(200, 70);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(865, 490);
            this.panelDesktopPane.TabIndex = 5;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Location = new System.Drawing.Point(200, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(868, 70);
            this.panelTitleBar.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(22, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(143, 37);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Library";
            // 
            // LMS_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1064, 555);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1080, 594);
            this.MinimumSize = new System.Drawing.Size(1080, 594);
            this.Name = "LMS_FORM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LMS";
            this.Load += new System.EventHandler(this.LMS_FORM_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu_sidbar.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnBRW_RTN;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelMenu_sidbar;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnStaffs;
        private System.Windows.Forms.Panel panel2;
    }
}

