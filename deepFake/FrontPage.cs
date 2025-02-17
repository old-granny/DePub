using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            LoadInstance();
            OnLoadPage();
        }

        private void LoadInstance()
        {
            FrontPageHandle = new FrontPageLoader();
        }

        public void OnLoadPage()
        {
            LoadFrontPage();
        }

        private void LoadFrontPage()
        {

            List<Panel> panelList = FrontPageHandle.getPosts();
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
            Main.LoadSignUpPage();
        }
    }
}
