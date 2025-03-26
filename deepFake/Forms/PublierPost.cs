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
using System.Xml.Linq;
using deepFake;
using deepFake.Elements;
using Org.BouncyCastle.Crypto.Parameters;

namespace deepFake
{
    public partial class PublierPost : Form
    {
        private List<InputTexte> inputTexteList = new List<InputTexte>();
        private List<SmartPictureBoxe> smartPictureBoxes = new List<SmartPictureBoxe>();

        private List<String> AbsoluteImagePath = new List<String>();
        private List<String> ListImageDejaFlow = new List<String>();

        private Dictionary<Panel, byte[]> PanelImageDict = new Dictionary<Panel, byte[]>();
        private List<Image> ListImagesEnvoyer = new List<Image>();
        private List<Panel> ListPanelsActive = new List<Panel>();

        private Stack<Control> stackElement = new Stack<Control>();
        private List<Control> listDesElementActif = new List<Control>();

        private int Pos = 0;
        private Point FirstPoint = new Point(10, 100);
        private int DistanceEntre2Element = 20;
        
        // Attribut
        private Acceuil Main;
        private ComPostSQL Handle;

        // Element contenue
        private InputTexte InputeTitre;
        private AddElement Element1;

        // int pour le scrolling
        private int Y_Max = 135, Y_Min = 0;

        // List des panel actif
        private List<Control> ElementsActif = new List<Control>();
        private Dictionary<Point, bool> dict_position_disponible = new Dictionary<Point, bool>(); // si true alors disponible

        public PublierPost(Acceuil acceuil)
        {
            Main = acceuil;
            Handle = new ComPostSQL();
            InstancierLesPoint();
            InitializeComponent();
            InitializeElement();
            Beautefull();
        }

        private void InstancierLesPoint()
        {
            dict_position_disponible.Add(new Point(10, 100), true);
            dict_position_disponible.Add(new Point(10, 400), true);
            dict_position_disponible.Add(new Point(10, 700), true);
            dict_position_disponible.Add(new Point(10, 1000), true);
            dict_position_disponible.Add(new Point(10, 1300), true);
            dict_position_disponible.Add(new Point(10, 1600), true);
        }


        private void Beautefull()
        {
            PanelContenue.BackColor = ColorTranslator.FromHtml("#E3DDE2");
            PanelPost.BackColor = Color.White;
        }

        private void InitializeElement()
        {
            Point pos = new Point(10, 10);
            Size size = new Size(800, 50);

            InputeTitre = new InputTexte("Input title", size, 50, false);
            InputeTitre.Location = pos;
            InputeTitre.Name = "texte1";

            ScrollablePanel.Controls.Add(InputeTitre);

            Element1 = new AddElement();
            Element1.Location = new Point(10, 200);
            ScrollablePanel.Controls.Add(Element1);

            Element1.ajouterImageBtn.Click += AjouterImageBtn_Click;
            Element1.ajouterTexteBtn.Click += AjouterTexteBtn_Click;

        }

        private void AjouterTexteBtn_Click(object? sender, EventArgs e)
        {
            listDesElementActif = Algorithme.OrderListWithLocation(listDesElementActif);

            if (inputTexteList.Count > 3) return;

            Point p = new Point(FirstPoint.X, FirstPoint.Y);
            if (listDesElementActif.Count > 0)
            {
                Control lastElement = listDesElementActif[listDesElementActif.Count - 1];
                p = new Point(lastElement.Location.X, lastElement.Bottom + DistanceEntre2Element);
            }
            InputTexte inputT = new InputTexte($"input{inputTexteList.Count}", new Size(800, 200), 1000, true, true, [200, 1000], [InputeTitre.Bottom + 20, 1000], true);
            inputT.Location = p;
            inputTexteList.Add(inputT);
            listDesElementActif.Add(inputT);
            ScrollablePanel.Controls.Add(inputT);
            Element1.Location = new Point(inputT.Location.X, inputT.Bottom+30);
            if(listDesElementActif.Count != 1) Y_Min -= 200;
            SetNewY_S();
            
        }
        private void AjouterImageBtn_Click(object? sender, EventArgs e)
        {
            listDesElementActif = Algorithme.OrderListWithLocation(listDesElementActif);

            if (smartPictureBoxes.Count > 3) return;
            
            Point p = new Point(FirstPoint.X, FirstPoint.Y);
            if (listDesElementActif.Count > 0)
            {
                Control lastElement = listDesElementActif[listDesElementActif.Count - 1];
                p = new Point(lastElement.Location.X, lastElement.Bottom + DistanceEntre2Element);
            }
            SmartPictureBoxe smart = new SmartPictureBoxe(p, new Size(800, 400), [200, 1000], [InputeTitre.Bottom + 20, 1000]);
            listDesElementActif.Add(smart);
            ScrollablePanel.Controls.Add(smart);
            smartPictureBoxes.Add(smart);
            
            Element1.Location = new Point(smart.Location.X, smart.Bottom + 30);
            if(listDesElementActif.Count != 1) Y_Min-=400;
            SetNewY_S();
            
        }

