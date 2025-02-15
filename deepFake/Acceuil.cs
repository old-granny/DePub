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
            ScrollPub.Value = ScrollPub.Minimum;
            

            PanelPulication.VerticalScroll.Value = ScrollPub.Minimum;
            List<Panel> panelList = file.getPosts();
            for (int i = 0; i < panelList.Count; i++)
            {
                PanelPulication.Controls.Add(panelList[i]);
            }

            pagePublierPost.Show();
            panelInsidePost.Hide();

            Console.WriteLine(PanelPulication.VerticalScroll.Maximum / 2);
            ScrollPub.Maximum = (PanelPulication.VerticalScroll.Maximum) / 2;
            PanelPulication.VerticalScroll.Visible = false;
            PanelPulication.HorizontalScroll.Visible = false;
        }
        private void boutonPagePost_Click(object sender, EventArgs e)
        {
            panelInsidePost.Show();
            PanelPulication.Hide();
            pagePublierPost.FormBorderStyle = FormBorderStyle.None;
            panelInsidePost.Controls.Add(pagePublierPost);
            pagePublierPost.Show();
        }

        private void ScrollPub_Scroll(object sender, ScrollEventArgs e)
        {
            Console.WriteLine(ScrollPub.Value);
            PanelPulication.VerticalScroll.Value = ScrollPub.Value;
        }

        private void PanelPulication_Scroll(object sender, ScrollEventArgs e)
        {
            Console.WriteLine(PanelPulication.VerticalScroll.Maximum);
        }
    }
}
