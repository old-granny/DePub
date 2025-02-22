using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deepFake
{
    public partial class PublierPost : Form
    {
        private List<String> AbsoluteImagePath = new List<String>();
        private List<PictureBox> PictureBXList = new List<PictureBox>();
        private Acceuil Main;
        private ComPostSQL Handle;
        public PublierPost(Acceuil acceuil)
        {
            Main = acceuil;
            Handle = new ComPostSQL();
            InitializeComponent();
        }


        private PictureBox createPictureBoxe(int pos, int width, int height)
        {
            PictureBox pic = new PictureBox();
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Size = new Size(300, 300);
            pic.Location = new Point(pos * 3, pos*3);
            pic.Name = $"pict{pos}";
            pic.TabIndex = 0;

            return pic;
        }

        private void boutonPost_Click(object sender, EventArgs e)
        {
            string content = Contenue.Text;
            string title = Titre.Text;
            Handle.insertIntoData(title, content);

            Main.LoadFrontPage();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.AddExtension = true;
            ofd.Multiselect = true;
            ofd.Filter = "All Files|*.png;*.jpeg;*.jpg;";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string fileName in ofd.FileNames)
                {
                    AbsoluteImagePath.Add(fileName);
                }
                UpdateLabelimage();
            }

        }

        private void UpdateLabelimage()
        {
            int pos = 0;
            foreach (string fileName in AbsoluteImagePath)
            {
                Image img = Image.FromFile(fileName);
                PictureBox pan = createPictureBoxe(pos, img.Width, img.Height);
                pan.Image = img;
                if (!PictureBXList.Contains(pan)) {
                    PictureBXList.Add(pan);
                }
                pos++;
            }
            foreach (PictureBox pan in PictureBXList)
            {
                flowLayoutPanel1.Controls.Add(pan);
            }
        }
        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Main.LoadFrontPage();
        }
    }
}
