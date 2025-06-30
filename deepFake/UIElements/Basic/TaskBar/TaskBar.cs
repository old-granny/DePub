using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Net.WebRequestMethods;
using System.Drawing.Drawing2D;
using deepFake.ModelConception.Observateur;
using deepFake.UIElements.Basic.TaskBar.Components;

namespace deepFake.UIElements.Basic.TaskBar
{
    public partial class TaskBar : Panel, AbonneUser
    {
        private Panel petitLogo;
        private SearchBar searchBar;

        private FlowLayoutPanel layoutPanelForm;
        private FlowLayoutPanel layoutPanelTaskBar;


        private static TaskBar _instance = null;



        private int ButtonFormWidth = 50;
        private int ButtonFormHeight = 50;
        private int ButtonTaskBarWidth = 30;
        private int ButtonTaskBarHeight = 30;

        private Button BtnMaximize;

        public static TaskBar Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TaskBar();
                }
                return _instance;

            }
        }
        protected TaskBar()
        {
            Beautiful();
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            _instance = this;
            searchBar = new SearchBar(); // no Point passed here
            Controls.Add(searchBar);

            // Subscribe to resize event to recenter search bar
            this.Resize += (s, e) => CenterElements();
            this.HandleCreated += (s, e) => CenterElements(); // ensure it's placed on startup

            Mouvements();
            Globals.User.AjouterAbonne(_instance);
            InitializeComponents();

            

        }


        private void Beautiful()
        {
            Height = 60;
            Dock = DockStyle.Top;
            BackColor = ColorTranslator.FromHtml("#2D3E50");
            Padding = new Padding(10);

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int radius = 20;
            int w = this.Width;
            int h = this.Height;

            if (w <= 0 || h <= 0) return;

            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            path.AddLine(0, 0, w, 0); // Top edge
            path.AddLine(w, 0, w, h); // Right edge
            path.AddLine(w, h, radius, h); // Bottom edge to left curve
            path.AddArc(0, h - radius * 2, radius * 2, radius * 2, 90, 90); // Bottom-left corner
            path.AddLine(0, h - radius, 0, 0); // Left edge

            path.CloseFigure();

            this.Region = new Region(path);
        }


        /*
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                ColorTranslator.FromHtml("#2D3E50"),  // Top color
                ColorTranslator.FromHtml("#1C2833"),  // Bottom color
                LinearGradientMode.Vertical))         // Top-to-bottom gradient
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        */

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                ColorTranslator.FromHtml("#000000"), // Right side color
                ColorTranslator.FromHtml("#0A3241"), // Left side color
                LinearGradientMode.Horizontal))      // Left-to-right by default
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
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
                Location = new Point(10, 8),
                BackgroundImageLayout = ImageLayout.Zoom,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
            };
            Controls.Add(petitLogo);
            petitLogo.Click += PetitLogo_Click;


            CreateTaskbarAction();
            CreateTopBarButton();
        }

        private void PetitLogo_Click(object? sender, EventArgs e) =>
            Acceuil.GetInstance().LoadFrontPage();
        

        private void CreateTopBarButton()
        {
            // Control Buttons (Minimize, Maximize/Restore, Close)x
            Button btnMinimize = CreateTaskBarButton(Properties.Resources.minus);
            btnMinimize.Click += (s, e) => FindForm().WindowState = FormWindowState.Minimized;
            btnMinimize.MouseEnter += (s, e) => btnMinimize.BackgroundImage = Properties.Resources.minusHover;
            btnMinimize.MouseLeave += (s, e) => btnMinimize.BackgroundImage = Properties.Resources.minus;




            BtnMaximize = CreateTaskBarButton(Properties.Resources.maximize);
            BtnMaximize.Click += (s, e) =>
            {
                var form = FindForm();
                form.WindowState = form.WindowState == FormWindowState.Maximized
                    ? FormWindowState.Normal
                    : FormWindowState.Maximized;
                BtnMaximize.BackgroundImage = form.WindowState == FormWindowState.Maximized
                    ? Properties.Resources.screenNormal
                    : Properties.Resources.maximize;

            };
            BtnMaximize.MouseEnter += (s, e) =>
            {
                var form = FindForm();
                BtnMaximize.BackgroundImage = form.WindowState == FormWindowState.Maximized
                    ? Properties.Resources.screenNormalHover
                    : Properties.Resources.maximizeHover;
            };
            BtnMaximize.MouseLeave += (s, e) =>
            {
                var form = FindForm();
                BtnMaximize.BackgroundImage = form.WindowState == FormWindowState.Maximized
                    ? Properties.Resources.screenNormal
                    : Properties.Resources.maximize;
            };

            Button btnClose = CreateTaskBarButton(Properties.Resources.Exit);
            btnClose.Click += (s, e) => FindForm().Close();
            btnClose.MouseEnter += (s, e) => btnClose.BackgroundImage = Properties.Resources.ExitHover;
            btnClose.MouseLeave += (s, e) => btnClose.BackgroundImage = Properties.Resources.Exit;

            layoutPanelTaskBar = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.RightToLeft,
                Width = ButtonTaskBarWidth * 4,
                Height = this.Height, 
                Dock = DockStyle.Right,
                Padding = new Padding(0),
                BackColor = Color.Transparent,

            };
            

            btnMinimize.Margin = new Padding(0, -15, 0, 0);  // 60px - 30px = 30 → 15px top margin centers
            BtnMaximize.Margin = new Padding(0, -15, 0, 0);
            btnClose.Margin = new Padding(0, -15, 0, 0);

            layoutPanelTaskBar.Controls.Add(btnClose);
            layoutPanelTaskBar.Controls.Add(CreateEmptyPanel(8));
            layoutPanelTaskBar.Controls.Add(BtnMaximize);
            layoutPanelTaskBar.Controls.Add(CreateEmptyPanel(8));
            layoutPanelTaskBar.Controls.Add(btnMinimize);

            Controls.Add(layoutPanelTaskBar);
        }
        private Panel CreateEmptyPanel(int spacing) =>
                new Panel() { Width = spacing, Height = 1 };
        private void CreateTaskbarAction()
        {
            layoutPanelForm = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.LeftToRight,
                Width = Globals.User.IsLogging() ? ButtonFormWidth * 3 : ButtonFormWidth * 2,
                Height = ButtonFormHeight + 10,
                Location = new Point(0, 0),
                Left = searchBar.Left + searchBar.Width + 50,
                BackColor = Color.Transparent,
            };

            if (Globals.User.IsLogging())
            {

                Button logoutBtn = CreateFormButton(Properties.Resources.logOut);
                logoutBtn.Left = 150;

                logoutBtn.Click += (s, e) =>
                {
                    if (Globals.User.IsLogging())
                    {
                        Globals.User.Logout();
                    }
                    ((Acceuil)Parent).LoadFrontPage();
                };

                Button notificationBtn = CreateFormButton(Properties.Resources.notification);

                layoutPanelTaskBar.Controls.Add(CreateEmptyPanel(8));
                layoutPanelTaskBar.Controls.Add(notificationBtn);
                layoutPanelTaskBar.Controls.Add(CreateEmptyPanel(8));
                layoutPanelTaskBar.Controls.Add(logoutBtn);

            }
            else
            {
                // Sign In Button
                Button signInBtn = CreateFormButton(Properties.Resources.signIn);
                signInBtn.Left = 370;

                signInBtn.Click += (s, e) =>
                {
                    Acceuil.GetInstance().LoadSigningPage();
                };
                layoutPanelForm.Controls.Add(CreateEmptyPanel(8));
                layoutPanelForm.Controls.Add(signInBtn);

            }
            Controls.Add(layoutPanelForm);

        }

        private Button CreateFormButton(Image img)
        {
            Button btn = new Button()
            {
                BackgroundImage = img,
                BackgroundImageLayout = ImageLayout.Stretch,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Width = ButtonFormWidth,
                Height = ButtonFormHeight,
                Top = 10,
                Cursor = Cursors.Hand,

            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.TabStop = false;
            return btn;
        }

        private Button CreateTaskBarButton(Image img)
        {
            Button btn = new Button
            {
                Width = ButtonTaskBarWidth,
                Height = ButtonTaskBarHeight,
                BackgroundImage = img,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                BackgroundImageLayout = ImageLayout.Stretch,
                Cursor = Cursors.Hand,
            };

            btn.FlatAppearance.BorderSize = 0; // Remove border
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            
            return btn;
        }


        private void CenterElements()
        {
            CenterSearchBar();
            PlaceFormElements();
        }

        private void CenterSearchBar()
        {
            int newWidth;

            if (this.Width < 1000)
                newWidth = Math.Max(300, this.Width / 2); // Optional min size
            else
                newWidth = 600;

            // Update width and adjust internal layout
            searchBar.Width = newWidth;
            searchBar.ChangeWidthElements();

            // Center the bar after size update
            int x = (this.Width - searchBar.Width) / 2;
            int y = 7;
            searchBar.Location = new Point(x, y);
        }

        private void PlaceFormElements()
        {
            int newWidth;

            if (this.Width < 1000)
                newWidth = Math.Max(300, this.Width / 2); // Optional min size
            else
                newWidth = 600;

            // Center the bar after size update
            int x = (this.Width - searchBar.Width) / 2;
            int y = 7;
            searchBar.Location = new Point(x, y);


            layoutPanelForm.Left = searchBar.Left + searchBar.Width;

        }

        public void FaireAction() => (Globals.User.IsLogging() ? (Action)UserLoggedIn : (Action)UserLogedOut)();
        

        private void UserLoggedIn()
        {
            layoutPanelForm.Controls.Clear();
            layoutPanelForm.Width = ButtonFormWidth * 5;
            Button logoutBtn = CreateFormButton(Properties.Resources.logOut);

            logoutBtn.Click += (s, e) =>
            {
                if (Globals.User.IsLogging())
                {
                    Globals.User.Logout();
                }
                Acceuil.GetInstance().LoadFrontPage();
            };

            Button notificationBtn = CreateFormButton(Properties.Resources.notification);
            Button messagerieBtn = CreateFormButton(Properties.Resources.messagerie);


            layoutPanelForm.Controls.Add(CreateEmptyPanel(8));
            layoutPanelForm.Controls.Add(notificationBtn);
            layoutPanelForm.Controls.Add(CreateEmptyPanel(8));
            layoutPanelForm.Controls.Add(logoutBtn);
            layoutPanelForm.Controls.Add(CreateEmptyPanel(8));
            layoutPanelForm.Controls.Add(messagerieBtn);

            layoutPanelForm.Left = searchBar.Left + searchBar.Width;
        }
        private void UserLogedOut()
        {
            layoutPanelForm.Controls.Clear();
            Button signInBtn = CreateFormButton(Properties.Resources.signIn);
            signInBtn.Left = 370;

            signInBtn.Click += (s, e) =>
            {
                Acceuil.GetInstance().LoadSigningPage();
            };
            layoutPanelForm.Controls.Add(CreateEmptyPanel(8));
            layoutPanelForm.Controls.Add(signInBtn);
        }
    }
}
