using deepFake;
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
            User = new UserInstance();
            User.Username = "hello";
            User.id= 1;
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
            form.Hide();
            return true;
        }

        public bool Cleanup()
        {
            return true;
        }
    }
}
