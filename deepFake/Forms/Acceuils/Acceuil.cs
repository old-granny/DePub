using deepFake;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System;
using FormsTimer = System.Windows.Forms.Timer;
using deepFake.UIElements.Basic;



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
            InstancierComposants();
            LoadFrontPage();

        }

        private void InstancierComposants()
        {
            TaskBar taskBar = new TaskBar();
            this.Controls.Add(taskBar);
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
            
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false; // optional: removes minimize/maximize/close buttons
            this.Text = string.Empty; // optional: removes title text
            this.BackColor = ColorTranslator.FromHtml("#5796AD");

        }
        /* Fonction complementaire au constructeur */


        /* Fonction public pour permettre de changer de form facillement */

        public void LoadFrontPage()
        {
            // Clean up previous control if needed
            if (currentActive != null)
            {
                if (PanelLoadForm.Controls.Contains(currentActive))
                    PanelLoadForm.Controls.Remove(currentActive);
            }

            // Clear previous controls from the container panel
            PanelLoadForm.Controls.Clear();

            // Add just the publication panel directly
            Panel publicationPanel = FrontPagePage.PublicationPanel;

            // Optional: reload posts before showing
            FrontPagePage.ReloadPosts(0, 10);

            publicationPanel.Dock = DockStyle.Fill;
            PanelLoadForm.Controls.Add(publicationPanel);

            currentActive = null; // since we are not showing the full form anymore
        }

        public void LoadSignUpPage()
        {
            if (currentActive != null)
            {
                if (PanelLoadForm.Controls.Contains(currentActive))
                    PanelLoadForm.Controls.Remove(currentActive);
            }

            // Clear previous controls from the container panel
            PanelLoadForm.Controls.Clear();

            SignupPage.Cleanup();
            LoadFormInsidePanel(SignupPage);
        }
        public void LoadPublierPost()
        {
            if (currentActive != null)
            {
                if (PanelLoadForm.Controls.Contains(currentActive))
                    PanelLoadForm.Controls.Remove(currentActive);
            }

            // Clear previous controls from the container panel
            PanelLoadForm.Controls.Clear();

            PublierPostPage.Cleanup();
            LoadFormInsidePanel(PublierPostPage);
        }
        public void LoadSigningPage()
        {
            if (currentActive != null)
            {
                if (PanelLoadForm.Controls.Contains(currentActive))
                    PanelLoadForm.Controls.Remove(currentActive);
            }

            // Clear previous controls from the container panel
            PanelLoadForm.Controls.Clear();

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
