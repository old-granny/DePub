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

        public FrontPageLoader()
        {
            Handle = new ComPostSQL();
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
            for (int i = 0; i < postToShow; i++)
            {
                string[] ligne = Handle.getPostData("post_data", idPost[i]); // Ici le i est senser representer le id du post, vas surement launch une erreur
                List<Image> images = Handle.GetTableImages("post_data", idPost[i]);
                Panel panel = new BubblePubLoader(ligne[i], ligne[i], images[i]);
                list.Add(panel);
                nbPostsLoader++;
                x += 600;
                if (nbPostsLoader % 3 == 0) // Augmenter la position selon le le nombre de posts
                {
                    y += 900;
                    x = 100;
                }
            }

            return list;
        }
    }
}
