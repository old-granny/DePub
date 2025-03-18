using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using deepFake;
using deepFake.Elements;
using Org.BouncyCastle.Crypto.Parameters;

namespace deepFake
{
    public partial class PublierPost : Form
    {
        private List<InputTexte> inputTexteList = new List<InputTexte>();

        private List<String> AbsoluteImagePath = new List<String>();
        private List<String> ListImageDejaFlow = new List<String>();

        private Dictionary<Panel, byte[]> PanelImageDict = new Dictionary<Panel, byte[]>();
        private List<Image> ListImagesEnvoyer = new List<Image>();
        private List<Panel> ListPanelsActive = new List<Panel>();


        private int Pos = 0;
        
        // Attribut
        private Acceuil Main;
        private ComPostSQL Handle;

        // Element contenue
        private InputTexte InputeTitre;
        private AddElement Element1;

        public PublierPost(Acceuil acceuil)
        {
            Main = acceuil;
            Handle = new ComPostSQL();
            InitializeComponent();
            InitializeElement();
            Beautefull();
        }

        private void InitializeElement()
        {
            Point pos = new Point(200, 100);
            Size size = new Size(800, 50);

            InputeTitre = new InputTexte("Input title", size, 50, false, false);
            InputeTitre.Location = pos;
            InputeTitre.Name = "texte1";

            ScrollablePanel.Controls.Add(InputeTitre);

            Element1 = new AddElement();
            Element1.Location = new Point(200, 200);
            ScrollablePanel.Controls.Add(Element1);

            Element1.ajouterImageBtn.Click += AjouterImageBtn_Click;
            Element1.ajouterTexteBtn.Click += AjouterTexteBtn_Click;

        }

        private void AjouterTexteBtn_Click(object? sender, EventArgs e)
        {
            if (inputTexteList.Count < 3)
            {
                InputTexte inputT = new InputTexte("input1", new Size(800, 200), 1000, true, true);
                inputT.Location = GetNextInputTextePoint();
                inputTexteList.Add(inputT);
                ScrollablePanel.Controls.Add(inputT);
            }
        }
        private Point GetNextInputTextePoint()
        {
            Point pt = new Point(-1000, -1000);

            switch (inputTexteList.Count)
            {
                case 0:
                    pt.X = 200;
                    pt.Y = 400;
                    break;
                case 1:
                    pt.X = 200;
                    pt.Y = 600;
                    break;
                case 2:
                    pt.X = 200;
                    pt.Y = 800;
                    break;
                default:
                    return pt;
            }
            return pt;
        }

        private void AjouterImageBtn_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Beautefull()
        {
            PanelContenue.BackColor = ColorTranslator.FromHtml("#E3DDE2");
            PanelPost.BackColor = Color.White;
        }

        

























        private Panel CreatePanaelImage(string filename)
        {
            Panel panaelImage = new Panel();
            Label label = new Label();
            byte[] img_bytes = File.ReadAllBytes(filename);
            Image img = (Bitmap)((new ImageConverter()).ConvertFrom(img_bytes));
            //Image img = Image.FromFile(filename);
            PictureBox pic = createPictureBoxe(img);
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
            label.Name = filename + Pos.ToString();
            label.Size = new Size(20, 22);
            label.TabIndex = 1;
            label.Text = "X";

            panaelImage.Controls.Add(label);
            panaelImage.Controls.Add(pic);
            panaelImage.Location = new Point(12, 12);
            panaelImage.Name = $"panel{Pos}";
            panaelImage.Size = new Size(477, 276);
            panaelImage.TabIndex = 0;

            label.Click += LabelDeleteClick;

            PanelImageDict.Add(panaelImage, img_bytes);
            Pos += 1;
            return panaelImage;
        }

        private PictureBox createPictureBoxe(Image img)
        {
            PictureBox pic = new PictureBox();
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Size = new Size(300, 300);
            pic.Name = $"pict{Pos}";
            pic.TabIndex = 0;
            pic.Image = img;
            ListImagesEnvoyer.Add(img);

            return pic;
        }

        private void boutonPost_Click(object sender, EventArgs e)
        {
            // manque de verification
            // Checker si le size est acceptable
            // Max 16 777 216 bits 

            //string title = Contenu1LBL.Text;
         


            byte[] img1 = null;
            byte[] img2 = null;
            byte[] img3 = null;
            if (PanelImageDict.Count >= 1)
            {
                img1 = PanelImageDict.ElementAt(0).Value;
            }
            if (PanelImageDict.Count >= 2)
            {
                img2 = PanelImageDict.ElementAt(1).Value;
            }
            if (PanelImageDict.Count >= 3)
            {
                img3 = PanelImageDict.ElementAt(2).Value;
            }
            //Handle.insertIntoData(title, content, img1, img2, img3);
            Main.LoadFrontPage();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (Pos > 2)
            {
                // Checker exede le nombre d'image permisse
                Console.WriteLine("Nb image exceed");
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.AddExtension = true;
            ofd.Multiselect = true;
            ofd.Filter = "All Files|*.png;*.jpeg;*.jpg;";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in ofd.FileNames)
                {
                    if (Pos > 2)
                    {
                        Console.WriteLine("Nb image exceed");
                    }
                    else
                    {
                        AbsoluteImagePath.Add(fileName);
                        UpdateLabelimage(fileName);

                    }
                }

            }
        }

        private void UpdateLabelimage(string filename)
        {
            Panel pan = CreatePanaelImage(filename);
            PanelPost.Controls.Add(pan);
        }
        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Main.LoadFrontPage();
        }

        private void LabelDeleteClick(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            Panel parent = clickedLabel.Parent as Panel;
            if (parent != null)
            {
                PanelPost.Controls.Remove(parent);
                parent.Dispose();
                PanelImageDict.Remove(parent);
                Pos -= 1;
            }
        }

        public bool Cleanup()
        {
            return true;
        }

        private void ScrollablePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            
            int scrolled = e.Delta;

            // Max en hauteur = 135 et min hauteur = -325
            if (ScrollablePanel.Location.Y + scrolled < 135 && ScrollablePanel.Location.Y + scrolled > -325)
                ScrollablePanel.Location = new Point(ScrollablePanel.Location.X, ScrollablePanel.Location.Y + scrolled);
        }
    }
}
