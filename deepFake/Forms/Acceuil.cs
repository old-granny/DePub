using deepFake;
using System.Drawing.Printing;
using System.Security.Cryptography;

namespace deepFake
{

    /// <summary>
    /// Cette classe vas servir de controleur principale
    /// il vas toute gerer
    /// </summary>
    public partial class Acceuil : Form
    {
        
        public UserInstance User; // Instance de l'usager
        
        /*  Instance des Form  */
        private PublierPost PublierPostPage;
        private FrontPage FrontPagePage;
        private Signup SignupPage;
        private Signing SigningPage;
        /*  Instance des Form  */
        private Form currentActive = null; // Form active


        public Acceuil()
        {
            InitializeComponent(); // Fonction implementer automatiquement par .NET
            User = new UserInstance();

            CreationInstanceForm();
            Beautefull();
            LoadFrontPage();

        }

        /* Fonction complementaire au constructeur */
        private void CreationInstanceForm()
        {
            PublierPostPage = new PublierPost(this) { TopLevel = false, TopMost = true };
            FrontPagePage = new FrontPage(this) { TopLevel = false, TopMost = true };
            SignupPage = new Signup(this) { TopLevel = false, TopMost = true };
            SigningPage = new Signing(this) { TopLevel = false, TopMost = true };
        }

        private void Beautefull()
        {
            PanelLoadForm.BackColor = ColorTranslator.FromHtml("#FBE4D8");
        }
        /* Fonction complementaire au constructeur */



        /* Fonction public pour permettre de changer de form facillement */

        public void LoadFrontPage()
        {
            FrontPagePage.Cleanup();
            LoadFormInsidePanel(FrontPagePage);
        }
        public void LoadSignUpPage()
        {
            SignupPage.Cleanup();
            LoadFormInsidePanel(SignupPage);
        }
        public void LoadPublierPost()
        {
            PublierPostPage.Cleanup();
            LoadFormInsidePanel(PublierPostPage);
        }
        public void LoadSigningPage()
        {
            SigningPage.Cleanup();
            LoadFormInsidePanel(SigningPage);
        }
        /* Fonction public pour permettre de changer de form facillement */


        /* Fonction pour faciliter la tache des Loader de form */
        public bool LoadFormInsidePanel(Form form)
        {
            if (currentActive != null)
            {
                CloseFormInsidePanel(currentActive);
            }
            currentActive = form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
            PanelLoadForm.Controls.Add(form);
            return true;
        }

        private bool CloseFormInsidePanel(Form form)
        {
            form.Hide();
            return true;
        }
        /* Fonction pour faciliter la tache des Loader de form */


        public bool Cleanup()
        {
            return true;
        }
    }
}
