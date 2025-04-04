using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;
using deepFake;
using deepFake.Elements;


namespace deepFake
{
    public partial class PublierPost : Form
    {
        private List<InputTexte> inputTexteList = new List<InputTexte>(); // Vas garder en memoire le nombre de TexteList que le form contient
        private List<SmartPictureBoxe> smartPictureBoxes = new List<SmartPictureBoxe>(); // Garder en memoire les smartPictureBox contenue dans le form

        private Point FirstPoint = new Point(10, 100);
        private int DistanceEntre2Element = 20;
        
        // Attribut
        private Acceuil Main;
        private ComPostSQL Handle;

        // Element contenue
        private InputTexte InputeTitre;
        private AddElement AddsElements;
        private Button SubmitButton;

        // int pour le scrolling
        private int Y_Max = 135, Y_Min = 0;


        public PublierPost(Acceuil acceuil)
        {
            Main = acceuil;
            Handle = new ComPostSQL();
            InitializeComponent();
            InitializeElement();
            Beautefull();
        }

        private void Beautefull()
        {
            PanelContenue.BackColor = ColorTranslator.FromHtml("#E3DDE2");
            PanelPost.BackColor = Color.White;
        }

        private void InitializeElement()
        {

            InputeTitre = new InputTexte("Input title", new Size(800, 50), 50, false) 
            {
                Location = new Point(10, 10),
                Name = "texte1"
            };
            AddsElements = new AddElement()
            {
                Location = new Point(10, 200),
            };
            SubmitButton = new Button()
            {
                Location = new Point(AddsElements.Location.X, AddsElements.Bottom + 30),
                Text = "Submit",
                Size = new Size(100, 40),
                Font = new Font("Candara", 16F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };
            
            AddsElements.ajouterImageBtn.Click += AjouterImageBtn_Click;
            AddsElements.ajouterTexteBtn.Click += AjouterTexteBtn_Click;
            SubmitButton.Click += SubmitButton_Click;


            ScrollablePanel.Controls.Add(AddsElements);
            ScrollablePanel.Controls.Add(InputeTitre);
            ScrollablePanel.Controls.Add(SubmitButton);

        }

        private void SetNewY_S()
        {
            foreach (DraggablePanel draggableElement in inputTexteList) {
                draggableElement.Set_Y_S(AddsElements.Location.Y);
            }
            foreach (DraggablePanel draggableElement in smartPictureBoxes)
            {
                draggableElement.Set_Y_S(AddsElements.Location.Y);
            }
        }
        public void ElementRemoved(Control element)
        {
            if (element == null) return;
            int toMove = 0;   

            if(element is InputTexte input)
            {
                inputTexteList.Remove(input);
                DraggablePanel.ActiveDraggablePanels.Remove(input);
                input.Parent.Controls.Remove(input);
                toMove = 300;
            }

            if (element is SmartPictureBoxe smartPictureBoxe)
            {
                smartPictureBoxes.Remove(smartPictureBoxe);
                DraggablePanel.ActiveDraggablePanels.Remove(smartPictureBoxe);
                smartPictureBoxe.Parent.Controls.Remove(smartPictureBoxe);
                toMove = 400;
            }

            if (DraggablePanel.ActiveDraggablePanels.Count > 2)
            {
                ScrollablePanel.Location = new Point(ScrollablePanel.Location.X, ScrollablePanel.Location.Y + toMove);
                Y_Min += toMove;
            }
            if (DraggablePanel.ActiveDraggablePanels.Count == 2)
            {
                Y_Min += toMove;
            }

            DraggablePanel.PlaceWithList();
        }

        /// <summary>
        /// Placer les elements dans le panel selon l'orde dans la list
        /// Vas etre utiliser principalement quand l'usager veut enlever dequoi
        /// </summary>
        private void PlaceWithList()
        {
            Point first = new Point(FirstPoint.X, FirstPoint.Y);
            Control lastElement = null;
            
            for (int i = 0; i < DraggablePanel.ActiveDraggablePanels.Count; i++) {
                Control element = DraggablePanel.ActiveDraggablePanels[i];
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
                if (i == DraggablePanel.ActiveDraggablePanels.Count - 1) {
                    AddsElements.Location = new Point(element.Location.X, element.Bottom + 30);
                    SubmitButton.Location = new Point(AddsElements.Location.X, AddsElements.Bottom + 30);
                }
                lastElement = element;
            }
            if(DraggablePanel.ActiveDraggablePanels.Count == 0)
            {
                AddsElements.Location = new Point(10, 200);
                SubmitButton.Location = new Point(AddsElements.Location.X, AddsElements.Bottom + 30);
            }
        }


        private void ScrollablePanel_MouseWheel(object sender, MouseEventArgs e)
        {

            int scrolled = e.Delta;
            // Max en hauteur = 135 et min hauteur = -325
            if (ScrollablePanel.Location.Y + scrolled < Y_Max && ScrollablePanel.Location.Y + scrolled > Y_Min)
                ScrollablePanel.Location = new Point(ScrollablePanel.Location.X, ScrollablePanel.Location.Y + scrolled);
        }

        private void AjouterImageBtn_Click(object? sender, EventArgs e)
        {
            DraggablePanel.ActiveDraggablePanels = Algorithme.OrderListWithLocation(DraggablePanel.ActiveDraggablePanels);

            if (smartPictureBoxes.Count > 2) return;

            Point p = new Point(FirstPoint.X, FirstPoint.Y);
            if (DraggablePanel.ActiveDraggablePanels.Count > 0)
            {
                Control lastElement = DraggablePanel.ActiveDraggablePanels[DraggablePanel.ActiveDraggablePanels.Count - 1];
                p = new Point(lastElement.Location.X, lastElement.Bottom + DistanceEntre2Element);
            }
            SmartPictureBoxe smart = new SmartPictureBoxe($"Image {smartPictureBoxes.Count}", p, new Size(800, 400), [200, 1000], [InputeTitre.Bottom + 20, 1000]);

            DraggablePanel.ActiveDraggablePanels.Add(smart);
            ScrollablePanel.Controls.Add(smart);
            smartPictureBoxes.Add(smart);

            AddsElements.Location = new Point(smart.Location.X, smart.Bottom + 30);
            SubmitButton.Location = new Point(AddsElements.Location.X, AddsElements.Bottom + 30);

            if (DraggablePanel.ActiveDraggablePanels.Count != 1) Y_Min -= 400;
            SetNewY_S();

        }

        private void AjouterTexteBtn_Click(object? sender, EventArgs e)
        {

            if (inputTexteList.Count > 3) return;

            DraggablePanel.ActiveDraggablePanels = Algorithme.OrderListWithLocation(DraggablePanel.ActiveDraggablePanels);

            Point p = FirstPoint;
            if (DraggablePanel.ActiveDraggablePanels.Count > 0)
            {
                Control lastElement = DraggablePanel.ActiveDraggablePanels[DraggablePanel.ActiveDraggablePanels.Count - 1];
                p = new Point(lastElement.Location.X, lastElement.Bottom + DistanceEntre2Element);
            }
            InputTexte inputT = new InputTexte($"Input {inputTexteList.Count}", p, $"input{inputTexteList.Count}", new Size(800, 200), 1000, true, true, [200, 1000], [InputeTitre.Bottom + 20, 1000], true);

            DraggablePanel.ActiveDraggablePanels.Add(inputT);
            inputTexteList.Add(inputT);
            ScrollablePanel.Controls.Add(inputT);

            AddsElements.Location = new Point(inputT.Location.X, inputT.Bottom + 30);
            SubmitButton.Location = new Point(AddsElements.Location.X, AddsElements.Bottom + 30);
            if (DraggablePanel.ActiveDraggablePanels.Count != 1) Y_Min -= 300;
            SetNewY_S();

        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // manque de verification
            // Checker si le size est acceptable
            // Max 16 777 216 bits 

            //string title = Contenu1LBL.Text;
            List<string> inputBoxConent = GetStringContentOfPage();
            List<byte[]> pictureBoxContent = GetPictureBoxContent();




            //Handle.insertIntoData(title, content, images[0], images[1], images[2]);
            Main.LoadFrontPage();
        }

        private List<string> GetStringContentOfPage()
        {
            List<string> contents = new List<string>();
            foreach (InputTexte inp in inputTexteList)
            {
                contents.Add(inp.GetContentOfInput());
            }
            return contents;   
        }
        private List<byte[]> GetPictureBoxContent()
        {
            List<byte[]> images = new List<byte[]>();

            foreach (SmartPictureBoxe pic in smartPictureBoxes)
            {
                images.Add(pic.Current_Image_Data);
            }
            return images;
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Main.LoadFrontPage();
        }

        public bool Cleanup()
        {
            return true;
        }

        
    }
}
