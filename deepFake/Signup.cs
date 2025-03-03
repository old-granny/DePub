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

        private string VerifierUserInfos(string username, string name, string prename, string email, string password, string date)
        {
            // Ici devrait implementer quelque securiter supplemataire 
            // Verifie si texte contient charactere illigal
            // Verifier si mot de passe securitere
            // Verifier si le username exsite deja
            
            
            return "OK";

        }

        // Components Action
        private void button1_Click(object sender, EventArgs e)
        {
            string retour = VerifierUserInfos(UsernameTBX.Text, NameTXB.Text, PrenomTXB.Text, emailTXB.Text, passwordTXB.Text, dateTXB.Text);
            switch (retour)
            {
                case "OK":
                    conn.createNewUser(UsernameTBX.Text, NameTXB.Text, PrenomTXB.Text, emailTXB.Text, passwordTXB.Text, dateTXB.Text);
                    break;
                default:
                    break;
            }
            Main.LoadFrontPage();
        }

        private void GoBackLBL_Click(object sender, EventArgs e)
        {
            Main.LoadFrontPage(); // Aller a la page principale
        }
    }
}
