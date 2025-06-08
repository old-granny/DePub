using deepFake;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System;
using FormsTimer = System.Windows.Forms.Timer;



namespace deepFake
{

    /// <summary>
    /// Cette classe vas servir de controleur principale
    /// il vas toute gerer
    /// </summary>
    public partial class Acceuil : Form
    {

        public UserInstance User; // Instance de l'usager

        /*  Instance des Form  */
        private PublierPost PublierPostPage;
        private FrontPage FrontPagePage;
        private Signup SignupPage;
        private Signing SigningPage;
        /*  Instance des Form  */
        private Form currentActive = null; // Form active


        private FormsTimer animTimer;
        private float animProgress;       // 0.0 → 1.0
        private bool fadingIn;            // true when hover, false when leave
        private const float step = 0.1f;  // adjust for speed (0.05 = slower, 0.2 = faster)

        public Acceuil()
        {
            InitializeComponent(); // Fonction implementer automatiquement par .NET

            animTimer = new FormsTimer { Interval = 30 };

            User = new UserInstance();

            CreationInstanceForm();
            Beautefull();
            LoadFrontPage();

        }

        /* Fonction complementaire au constructeur */
        private void CreationInstanceForm()
        {
            PublierPostPage = new PublierPost(this) { TopLevel = false, TopMost = true };
            FrontPagePage = new FrontPage(this) { TopLevel = false, TopMost = true };
            SignupPage = new Signup(this) { TopLevel = false, TopMost = true };
            SigningPage = new Signing(this) { TopLevel = false, TopMost = true };
        }

        private void Beautefull()
        {
            this.TaskBar.MouseDown += TaskBar_MouseDown;
            this.TaskBar.Paint += TaskBarPaint;
            SetRoundedBottomLeftCorner(TaskBar, 25);
            animTimer.Tick += AnimTimer_Tick;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false; // optional: removes minimize/maximize/close buttons
            this.Text = string.Empty; // optional: removes title text
            this.BackColor = ColorTranslator.FromHtml("#5796AD");

        }
        /* Fonction complementaire au constructeur */

        private void TaskBarPaint(object sender, PaintEventArgs e)
        {
            Control taskBar = (Control)sender;
            Graphics g = e.Graphics;

            Rectangle rect = taskBar.ClientRectangle;

            Color color1 = ColorTranslator.FromHtml("#000000");
            Color color2 = ColorTranslator.FromHtml("#0A3241");
            Color color3 = ColorTranslator.FromHtml("#0A3241");

            Rectangle rect1 = new Rectangle(0, 0, rect.Width / 2, rect.Height);
            Rectangle rect2 = new Rectangle(rect.Width / 2, 0, rect.Width / 2, rect.Height);

            using (LinearGradientBrush brush1 = new LinearGradientBrush(rect1, color1, color2, LinearGradientMode.Horizontal))
            using (LinearGradientBrush brush2 = new LinearGradientBrush(rect2, color2, color3, LinearGradientMode.Horizontal))
            {
                g.FillRectangle(brush1, rect1);
                g.FillRectangle(brush2, rect2);
            }

        }
        private void SetRoundedBottomLeftCorner(Control control, int radius)
        {
            int width = control.Width;
            int height = control.Height;

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            // Top-left corner
            path.AddLine(0, 0, width, 0); // Top edge
            path.AddLine(width, 0, width, height); // Right edge

            // Bottom-right corner (square)
            path.AddLine(width, height, radius, height); // Bottom edge to start rounding

            // Bottom-left corner (rounded)
            path.AddArc(0, height - 2 * radius, 2 * radius, 2 * radius, 90, 90);

            // Left edge up to top
            path.AddLine(0, height - radius, 0, 0);

            path.CloseFigure();

            control.Region = new Region(path);
        }

