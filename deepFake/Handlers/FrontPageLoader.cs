using deepFake.SQL;
using deepFake.UIElements.WithForms.BublePub;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deepFake.Handlers
{
    internal class FrontPageLoader
    {
        const int MAX_POST = 15;

        //Attribut
        // Instance Class
        private ComPostSQL Handle;
        private Acceuil Main;

        public FrontPageLoader(Acceuil acceuil)
        {
            Main = acceuil;
            Handle = ComPostSQL.Instance;
        }

        public List<Panel> getPosts(int start)
        {

            List<int> idPost = Handle.getIdPost(start); // Allez chercher les ids des publication de la base de donnees

            int postToShow = idPost.Count; // nb Total des posts
            if (postToShow > MAX_POST) postToShow = MAX_POST;

            int x = 100, y = 50; // Les position des posts

            int nbPostsLoader = 0;
            // Devrait trouver une facon qui pourrait fonctionnner si on veut pas necessairement les premier post
            List<Panel> list = new List<Panel>();
            for (int i = 0; i < idPost.Count; i++)
            {
                List<string> lignes = Handle.getPostData("post_data", idPost[i]); // Ici le i est senser representer le id du post, vas surement launch une erreur
                List<Image> images = Handle.GetTableImages("post_data", idPost[i]);
                string format = Handle.GetFormatWithId("post_data", idPost[i]);
                Panel panel = new BubblePubLoader(Main, lignes[0], format, lignes, images);
                panel.Location = new Point(x, y);
                list.Add(panel);
                nbPostsLoader++;
                x += panel.Width + 50;
                if (nbPostsLoader % 3 == 0) // Augmenter la position selon le le nombre de posts
                {
                    y += 700;
                    x = 100;
                }
            }

            return list;
        }
    }
}
