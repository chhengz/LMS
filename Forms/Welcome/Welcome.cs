using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS.Forms.Welcome
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            this.Text = "Welcome to Library Management System";
        }

        private void Welcome_SizeChanged(object sender, EventArgs e)
        {
            // Center the child panel inside the form
            panelCenter.Left = (this.ClientSize.Width - panelCenter.Width) / 2;
            panelCenter.Top = (this.ClientSize.Height - panelCenter.Height) / 2;
        }


        private void Welcome_Load(object sender, EventArgs e)
        {
            Welcome_SizeChanged(sender, e);
        }
    }
}
