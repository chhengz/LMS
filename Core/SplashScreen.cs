using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class SplashScreen : Form
    {
     
        public SplashScreen()
        {
            InitializeComponent();

            // Basic form setup
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;


            spinner.MarqueeAnimationSpeed = 30;
            spinner.Style = ProgressBarStyle.Marquee;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Opacity = 0;

            Timer fadeIn = new Timer { Interval = 15 };
            fadeIn.Tick += (s, ev) =>
            {
                if (Opacity < 1)
                    Opacity += 0.05;
                else
                    fadeIn.Stop();
            };
            fadeIn.Start();
        }

        // ===================== Show for 2s then fade-out =====================
        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // Keep visible for 3 seconds (simulate loading)
            await Task.Delay(3000);

            // Fade-out before switching
            await FadeOutAsync();

            // ✅ After splash, show login form (or main form)
            Hide();
            new Login_form().Show();
        }

        private async Task FadeOutAsync()
        {
            while (Opacity > 0)
            {
                await Task.Delay(15);
                Opacity -= 0.05;
            }
        }
    }
}
