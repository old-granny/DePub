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
        private Acceuil Main;
        private ComPostSQL Handle;
        public PublierPost(Acceuil acceuil)
        {
            Main = acceuil;
            Handle = new ComPostSQL();
            InitializeComponent();
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
                Label label2 = new Label();
                Image img = Image.FromFile(fileName);
                label2.AutoSize = true;
                label2.Name = $"label{pos}";
                label2.Size = new Size(img.Width, img.Height);
                label2.TabIndex = 1;
                label2.Image = img;
                flowLayoutPanel1.Controls.Add(label2);
                pos +=1;
            }
        }
        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Main.LoadFrontPage();
        }
    }
}
