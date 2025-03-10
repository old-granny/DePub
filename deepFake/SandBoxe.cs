using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deepFake
{
    public partial class SandBoxe : Form
    {
        public SandBoxe()
        {
            InitializeComponent();
            panel1.BackColor = ColorTranslator.FromHtml("#E3DDE2");
            panel2.BackColor = ColorTranslator.FromHtml("#554971");
            int x = 100, y = 10;
            for (int i = 0; i< 10; i++) { 
                LoadRectanlges(x, y);
                x += 600;
                if(i % 3 == 0 && i!=0)
                {
                    x = 100;
                    y += 800;
                }
            }
            
        }

        public void LoadRectanlges(int x, int y)
        {
            Panel pan1 = new Panel();
            pan1.BackgroundImage = Properties.Resources.LightBlueRect1;
            pan1.Size = new Size(500, 700);
            pan1.Location = new Point(x, y);
            panel1.Controls.Add(pan1);
            

            // Titre 
            Label lbs = new Label();
            lbs.Text = "Ceci est un titre vraiment palpitant sur les neuves";
            lbs.Font = new Font("Candara", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbs.BackColor = Color.Transparent;
            lbs.Size = new Size(500,100);
            lbs.Location = new Point(0, 0);
            pan1.Controls.Add(lbs);

            PictureBox pic = new PictureBox();
            pic.Location = new Point(50, 150);
            pic.Size = new Size(400, 250);
            pic.Image = Properties.Resources.background2; // Image de teste pour les posts
            pic.SizeMode = PictureBoxSizeMode.StretchImage;

            // Add rounded corners
            int cornerRadius = 35; // Adjust as needed
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(pic.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(pic.Width - cornerRadius, pic.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, pic.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();
            pic.Region = new Region(path);
            pan1.Controls.Add(pic);


            // Contenue subContenue
            Label contenueLBL = new Label();
            contenueLBL.Text = "Ceci est du contenue vraiment palpitant sur les neuves , " +
                "meme s'il sont weird je les aime bien, car il sont encore innoncent fasse a " +
                "l'universite. Moi aussi je suios encore une neuves mais je viens bientot en finir";
            contenueLBL.Font = new Font("Candara", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contenueLBL.BackColor = Color.Transparent;
            contenueLBL.Size = new Size(500, 100);
            contenueLBL.Location = new Point(0, 500);
            pan1.Controls.Add(contenueLBL);



            pan1.Click += Pan1_Click;
            lbs.Click += Pan1_Click;
            contenueLBL.Click += Pan1_Click;
            pic.Click += Pan1_Click;
        }

        private void Pan1_Click(object? sender, EventArgs e)
        {
            Console.WriteLine("hello");
        }
    }
}
