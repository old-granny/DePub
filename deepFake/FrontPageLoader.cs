using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deepFake
{
    internal class FrontPageLoader
    {

        //Attribut
        
        // Instance Class
        private ComPostSQL Handle;

        public FrontPageLoader() 
        {
            Handle = new ComPostSQL();
        }

        public List<Panel> getPosts(int start)
        {
            // premiere etape serait de trouver le nombre de post total
            List<int> idPost = Handle.getIdPost(start); // Le nombre de post total
            int postToShow = idPost.Count;
            if(postToShow > 15) {
                // devrait implement un maximum, on en veut pas toute montrer les posts
                postToShow = 15;
            }

            int x = 100, y = 0; // Les position des posts

            int nbPostsLoader = 0;
            // Devrait trouver une facon qui pourrait fonctionnner si on veut pas necessairement les premier post
            List<Panel> list = new List<Panel>();
            for (int i = 0; i < postToShow; i++) {
                string[] ligne = Handle.getPostData("post_data", idPost[i]); // Ici le i est senser representer le id du post, vas surement launch une erreur
                List<Image> images = Handle.GetTableImages("post_data", idPost[i]);
                Panel panel = LoadRectanlges(ligne[0], ligne[1], x, y, images);
                list.Add(panel);
                nbPostsLoader++;
                x += 600;
                if (nbPostsLoader % 3 == 0) // Augmenter la position selon le le nombre de posts
                {
                    y += 900;
                    x = 0;
                }
                
            }
            
            return list;
        }

        private Panel CreatePostPanel(string title, string content, int x, int y, List<Image> images)
        {
            Panel panelContenuePost = new Panel();
            
            Label Titre = new Label();
            Label Contenue = new Label();
            BubblePub bubble = new BubblePub(title, content, images[0]);

            bubble.Show();

            panelContenuePost.Controls.Add(bubble);

            // Panel settings
            panelContenuePost.Location = new Point(x, y);
            //panelContenuePost.Controls.Add(Titre);
            //panelContenuePost.Controls.Add(Contenue);
            panelContenuePost.Size = new Size(1265, 900);
            panelContenuePost.BorderStyle = BorderStyle.FixedSingle;

            // Title settings
            Titre.Location = new Point(10, 3);
            Titre.Size = new Size(325, 50);
            Titre.Text = title;
            Titre.Font = new Font("Candara", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);



            // Content settings
            Contenue.Location = new Point(10, 50);
            Contenue.Size = new Size(1200, 150);
            Contenue.Text = content;
            Contenue.Font = new Font("Candara", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);

            
            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Size = new Size((int)(1920/2.5f), (int)(1080/2.5f));
            pictureBox.Name = $"pictpost";
            pictureBox.TabIndex = 0;
            pictureBox.Image = images[0]; // Image de titre
            pictureBox.Location = new Point(0, 300);
            //panelContenuePost.Controls.Add(pictureBox);
            

            return panelContenuePost;
        }

        public Panel LoadRectanlges(string title, string content, int x, int y, List<Image> images)
        {
            Panel pan1 = new Panel();
            pan1.BackgroundImage = Properties.Resources.LightBlueRect1;
            pan1.Size = new Size(500, 700);
            pan1.Location = new Point(x, y);


            // Titre 
            Label lbs = new Label();
            lbs.Text = title;
            lbs.Font = new Font("Candara", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbs.BackColor = Color.Transparent;
            lbs.Size = new Size(500, 100);
            lbs.Location = new Point(0, 0);
            pan1.Controls.Add(lbs);

            PictureBox pic = new PictureBox();
            pic.Location = new Point(50, 150);
            pic.Size = new Size(400, 250);
            pic.Image = images[0]; // Image de teste pour les posts
            pic.SizeMode = PictureBoxSizeMode.StretchImage;

            // Add rounded corners
            int cornerRadius = 35; // Adjust as needed
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(pic.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(pic.Width - cornerRadius, pic.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, pic.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();
            pic.Region = new Region(path);
            pan1.Controls.Add(pic);


            // Contenue subContenue
            Label contenueLBL = new Label();
            contenueLBL.Text = content;
            contenueLBL.Font = new Font("Candara", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contenueLBL.BackColor = Color.Transparent;
            contenueLBL.Size = new Size(500, 100);
            contenueLBL.Location = new Point(0, 500);
            pan1.Controls.Add(contenueLBL);



            pan1.Click += Pan1_Click;
            lbs.Click += Pan1_Click;
            contenueLBL.Click += Pan1_Click;
            pic.Click += Pan1_Click;
            
            return pan1;
        }

        private void Pan1_Click(object? sender, EventArgs e)
        {
            Console.WriteLine("hello");
        }

    }
}
