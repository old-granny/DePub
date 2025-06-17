using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Net.WebRequestMethods;
using System.Drawing.Drawing2D;

namespace deepFake.UIElements.Basic
{
    internal class TaskBar : Panel
    {
        private Button btnHome;
        private Button btnSignUp;
        private Button btnSignIn;
        private Panel petitLogo;

        //Pour le dragging
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        private const int WM_NCHITTEST = 0x84;
        private const int HTTOP = 12;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTCAPTION1 = 2;

        public TaskBar()
        {
            this.Height = 60;
            this.Dock = DockStyle.Top;
            this.BackColor = ColorTranslator.FromHtml("#2D3E50"); // Dark blue-gray
            this.Padding = new Padding(10);

            this.MouseDown += TaskBar_MouseDown;

            InitializeComponents();
        }


        private void InitializeComponents()
        {
            // App Title Label
            petitLogo = new Panel
            {
                BackgroundImage = Properties.Resources.petitLogo,
                AutoSize = true,
                Height = Properties.Resources.petitLogo.Height,
                Width = Properties.Resources.petitLogo.Width,
                Location = new Point(10, 15),
                BackgroundImageLayout = ImageLayout.Zoom
            };
            this.Controls.Add(petitLogo);

            // Home Button
            btnHome = CreateButton("Accueil");
            btnHome.Left = 150;
            btnHome.Click += (s, e) =>
            {
                ((Acceuil)this.Parent).LoadFrontPage();
            };

            // Sign Up Button
            btnSignUp = CreateButton("Inscription");
            btnSignUp.Left = 250;
            btnSignUp.Click += (s, e) =>
            {
                ((Acceuil)this.Parent).LoadSignUpPage();
            };

            // Sign In Button
            btnSignIn = CreateButton("Connexion");
            btnSignIn.Left = 370;
            btnSignIn.Click += (s, e) =>
            {
                ((Acceuil)this.Parent).LoadSigningPage();
            };

            // Ajouter Publication
            btnSignIn = CreateButton("New post");
            btnSignIn.Left = 370+(370-250);
            btnSignIn.Click += (s, e) =>
            {
                ((Acceuil)this.Parent).LoadPublierPost();
            };

            this.Controls.Add(btnHome);
            this.Controls.Add(btnSignUp);
            this.Controls.Add(btnSignIn);

            // Control Buttons (Minimize, Maximize/Restore, Close)
            Button btnMinimize = CreateControlButton(Properties.Resources.minus);
            btnMinimize.Click += (s, e) => this.FindForm().WindowState = FormWindowState.Minimized;

            Button btnMaximize = CreateControlButton(Properties.Resources.maximize);
            btnMaximize.Click += (s, e) =>
            {
                var form = this.FindForm();
                form.WindowState = form.WindowState == FormWindowState.Maximized
                    ? FormWindowState.Normal
                    : FormWindowState.Maximized;
                btnMaximize.BackgroundImage = form.WindowState == FormWindowState.Maximized
                    ? Properties.Resources.screenNormal
                    : Properties.Resources.maximize;

            };

            Button btnClose = CreateControlButton(Properties.Resources.Exit);
            btnClose.Click += (s, e) => this.FindForm().Close();

            // Positioning: right-aligned
            int buttonWidth = 55;
            int spacing = 1;
            int totalButtons = 3;
            int totalWidth = buttonWidth * totalButtons;

            btnMinimize.Location = new Point(this.Width - totalWidth, 10);
            btnMaximize.Location = new Point(this.Width - buttonWidth * 2, 10);
            btnClose.Location = new Point(this.Width - buttonWidth, 10);

            btnMinimize.Anchor = btnMaximize.Anchor = btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.Controls.Add(btnMinimize);
            this.Controls.Add(btnMaximize);
            this.Controls.Add(btnClose);
        }

        private Button CreateButton(string text)
        {
            return new Button
            {
                Text = text,
                ForeColor = Color.White,
                BackColor = ColorTranslator.FromHtml("#4A90E2"),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Width = 100,
                Height = 35,
                Top = 12
            };
        }

        private Button CreateControlButton(Image img)
        {
            Button btn = new Button
            {
                Width = img.Width,
                Height = img.Height,
                BackgroundImage = img,
                FlatStyle = 0,
                BackColor = Color.Transparent,
            };

            btn.FlatAppearance.BorderSize = 0; // Remove border
            
            return btn;
        }



        private void TaskBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.FindForm().Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a vertical linear gradient brush from blue to light blue
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                ColorTranslator.FromHtml("#000000"),       // Start color (your #5796AD)
                ColorTranslator.FromHtml("#0A3241"),      // End color (lighter)
                LinearGradientMode.Horizontal))       // Gradient direction
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            // Optional: Draw other stuff on the taskbar here
        }

    }
}
