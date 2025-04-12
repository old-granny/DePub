using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deepFake.UIElements.WithForms.BublePub
{
    public partial class BubblePost : Form
    {
        Label LabelTitre;
        Acceuil Main;

        public BubblePost(Acceuil acceuil, string titre, List<string> format, List<Image> images, List<string> contents)
        {
            Main = acceuil;
            InitializeComponent();
            InstancierElement(titre, format, images, contents);
        }

        private void InstancierElement(string titre, List<string> format, List<Image> images, List<string> contents)
        {
            AddTitleLabel(titre);

            int imageIndex = 0;
            int contentIndex = 1;
            Point currentPosition = new Point(100, 100);
            Control lastControl = null;

            foreach (var entry in format)
            {
                if (string.IsNullOrWhiteSpace(entry))
                    continue;

                string type = entry.Length >= 5 ? entry[..5] : entry; 

                // Calculate next control position
                if (lastControl != null)
                {
                    currentPosition.Y = lastControl.Bottom + 100;
                }

                Control newControl = type switch
                {
                    "Input" => TryCreateLabel(contents, ref contentIndex, currentPosition),
                    "Image" => TryCreatePictureBox(images, ref imageIndex, currentPosition),
                    _ => null
                };

                if (newControl != null)
                {
                    MainPanel.Controls.Add(newControl);
                    lastControl = newControl;
                }
            }
        }

        private void AddTitleLabel(string title)
        {
            LabelTitre = new Label
            {
                Text = title,
                Size = new Size(100, 100),
                Dock = DockStyle.Top
            };
            MainPanel.Controls.Add(LabelTitre);
        }

        private Label TryCreateLabel(List<string> contents, ref int index, Point location)
        {
            if (index >= contents.Count || contents[index] == null) return null;
            return getLabel(contents[index++], location);
        }

        private PictureBox TryCreatePictureBox(List<Image> images, ref int index, Point location)
        {
            if (index >= images.Count || images[index] == null) return null;
            return getPictureBox(images[index++], location);
        }




        private PictureBox getPictureBox(Image img, Point pt)
        {
            PictureBox pic = new PictureBox()
            {
                Image = img,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = pt,
                Size = new Size(500, 500)
            };
            return pic;
        }

        private Label getLabel(string content, Point pt)
        {
            Label lab = new Label()
            {
                Text = content,
                Location = pt,
                Size = new Size(200, 200)
            };
            return lab;
        }












        private void retourBTN_Click(object sender, EventArgs e)
        {
            Main.LoadFrontPage();
        }
    }
}
