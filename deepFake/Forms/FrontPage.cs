using deepFake;
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
            this.BackColor = ColorTranslator.FromHtml("#E3DDE2");
            PanelContenuePublication.BackColor = ColorTranslator.FromHtml("#E3DDE2");
            PanelTop.BackColor = ColorTranslator.FromHtml("#554971");

        }
        private void LoadInstance()
        {
            FrontPageHandle = new FrontPageLoader();
        }
        /* Fonction helper pour le constructeur */

        /* Methode de Front page */

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


        /*--- Action des boutons ---*/
        private void boutonPagePost_Click(object sender, EventArgs e)
        {
            Main.LoadPublierPost();
        }

        private void BTNSignin_Click(object sender, EventArgs e)
        {
            Main.LoadSigningPage();
        }

        private void BTNSignup_Click(object sender, EventArgs e)
        {
            Main.LoadSignUpPage();
        }

        private void SignoutBTN_Click(object sender, EventArgs e)
        {
            Main.LoadFrontPage();
        }

        /*--- Action des boutons ---*/


        public bool Cleanup()
        {
            return true;
        }
    }
}
