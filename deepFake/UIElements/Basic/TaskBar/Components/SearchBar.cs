using System;
using System.Drawing;
using System.Windows.Forms;

namespace deepFake.UIElements.Basic.TaskBar.Components
{
    internal class SearchBar : Panel
    {
        private Button search;
        private TextBox searchText;

        public SearchBar(Point pt)
        {
            InitializeComponent();
            Location = pt;
        }

        public SearchBar()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Styling for the search bar
            Width = 600;
            Height = 40;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;

            // Rounded corners
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));

            // Create search textbox
            searchText = new TextBox()
            {
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 14),
                Location = new Point(18, 10),
                Width = Width - 60,
                Height = Height - 20
            };
            Controls.Add(searchText);

            // Create search button
            search = new Button()
            {
                BackgroundImage = Properties.Resources.SearchIcon,
                BackgroundImageLayout = ImageLayout.Zoom,
                Size = new Size(18, 18),
                Location = new Point(Width - 35, 13),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };
            search.FlatStyle = FlatStyle.Flat;
            search.BackColor = Color.Transparent;
            search.FlatAppearance.BorderSize = 0;
            search.FlatAppearance.MouseOverBackColor = Color.Transparent;
            search.FlatAppearance.MouseDownBackColor = Color.Transparent;
            search.TabStop = false;
            
            Controls.Add(search);
        }

        // Windows API for rounded corners
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);


        public void ChangeWidthElements()
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            searchText.Width = this.Width - 60;
            search.Location = new Point(Width - 35, 13);
        }
    }
}
