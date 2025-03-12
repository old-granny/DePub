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
        // Form 
        private Acceuil Main;

        // Class 
        private FrontPageLoader FrontPageHandle;

        public FrontPage(Acceuil acceuil)
        {
            Main = acceuil;
            InitializeComponent();
            beautefull();
            LoadInstance();
            OnLoadPage();
        }

        private void beautefull()
        {
            this.BackColor = ColorTranslator.FromHtml("#E3DDE2");
            PanelContenuePublication.BackColor = ColorTranslator.FromHtml("#E3DDE2");
            PanelTop.BackColor = ColorTranslator.FromHtml("#554971");

        }


        private void LoadInstance()
        // Fonction qui vas servir a instancier les instances
        {
            FrontPageHandle = new FrontPageLoader();
        }


        public void LoadUserInfos(string name, int id)
        {
            //ProfilTitle.Text = name;
        }

        /// <summary>  
        /// TODO  
        /// </summary>
        public void OnLoadPage()
        {
            LoadFrontPage();
            if (Main.User != null)
            {
                LoadUserInfos(Main.User.Username, Main.User.id);
                panelSignin.Show();
                panelSign.Hide();
            }
            else
            {
                panelSignin.Hide();
                panelSign.Show();
            }
        }

        private void LoadFrontPage()
        {

            List<Panel> panelList = FrontPageHandle.getPosts(1);
            for (int i = 0; i < panelList.Count; i++)
            {
                PanelContenuePublication.Controls.Add(panelList[i]);
            }
            PanelContenuePublication.Show();
        }

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
            const string defaut = "Not Sign In";
            Main.User = null;
            //ProfilTitle.Text = defaut;
            Main.LoadFrontPage();
        }
    }
}
