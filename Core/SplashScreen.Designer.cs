namespace LMS
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.lblTitle = new System.Windows.Forms.Label();
            this.pic_rupp = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pic_lms = new System.Windows.Forms.PictureBox();
            this.pic_main = new System.Windows.Forms.PictureBox();
            this.spinner = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pic_rupp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_lms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_main)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Khmer OS Muol", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(130, 161);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(225, 55);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "សូមរងចាំបន្តិច";
            // 
            // pic_rupp
            // 
            this.pic_rupp.Image = ((System.Drawing.Image)(resources.GetObject("pic_rupp.Image")));
            this.pic_rupp.Location = new System.Drawing.Point(103, 40);
            this.pic_rupp.Name = "pic_rupp";
            this.pic_rupp.Size = new System.Drawing.Size(118, 92);
            this.pic_rupp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_rupp.TabIndex = 1;
            this.pic_rupp.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Khmer OS Battambang", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(227, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            // 
            // pic_lms
            // 
            this.pic_lms.Image = ((System.Drawing.Image)(resources.GetObject("pic_lms.Image")));
            this.pic_lms.Location = new System.Drawing.Point(264, 40);
            this.pic_lms.Name = "pic_lms";
            this.pic_lms.Size = new System.Drawing.Size(118, 92);
            this.pic_lms.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_lms.TabIndex = 3;
            this.pic_lms.TabStop = false;
            // 
            // pic_main
            // 
            this.pic_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_main.Image = ((System.Drawing.Image)(resources.GetObject("pic_main.Image")));
            this.pic_main.Location = new System.Drawing.Point(0, 0);
            this.pic_main.Name = "pic_main";
            this.pic_main.Size = new System.Drawing.Size(484, 311);
            this.pic_main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_main.TabIndex = 4;
            this.pic_main.TabStop = false;
            // 
            // spinner
            // 
            this.spinner.Location = new System.Drawing.Point(103, 232);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(279, 23);
            this.spinner.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.spinner.TabIndex = 5;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.spinner);
            this.Controls.Add(this.pic_lms);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pic_rupp);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pic_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.Text = "SplashScreen";
            ((System.ComponentModel.ISupportInitialize)(this.pic_rupp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_lms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pic_rupp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic_lms;
        private System.Windows.Forms.PictureBox pic_main;
        private System.Windows.Forms.ProgressBar spinner;
    }
}