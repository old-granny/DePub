using deepFake.Handlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deepFake
{

    public partial class FrontPage : Form
    {
        /* Instance de Forms */
        /* Instance de Forms */


        public Panel PublicationPanel => PanelContenuePublication;
        /* Instance de Main attend un acceuil */
        private Acceuil Main;

        /*  Instance des classes Helpers  */ 
        private FrontPageLoader FrontPageHandle;

        public FrontPage(Acceuil acceuil)
        {
            InitializeComponent();

            Main = acceuil;
            this.Name = "FrontPage";
            
            Beautefull();
            LoadInstance();
            LoadPosts(0, 10);
        }

        /* Fonction helper pour le constructeur */
        private void Beautefull()
        {
            
        }
        private void LoadInstance()
        {
            FrontPageHandle = new FrontPageLoader(Main);
        }


        public void LoadPosts(int startPos, int maxPost)
        {
            List<Panel> panelList = FrontPageHandle.getPosts(1);
            int nbPost = 0;
            for (int i = startPos; i < panelList.Count; i++)
            {
                if (nbPost >= maxPost) break;
                PanelContenuePublication.Controls.Add(panelList[i]);
                nbPost++;
            }
            PanelContenuePublication.Show();
        }
        public bool Cleanup()
        {
            return true;
        }

        public void ReloadPosts(int startPos, int maxPost)
        {
            PanelContenuePublication.Controls.Clear();
            List<Panel> panelList = FrontPageHandle.getPosts(1);
            int nbPost = 0;
            for (int i = startPos; i < panelList.Count; i++)
            {
                if (nbPost >= maxPost) break;
                PanelContenuePublication.Controls.Add(panelList[i]);
                nbPost++;
            }
            PanelContenuePublication.Show();
        }
    }
}
