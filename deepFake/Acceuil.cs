using System.Drawing.Printing;
using System.Security.Cryptography;

namespace deepFake
{
    // Section Principale
    public partial class Acceuil : Form
    {
        public UserInstance User;

        // Form
        private PublierPost PublierPostPage;
        private FrontPage FrontPagePage;
        private Signup SignupPage;
        private Signing SigningPage;

        // Form
        private Form currentActive = null;
        

        // Attribut
        List<Form> forms = new List<Form>();


        public Acceuil()
        {
            InitializeComponent();
            InstancierAttribut();
            Beautefull();
            OnLoadPage();

        }

        private void OnLoadPage()
        {
            LoadFrontPage();
        }

        private void InstancierAttribut()
        {
            User = null;
            // Forms
            PublierPostPage = new PublierPost(this) { TopLevel = false, TopMost = true };
            FrontPagePage = new FrontPage(this) { TopLevel = false, TopMost = true };
            SignupPage = new Signup(this) { TopLevel = false, TopMost = true };
            SigningPage = new Signing(this) { TopLevel = false, TopMost = true };
        }
        private void Beautefull()
        {
            PanelLoadForm.BackColor = ColorTranslator.FromHtml("#FBE4D8");

        }


        public void LoadFrontPage()
        {
            LoadFormInsidePanel(FrontPagePage);
            FrontPagePage.OnLoadPage();

        }

        public void LoadSignUpPage()
        {
            LoadFormInsidePanel(SignupPage);
        }
        public void LoadPublierPost()
        {
            LoadFormInsidePanel(PublierPostPage);
        }
        public void LoadSigningPage()
        {
            LoadFormInsidePanel(SigningPage);
        }

        private bool LoadFormInsidePanel(Form form)
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
            form.Close();
            return true;
        }
    }
}
