using deepFake.SQL;
using deepFake.UIElements;
using deepFake.UIElements.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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


        private LoginInputs Username;
        private LoginInputs Password;

        private LoginButton LogButton;
        private LoginButton GoBack;

        public Signing()
        {
            Conn = ComUserSQL.Instance;
            Main = Acceuil.GetInstance();
            InitializeComponent();
            CreateComponents();
            Beautiful();

        }

        private void CreateComponents()
        {
            GrosLogo.BackgroundImage = Properties.Resources.LogosGros;
            PhraseIntro.BackgroundImage = Properties.Resources.Phrase;

            Username = new LoginInputs("Username");
            Password = new LoginInputs("Password");

            Username.Width = flowPanelForm.Width;
            Password.Width = flowPanelForm.Width;

            flowPanelForm.Controls.Add(Username);
            flowPanelForm.Controls.Add(Password);

            Panel forgotPasswordPanel = new Panel()
            {
                Width = flowPanelForm.Width,
                Height = 30,
            };
            Label forgotPasswordLabel = new Label()
            {
                Text = "Forgot your password?",
                ForeColor = ColorTranslator.FromHtml("#0048FF"),
                Location = new Point(forgotPasswordPanel.Width / 2, forgotPasswordPanel.Height / 3)
            };
            forgotPasswordPanel.Controls.Add(forgotPasswordLabel);
            flowPanelForm.Controls.Add(forgotPasswordPanel);

            LogButton = new LoginButton(ColorTranslator.FromHtml("#ffffff"), ColorTranslator.FromHtml("#545454"), "Login");
            GoBack = new LoginButton(ColorTranslator.FromHtml("#ffffff"), ColorTranslator.FromHtml("#000000"), "Go back");

            LogButton.Width = flowPanelForm.Width;
            GoBack.Width = flowPanelForm.Width;

            flowPanelForm.Controls.Add(LogButton);
            flowPanelForm.Controls.Add(GoBack);

            Panel createAccountPanel = new Panel()
            {
                Width = flowPanelForm.Width,
                Height = 30,
            };
            Label createAccountLabel = new Label()
            {
                Text = "Don't have a account ?",
                ForeColor = ColorTranslator.FromHtml("#0048FF"),
                Location = new Point(createAccountPanel.Width / 2, createAccountPanel.Height / 3)
            };
            createAccountPanel.Controls.Add(createAccountLabel);
            flowPanelForm.Controls.Add(createAccountPanel);
        }

        private void Beautiful()
        {
            // Changer la couleur de fond du panneau de droite
            RightSidePanel.BackColor = ColorTranslator.FromHtml("#5796AD");
            flowPanelForm.Left = FormPanel.Left;
            flowPanelForm.Width = FormPanel.Width;
        }


        private void LoginBTN_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;
            if (Conn.SigningCheck(username, password))
            {
                Globals.User.Login(username, 1);
                Main.LoadFrontPage();
            }
            else
            {
                LogButton.BackColor = Color.Red;

            }

        }

        private void UsernameTXB_Enter(object sender, EventArgs e)
        {
            const string DEFAUT = "Username";
            if (Username.Text == DEFAUT)
            {

            }
        }

        private void PasswordTXB_Enter(object sender, EventArgs e)
        {
            const string DEFAUT = "Password";
            if (Password.Text == DEFAUT)
            {

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
