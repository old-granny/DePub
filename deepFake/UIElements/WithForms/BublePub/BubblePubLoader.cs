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
        BubblePost BubblePostForm;

        Acceuil Main;

        int Ratio;
        Random Gen;

        List<int[]> RatioPossible = new List<int[]>();
        public BubblePubLoader(Acceuil acceuil, string titre, string format, List<string> contents, List<Image> images)
        {
            Main = acceuil;
            LoadAttribut();
            LoadThisStyle();
            LoadElements(titre, contents, images);
            BubblePostForm = new BubblePost(Main, titre, Algorithme.FormaterFormatPost(format), images, contents) { TopLevel = false, TopMost = true };
        }

        private void LoadAttribut()
        {
            Gen = new Random();

            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;

            RatioPossible.Clear();

            int minWidth = (int)(area.Width * 0.25);  
            int maxWidth = (int)(area.Width * 0.3);  

            int minHeight = (int)(area.Height * 0.4); 
            int maxHeight = (int)(area.Height * 0.6); 

            for (int i = 0; i < 10; i++)
            {
                int width = Gen.Next(minWidth, maxWidth + 1);
                int height = Gen.Next(minHeight, maxHeight + 1);

                RatioPossible.Add(new int[2] { width, height });
            }
        }


        private void LoadThisStyle()
        {
            int pos = Gen.Next(0, RatioPossible.Count - 1);
            this.Size = new Size(RatioPossible[pos][0], RatioPossible[pos][1]);
            this.BackColor = Color.FromArgb(200, 200, 200);
        }

        private void LoadElements(string titre, List<string> contents, List<Image> images)
        {
            // Title Label
            Titre = new Label()
            {
                Location = new Point(10, 10),
                Text = titre,
                Size = new Size(280, 40),
                Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point),
            };

            // Create PictureBox without fixed size
            ImagePublication = new PictureBox()
            {
                Image = images[0],
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            this.Resize += (s, e) =>
            {
                int margin = 40;
                int availableWidth = this.ClientSize.Width - margin * 2;

                // Maintain image aspect ratio
                double aspectRatio = (double)images[0].Height / images[0].Width;
                int width = availableWidth;
                int height = (int)(width * aspectRatio);

                ImagePublication.Size = new Size(width, height);
                ImagePublication.Location = new Point(margin, Titre.Bottom + 10);
            };

            // Force trigger initial layout
            this.Resize += null;
            this.OnResize(EventArgs.Empty);

            // Content Label
            Content1 = new Label()
            {
                Location = new Point(100, ImagePublication.Bottom + 10), // Will be repositioned after Resize
                Text = contents[0],
                Size = new Size(180, 80),
                Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(64, 64, 64)
            };

            this.Controls.Add(Titre);
            this.Controls.Add(ImagePublication);
            this.Controls.Add(Content1);


            Titre.Click += Click_LoadBubblePost;
            ImagePublication.Click += Click_LoadBubblePost;
            Content1.Click += Click_LoadBubblePost;
            this.Click += Click_LoadBubblePost;
        }

        private void Click_LoadBubblePost(object? sender, EventArgs e)
        {
            Main.LoadFormInsidePanel(BubblePostForm);
        }
    }
}