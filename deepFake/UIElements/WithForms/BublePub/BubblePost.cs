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
        // --- elements UI--- //
        Label LabelTitre;
        Acceuil Main;
        // --- elements UI --- //

        // --- Constante --- //
        private Point POINTTITRE = new Point(200, 200);
        // --- Consrante --- //

        // --- Attribut --- //
        int Y_Max = 0;
        int Y_Min = 0;
        // --- Attribut --- //

        public BubblePost(string titre, List<string> format, List<Image> images, List<string> contents)
        {
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

                Control newControl = null;

                switch (type)
                {
                    case "Input":
                        newControl = TryCreateLabel(contents, ref contentIndex, currentPosition);
                        Y_Min -= 300;
                        break;

                    case "Image":
                        newControl = TryCreatePictureBox(images, ref imageIndex, currentPosition);
                        Y_Min -= 400;
                        break;

                    default:
                        newControl = null;
                        break;
                }

                if (newControl != null)
                {
                    ScrollablePanel.Controls.Add(newControl);
                    lastControl = newControl;
                }
            }
            if(lastControl != null) retourBTN.Location = new Point(lastControl.Location.X, lastControl.Bottom + 100);
            else retourBTN.Location = new Point(0, 100);
            ScrollablePanel.Controls.Add(retourBTN);
        }
        private void AddTitleLabel(string title)
        {
            LabelTitre = new Label
            {
                Text = title,
                AutoSize = true, // Automatically size the label based on content
                Anchor = AnchorStyles.Top, // Only anchor to top to allow manual centering
                Location = new Point(0, 0), // Temp location, will be updated after adding
                Font = new Font("Candara", 24f, FontStyle.Bold, GraphicsUnit.Point, 0)

            };

            ScrollablePanel.Controls.Add(LabelTitre);

            // Center horizontally within the panel
            LabelTitre.Location = new Point(
                (ScrollablePanel.ClientSize.Width - LabelTitre.Width) / 2,
                0
            );

            // Optional: Handle resizing of the panel to keep label centered
            ScrollablePanel.Resize += (s, e) =>
            {
                LabelTitre.Location = new Point(
                    (ScrollablePanel.ClientSize.Width - LabelTitre.Width) / 2,
                    LabelTitre.Location.Y
                );
            };
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
                SizeMode = PictureBoxSizeMode.AutoSize,
                Size = new Size(800, 400)
            };

            // Placer au centre le Picture boxe
            pic.Location = new Point(
                (ScrollablePanel.ClientSize.Width - LabelTitre.Width) / 2,
                pt.Y
            );

            // Reposition automatiquement les elements selon les scrollable panels
            ScrollablePanel.Resize += (s, e) =>
            {
                pic.Location = new Point(
                    (ScrollablePanel.ClientSize.Width - LabelTitre.Width) / 2,
                    pic.Location.Y
                );
            };
            return pic;
        }

        private Label getLabel(string content, Point pt)
        {
            Label lab = new Label()
            {
                Text = content,
                Location = pt,
                AutoSize = true,
                Font = new Font("Candara", 18f, FontStyle.Regular, GraphicsUnit.Point, 0)
            };

            // Placer au centre le Picture boxe
            lab.Location = new Point(
                (ScrollablePanel.ClientSize.Width - LabelTitre.Width) / 2,
                pt.Y
            );

            // Reposition automatiquement les elements selon les scrollable panels
            ScrollablePanel.Resize += (s, e) =>
            {
                lab.Location = new Point(
                    (ScrollablePanel.ClientSize.Width - LabelTitre.Width) / 2,
                    lab.Location.Y
                );
            };
            return lab;
        }



        private void ScrollablePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            int scrolled = e.Delta;
            if (ScrollablePanel.Location.Y + scrolled < Y_Max && ScrollablePanel.Location.Y + scrolled > Y_Min)
                ScrollablePanel.Location = new Point(ScrollablePanel.Location.X, ScrollablePanel.Location.Y + scrolled);
        }

        private void retourBTN_Click(object sender, EventArgs e)
        {
            Main.LoadFrontPage();
        }
    }
}
