namespace deepFake
{
    public partial class Acceuil : Form
    {
        private FileHandler file;
        private PublierPost pagePublierPost;

        public Acceuil()
        {
            InitializeComponent();
            file = new FileHandler();
            pagePublierPost = new PublierPost(file) { TopLevel = false, TopMost = true };
            panelInsidePost.Hide();
        }
        private void boutonPagePost_Click(object sender, EventArgs e)
        {
            panelInsidePost.Show();
            pagePublierPost.FormBorderStyle = FormBorderStyle.None;
            panelInsidePost.Controls.Add(pagePublierPost);
            pagePublierPost.Show();
        }
    }
}
