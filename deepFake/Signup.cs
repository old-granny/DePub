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

    public partial class Signup : Form
    {
        private ComUserSQL conn;
        private Acceuil Main;
        public Signup(Acceuil acceuil)
        {
            Main = acceuil;
            conn = new ComUserSQL();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.createNewUser(UsernameTBX.Text, NameTXB.Text, PrenomTXB.Text, emailTXB.Text, passwordTXB.Text, dateTXB.Text);
            Main.LoadFrontPage();
        }

        private void GoBackLBL_Click(object sender, EventArgs e)
        {
            Main.LoadFrontPage();
        }
    }
}
