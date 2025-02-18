using System.Drawing.Printing;

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
        

        // Attribut
        List<Form> forms = new List<Form>();


        public Acceuil()
        {
            InitializeComponent();
            InstancierAttribut();
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
            
            forms.Add(PublierPostPage);
            forms.Add(FrontPagePage);
            forms.Add(SignupPage);
            forms.Add(SigningPage);
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
            CloseFormInsidePanel();
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
            PanelLoadForm.Controls.Add(form);
            return true;
        }

        private bool CloseFormInsidePanel()
        {
            PanelLoadForm.Controls.Clear();
            return true;
        }
    }
}
