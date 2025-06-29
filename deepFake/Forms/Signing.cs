using deepFake.SQL;
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
    public partial class Signing : Form
    {
        private ComUserSQL Conn;
        private Acceuil Main;

        public Signing(Acceuil acceuil)
        {
            Conn = ComUserSQL.Instance;
            Main = acceuil;
            InitializeComponent();
            Beautiful();
        }


        private void Beautiful()
        {
            //PanelGrosLogo.BackgroundImage = Properties.Resources.LogosGros;
            //PanelPhrase.BackgroundImage = Properties.Resources.Phrase;
        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            string username = UsernameTXB.Text;
            string password = PasswordTXB.Text;
            if (Conn.SigningCheck(username, password)) {
                Globals.User.Login(username, 1);
                Main.LoadFrontPage();
            }
            else
            {
                ResultLBL.BackColor = Color.Red;
                ResultLBL.Text = "Fail";

            }

        }

        private void UsernameTXB_Enter(object sender, EventArgs e)
        {
            const string DEFAUT = "Username";
            if (UsernameTXB.Text == DEFAUT)
            {
                UsernameTXB.Clear();
            }
        }

        private void PasswordTXB_Enter(object sender, EventArgs e)
        {
            const string DEFAUT = "Password";
            if (PasswordTXB.Text == DEFAUT)
            {
                PasswordTXB.Clear();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Main.LoadFrontPage();
        }
        public bool Cleanup()
        {
            return true;
        }
    }
}
