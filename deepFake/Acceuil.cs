using System.Drawing.Printing;

namespace deepFake
{
    // Section Principale
    public partial class Acceuil : Form
    {
        // Form
        private PublierPost PublierPostPage;
        private FrontPage FrontPagePage;
        private Signup SignupPage;
        
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
            PublierPostPage = new PublierPost(this) { TopLevel = false, TopMost = true };
            FrontPagePage = new FrontPage(this) { TopLevel = false, TopMost = true };
            SignupPage = new Signup(this) { TopLevel = false, TopMost = true };
            forms.Add(PublierPostPage);
            forms.Add(FrontPagePage);
            forms.Add(SignupPage);
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
