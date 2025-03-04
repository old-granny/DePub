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
            if (username.Length > Globals.MaximumUsernameCount || username.Length < Globals.MinimumUsernameCount || username.ToLower() == "username") return "USERNAME";
            if (name.Length > Globals.MaximumNameCount || name.Length < Globals.MinimumNameCount || name.ToLower() == "name") return "NAME";
            if (!Algorithme.IsValidEmail(email)) return "EMAIL";
            if (password.Length > Globals.MaximumPasswordCount|| password.Length < Globals.MinimumPasswordCount|| password.ToLower() == "password") return "PASSWORD";


            return "OK";

        }

        // Components Action
        private void button1_Click(object sender, EventArgs e)
        {
            string retour = VerifierUserInfos(UsernameTBX.Text, NameTXB.Text, PrenomTXB.Text, emailTXB.Text, passwordTXB.Text, dateTXB.Text);
            switch (retour)
            {
                case "OK":
                    if(!conn.createNewUser(UsernameTBX.Text, NameTXB.Text, PrenomTXB.Text, emailTXB.Text, passwordTXB.Text, dateTXB.Text))
                    {
                        GeneralMistake();
                    }
                    else
                    {
                        // everything worked
                        Main.LoadFrontPage();
                    }
                    break;
                case "USERNAME":
                    UsernameMistake();
                    break;
                case "PASSWORD":
                    PasswordMistake();
                    break;
                case "NAME":
                    NameMistake();
                    break;
                case "EMAIL":
                    EmailMistake();
                    break;

                default:
                    break;
            }
        }

        private void GoBackLBL_Click(object sender, EventArgs e)
        {
            Main.LoadFrontPage(); // Aller a la page principale
        }
        private void UsernameMistake()
        {
            ErrorListLB.Text = "Username Mistake";
            ErrorListLB.ForeColor = Color.Red;
        }
        private void PasswordMistake() 
        {
            ErrorListLB.Text = "Pasword Mistake";
            ErrorListLB.ForeColor = Color.Red;

        }
        private void NameMistake()
        {
            ErrorListLB.Text = "Name Mistake";
            ErrorListLB.ForeColor = Color.Red;
        }
        private void EmailMistake()
        {
            ErrorListLB.Text = "Email Mistake";
            ErrorListLB.ForeColor = Color.Red;
        }
        private void GeneralMistake()
        {
            // A completer
            ErrorListLB.Text = "General Mistake";
            ErrorListLB.ForeColor = Color.Red;
        }
    }
}