        protected override void WndProc(ref Message m)
        {
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;
            const int WM_NCHITTEST = 0x84;

            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST)
            {
                const int RESIZE_HANDLE_SIZE = 10;
                var cursor = this.PointToClient(Cursor.Position);

                if (cursor.X <= RESIZE_HANDLE_SIZE)
                {
                    if (cursor.Y <= RESIZE_HANDLE_SIZE)
                        m.Result = (IntPtr)HTTOPLEFT;
                    else if (cursor.Y >= this.ClientSize.Height - RESIZE_HANDLE_SIZE)
                        m.Result = (IntPtr)HTBOTTOMLEFT;
                    else
                        m.Result = (IntPtr)HTLEFT;
                }
                else if (cursor.X >= this.ClientSize.Width - RESIZE_HANDLE_SIZE)
                {
                    if (cursor.Y <= RESIZE_HANDLE_SIZE)
                        m.Result = (IntPtr)HTTOPRIGHT;
                    else if (cursor.Y >= this.ClientSize.Height - RESIZE_HANDLE_SIZE)
                        m.Result = (IntPtr)HTBOTTOMRIGHT;
                    else
                        m.Result = (IntPtr)HTRIGHT;
                }
                else if (cursor.Y <= RESIZE_HANDLE_SIZE)
                {
                    m.Result = (IntPtr)HTTOP;
                }
                else if (cursor.Y >= this.ClientSize.Height - RESIZE_HANDLE_SIZE)
                {
                    m.Result = (IntPtr)HTBOTTOM;
                }
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void TaskBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /* Fonction public pour permettre de changer de form facillement */

        public void LoadFrontPage()
        {
            FrontPagePage.Cleanup();
            LoadFormInsidePanel(FrontPagePage);
        }
        public void LoadSignUpPage()
        {
            SignupPage.Cleanup();
            LoadFormInsidePanel(SignupPage);
        }
        public void LoadPublierPost()
        {
            PublierPostPage.Cleanup();
            LoadFormInsidePanel(PublierPostPage);
        }
        public void LoadSigningPage()
        {
            SigningPage.Cleanup();
            LoadFormInsidePanel(SigningPage);
        }
        /* Fonction public pour permettre de changer de form facillement */


        /* Fonction pour faciliter la tache des Loader de form */
        public bool LoadFormInsidePanel(Form form)
        {
            if (currentActive != null)
            {
                CloseFormInsidePanel(currentActive);
            }
            currentActive = form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
            //PanelLoadForm.Controls.Add(form);
            return true;
        }

        private bool CloseFormInsidePanel(Form form)
        {
            form.Hide();
            return true;
        }
        /* Fonction pour faciliter la tache des Loader de form */


        public bool Cleanup()
        {
            return true;
        }

        private void Acceuil_Load(object sender, EventArgs e)
        {

        }

        private void UnMax_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            fadingIn = true;
            animProgress = 0f;
            animTimer.Start();
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            fadingIn = false;
            animProgress = 0f;
            animTimer.Start();
        }

        private void AnimTimer_Tick(object? sender, EventArgs e)
        {
            // advance
            animProgress += step;
            if (animProgress >= 1f)
            {
                animProgress = 1f;
                animTimer.Stop();
            }

            // source images
            var bmpExit = Properties.Resources.Exit;
            var bmpExitHover = Properties.Resources.ExitHover;
            var blended = new Bitmap(bmpExit.Width, bmpExit.Height);

            using (var g = Graphics.FromImage(blended))
            {
                if (fadingIn)
                {
                    // fade from Exit → ExitHover
                    // Exit alpha = (1 - progress), Hover alpha = progress
                    DrawWithAlpha(g, bmpExit, 1f - animProgress);
                    DrawWithAlpha(g, bmpExitHover, animProgress);
                }
                else
                {
                    // fade from ExitHover → Exit
                    // Hover alpha = (1 - progress), Exit alpha = progress
                    DrawWithAlpha(g, bmpExitHover, 1f - animProgress);
                    DrawWithAlpha(g, bmpExit, animProgress);
                }
            }

            this.exitButton.BackgroundImage = blended;
        }

        /// <summary>
        /// Helper to draw a bitmap at 0,0 with a given alpha (0–1).
        /// </summary>
        private void DrawWithAlpha(Graphics g, Bitmap bmp, float alpha)
        {
            var cm = new ColorMatrix { Matrix33 = alpha };
            var ia = new ImageAttributes();
            ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            g.DrawImage(bmp,
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                0, 0, bmp.Width, bmp.Height,
                GraphicsUnit.Pixel, ia);
        }
    }
}
