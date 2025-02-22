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
using Org.BouncyCastle.Crypto.Parameters;

namespace deepFake
{
    public partial class PublierPost : Form
    {
        private List<String> AbsoluteImagePath = new List<String>();
        private List<String> ListImageDejaFlow = new List<String>();
        private List<Image> ListImagesEnvoyer = new List<Image>();
        
        private Acceuil Main;
        private ComPostSQL Handle;
        public PublierPost(Acceuil acceuil)
        {
            Main = acceuil;
            Handle = new ComPostSQL();
            InitializeComponent();
        }

        private Panel CreatePanaelImage(int pos, string filename)
        {
            Panel panaelImage = new Panel();
            Label label = new Label();
            PictureBox pic = createPictureBoxe(pos, filename);
            // 
            // pictureBox1
            // 
            pic.Location = new Point(0, 3);
            pic.Size = new Size(473, 269);
            // 
            // label1
            // 
            label.AutoSize = true;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Location = new Point(457, 0);
            label.Name = $"label{pos}";
            label.Size = new Size(20, 22);
            label.TabIndex = 1;
            label.Text = "X";

            panaelImage.Controls.Add(label);
            panaelImage.Controls.Add(pic);
            panaelImage.Location = new Point(12, 12);
            panaelImage.Name = "panel1";
            panaelImage.Size = new Size(477, 276);
            panaelImage.TabIndex = 0;

            label.Click += LabelDeleteClick;

            return panaelImage;
        }

        private PictureBox createPictureBoxe(int pos, string filename)
        {
            PictureBox pic = new PictureBox();
            Image img = Image.FromFile(filename);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Size = new Size(300, 300);
            pic.Name = $"pict{pos}";
            pic.TabIndex = 0;
            pic.Image = img;

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
                if (!ListImageDejaFlow.Contains(fileName)) { 
                    ListImageDejaFlow.Add(fileName);
                    Panel pan = CreatePanaelImage(pos, fileName);
                    flowLayoutPanel1.Controls.Add(pan);
                    pos += 1;
                }
            }
        }
        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Main.LoadFrontPage();
        }

        private void LabelDeleteClick(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                string labelName = clickedLabel.Name;
                Console.WriteLine($"You clicked: {labelName}");
            }
        }
    }
}
