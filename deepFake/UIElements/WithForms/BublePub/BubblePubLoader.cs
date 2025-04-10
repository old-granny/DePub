using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace deepFake.UIElements.WithForms.BublePub
{
    internal class BubblePubLoader : Panel
    {
        Label Titre;
        Label Content1;
        PictureBox ImagePublication;

        public BubblePubLoader(string titre, string content1, Image image)
        {
            LoadElements(titre, content1, image);
        }

        private void LoadElements(string titre, string content1, Image image)
        {
            // Panel styling
            this.BackColor = Color.WhiteSmoke;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Size = new Size(800, 400);
            this.Padding = new Padding(10);

            // Title Label with new styling
            Titre = new Label()
            {
                Location = new Point(10, 10),
                Text = titre,
                Size = new Size(280, 40),
                Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(54, 93, 217)
            };

            // Image with rounded corners styling
            ImagePublication = new PictureBox()
            {
                Location = new Point(10, 60),
                Size = new Size(80, 80),
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.Fixed3D
            };

            // Content Label with a refreshed look
            Content1 = new Label()
            {
                Location = new Point(100, 60),
                Text = content1,
                Size = new Size(180, 80),
                Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(64, 64, 64)
            };

            // Adding elements to the Panel
            this.Controls.Add(Titre);
            this.Controls.Add(ImagePublication);
            this.Controls.Add(Content1);
        }
    }
}