        private void SetNewY_S()
        {
            foreach (DraggablePanel draggableElement in inputTexteList) {
                draggableElement.Set_Y_S(Element1.Location.Y);
            }
            foreach (DraggablePanel draggableElement in smartPictureBoxes)
            {
                draggableElement.Set_Y_S(Element1.Location.Y);
            }
        }

        private void ScrollablePanel_MouseWheel(object sender, MouseEventArgs e)
        {

            int scrolled = e.Delta;
            Console.WriteLine(ScrollablePanel.Location.Y);
            // Max en hauteur = 135 et min hauteur = -325
            if (ScrollablePanel.Location.Y + scrolled < Y_Max && ScrollablePanel.Location.Y + scrolled > Y_Min)
                ScrollablePanel.Location = new Point(ScrollablePanel.Location.X, ScrollablePanel.Location.Y + scrolled);
        }

        public void ElementRemoved(Control element)
        {
            if (element == null) return;
            if(element.GetType() == typeof(InputTexte))
            {
                InputTexte inpute = element as InputTexte;
                if (inpute != null) { 
                    inputTexteList.Remove(inpute);
                    listDesElementActif.Remove(inpute);
                    inpute.Parent.Controls.Remove(element);
                }
            }
            if (element.GetType() == typeof(SmartPictureBoxe))
            {
                SmartPictureBoxe smartPictureBoxe = element as SmartPictureBoxe;
                if (smartPictureBoxe != null) {
                    if (listDesElementActif.Count > 2)
                    {
                        ScrollablePanel.Location = new Point(ScrollablePanel.Location.X, ScrollablePanel.Location.Y + 400);
                        Y_Min += 400;
                    }
                    if(listDesElementActif.Count == 2)
                    {
                        Y_Min += 400;
                    }
                    smartPictureBoxes.Remove(smartPictureBoxe);
                    listDesElementActif.Remove(smartPictureBoxe);
                    smartPictureBoxe.Parent.Controls.Remove(smartPictureBoxe);
                }

            }
            PlaceWithList();
        }

        /// <summary>
        /// Placer les elements dans le panel selon l'orde dans la list
        /// Vas etre utiliser principalement quand l'usager veut enlever dequoi
        /// </summary>
        private void PlaceWithList()
        {
            Point first = new Point(FirstPoint.X, FirstPoint.Y);
            Control lastElement = null;
            for (int i = 0; i < listDesElementActif.Count; i++) {
                Control element = listDesElementActif[i];
                if (i == 0 && element.Location != first) {
                    element.Location = first;
                }
                if (lastElement != null) 
                {
                    if (Algorithme.DistanceBetween2Point(lastElement.Location, element.Location) > DistanceEntre2Element+2) // le +2 pour la correction du float
                    { 
                           element.Location = new Point(lastElement.Location.X, lastElement.Bottom + DistanceEntre2Element);
                    }
                }
                if (i == listDesElementActif.Count - 1) {
                    Element1.Location = new Point(element.Location.X, element.Bottom + 30);
                }
                lastElement = element;
            }
            if(listDesElementActif.Count == 0)
            {
                Element1.Location = new Point(10, 200);
            }
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

        
    }
}
