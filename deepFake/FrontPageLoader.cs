using System;
using System.Collections.Generic;
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

            int x = 0, y = 0; // Les position des posts

            int nbPostsLoader = 0;
            // Devrait trouver une facon qui pourrait fonctionnner si on veut pas necessairement les premier post
            List<Panel> list = new List<Panel>();
            for (int i = 0; i < postToShow; i++) {
                string[] ligne = Handle.getPostData("post_data", idPost[i]); // Ici le i est senser representer le id du post, vas surement launch une erreur
                List<Image> images = Handle.GetTableImages("post_data", idPost[i]);
                Panel panel = CreatePostPanel(ligne[0], ligne[1], x, y, images);
                list.Add(panel);
                nbPostsLoader++;
                y += 700;
                if (nbPostsLoader % 3 == 0) // Augmenter la position selon le le nombre de posts
                {
                    y += 300;
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

            // Panel settings
            panelContenuePost.Location = new Point(x, y);
            panelContenuePost.Controls.Add(Titre);
            panelContenuePost.Controls.Add(Contenue);
            panelContenuePost.Size = new Size(650, 550);
            panelContenuePost.BorderStyle = BorderStyle.FixedSingle;

            // Title settings
            Titre.Location = new Point(0, 3);
            Titre.Size = new Size(325, 23);
            Titre.Text = title;
            

            // Content settings
            Contenue.Location = new Point(0, 32);
            Contenue.Size = new Size(325, 100);
            Contenue.Text = content;

            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Size = new Size((int)1920/3, (int)1080/3);
            pictureBox.Name = $"pictpost";
            pictureBox.TabIndex = 0;
            pictureBox.Image = images[0]; // Image de titre
            pictureBox.Location = new Point(0, 150);
            panelContenuePost.Controls.Add(pictureBox);
            return panelContenuePost;
        }

    }
}
