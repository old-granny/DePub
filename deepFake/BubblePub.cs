using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deepFake
{
    public partial class BubblePub : Panel
    {
        public BubblePub(string titre, string contenue, Image image)
        {
            InitializeComponent(titre, contenue, image);
        }
        private void InitializeComponent(string titre, string contenue, Image image)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acceuil));
            PictureBox pictureBox1 = new PictureBox();
            Label TitreLb = new Label();
            Label contenueLb = new Label();
            PictureBox imagePub = new PictureBox();
            //
            // ImagePub
            //
            Console.WriteLine(image.Width);
            imagePub.Image = image;
            imagePub.Size = new Size(300, 300);
            imagePub.SizeMode = PictureBoxSizeMode.StretchImage;
            imagePub.TabIndex = 1;
            imagePub.Location = new Point(0, 0);
            imagePub.Name = "imagePub";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectanglePUB;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(745, 746);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // TitreLb
            // 
            TitreLb.Parent = pictureBox1;
            TitreLb.BackColor = Color.Transparent;
            TitreLb.AutoSize = true;
            TitreLb.Font = new Font("Candara Light", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TitreLb.Location = new Point(314, 39);
            TitreLb.Name = "Lb";
            TitreLb.Size = new Size(108, 45);
            TitreLb.TabIndex = 1;
            TitreLb.Text = titre;
            // 
            // TitreLb
            // 
            contenueLb.Parent = pictureBox1;
            contenueLb.BackColor = Color.Transparent;
            contenueLb.AutoSize = true;
            contenueLb.Font = new Font("Candara Light", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contenueLb.Location = new Point(314, 39);
            contenueLb.Name = "LbContenue";
            contenueLb.Size = new Size(100, 100);
            contenueLb.TabIndex = 1;
            contenueLb.Text = contenue;
            // 
            // panel1
            // 
            this.Controls.Add(TitreLb);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(imagePub);
            this.Location = new Point(77, 24);
            this.Name = "panel1";
            this.Size = new Size(746, 747);
            this.TabIndex = 2;
        }
    }
}
