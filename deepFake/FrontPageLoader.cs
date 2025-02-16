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

        public List<Panel> getPosts()
        {
            List<Panel> list = new List<Panel>();
            List<string[]> res = Handle.getTableContent("post_data");
            int x = 0;
            int y = 0;
            int nbPost = 0;
            for (int i = 0; i < res.Count; i++)
            {
                list.Add(CreatePostPanel(res[i][1], res[i][2], x, y));
                x += 350;
                nbPost++;
                if (nbPost % 3 == 0) {
                    y += 300;
                    x = 0;
                } 
            }
            return list;
        }

        private Panel CreatePostPanel(string title, string content, int x, int y)
        {
            Panel panelContenuePost = new Panel();
            Label Titre = new Label();
            Label Contenue = new Label();

            // Panel settings
            panelContenuePost.Location = new Point(x, y);
            panelContenuePost.Controls.Add(Titre);
            panelContenuePost.Controls.Add(Contenue);
            panelContenuePost.Size = new Size(333, 254);
            panelContenuePost.BorderStyle = BorderStyle.FixedSingle;

            // Title settings
            Titre.Location = new Point(0, 3);
            Titre.Size = new Size(325, 23);
            Titre.Text = title;
            

            // Content settings
            Contenue.Location = new Point(0, 32);
            Contenue.Size = new Size(325, 186);
            Contenue.Text = content;

            return panelContenuePost;
        }

    }
}
