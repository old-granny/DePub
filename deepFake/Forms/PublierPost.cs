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
using Mysqlx.Crud;


namespace deepFake
{
    public partial class PublierPost : Form
    {
        private List<InputTexte> inputTexteList = new List<InputTexte>(); // Vas garder en memoire le nombre de TexteList que le form contient
        private List<SmartPictureBoxe> smartPictureBoxes = new List<SmartPictureBoxe>(); // Garder en memoire les smartPictureBox contenue dans le form

        public List<DraggablePanel> ActivePanelsDraggables = new List<DraggablePanel>();

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

        private const int MAX_PICTURE = 2, MAX_INPUT = 3;


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

        
        public void ElementRemoved(Control element)
        {
            if (element == null) return;
            int toMove = 0;   

            if(element is InputTexte input)
            {
                inputTexteList.Remove(input);
                ActivePanelsDraggables.Remove(input);
                input.Parent.Controls.Remove(input);
                toMove = 300;
            }

            if (element is SmartPictureBoxe smartPictureBoxe)
            {
                smartPictureBoxes.Remove(smartPictureBoxe);
                ActivePanelsDraggables.Remove(smartPictureBoxe);
                smartPictureBoxe.Parent.Controls.Remove(smartPictureBoxe);
                toMove = 400;
            }

            if (ActivePanelsDraggables.Count > 2)
            {
                ScrollablePanel.Location = new Point(ScrollablePanel.Location.X, ScrollablePanel.Location.Y + toMove);
                Y_Min += toMove;
            }
            if (ActivePanelsDraggables.Count == 2)
            {
                Y_Min += toMove;
            }

            DraggablePanel.PlaceWithList(ActivePanelsDraggables);
            SetLocationElementSubmit();

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

            // Placer les element actif en ordre de vue
            Algorithme.OrderListWithLocation(ref ActivePanelsDraggables);
            
            if (smartPictureBoxes.Count > MAX_PICTURE-1) return; // si execed le nombre de picture

            Point p = new Point(FirstPoint.X, FirstPoint.Y);
            if (ActivePanelsDraggables.Count > 0)
            {
                Control lastElement = ActivePanelsDraggables[ActivePanelsDraggables.Count - 1];
                p = new Point(lastElement.Location.X, lastElement.Bottom + DistanceEntre2Element);
            }
            SmartPictureBoxe smart = new SmartPictureBoxe($"Image {smartPictureBoxes.Count}", p, new Size(800, 400), [200, 1000], [InputeTitre.Bottom + 20, 1000]);

            ActivePanelsDraggables.Add(smart);
            ScrollablePanel.Controls.Add(smart);
            smartPictureBoxes.Add(smart);

            SetLocationElementSubmit();

            if (ActivePanelsDraggables.Count != 1) Y_Min -= 400;
            SetNewY_S();

        }

        private void AjouterTexteBtn_Click(object? sender, EventArgs e)
        {

            if (inputTexteList.Count > MAX_INPUT-1) return;

            Algorithme.OrderListWithLocation(ref ActivePanelsDraggables);

            Point p = FirstPoint;
            if (ActivePanelsDraggables.Count > 0)
            {
                Control lastElement = ActivePanelsDraggables[ActivePanelsDraggables.Count - 1];
                p = new Point(lastElement.Location.X, lastElement.Bottom + DistanceEntre2Element);
            }
            InputTexte inputT = new InputTexte($"Input {inputTexteList.Count}", p, $"input{inputTexteList.Count}", new Size(800, 200), 1000, true, true, [200, 1000], [InputeTitre.Bottom + 20, 1000], true);

            ActivePanelsDraggables.Add(inputT);
            inputTexteList.Add(inputT);
            ScrollablePanel.Controls.Add(inputT);

            SetLocationElementSubmit();

            if (ActivePanelsDraggables.Count != 1) Y_Min -= 300;
            SetNewY_S();

        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // manque de verification
            // Checker si le size est acceptable
            // Max 16 777 216 bits 

            //string title = Contenu1LBL.Text;
            List<string> inputBoxContent = GetStringContentOfPage();
            List<byte[]> pictureBoxContent = GetPictureBoxContent();

            List<string> positionElement = GetOrderOfElements();
            Algorithme.OrderListWithLocation(ref ActivePanelsDraggables);
            StringBuilder order = new StringBuilder();
            foreach (DraggablePanel pan in ActivePanelsDraggables)
            {
                order.Append(pan.Name);
                order.Append(";");
            }

            if(Handle.insertIntoData(order.ToString(), InputeTitre.GetContentOfInput(), inputBoxContent, pictureBoxContent))
                Main.LoadFrontPage();
            else
            {
                Console.WriteLine("ERROR");
            }
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
        private List<string> GetOrderOfElements()
        {
            List<string> order = new List<string>();

            foreach (Control con in ActivePanelsDraggables)
            {
                order.Add(con.Name);
            }
            return order;
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Main.LoadFrontPage();
        }

        public bool Cleanup()
        {
            return true;
        }

        private void SetNewY_S()
        {
            foreach (DraggablePanel draggableElement in ActivePanelsDraggables)
            {
                draggableElement.Set_Y_S(AddsElements.Location.Y);
            }
        }

        private void SetLocationElementSubmit()
        {
            if (ActivePanelsDraggables.Count == 0) return;
            int X = ActivePanelsDraggables[ActivePanelsDraggables.Count-1].Location.X;
            int Y = ActivePanelsDraggables[ActivePanelsDraggables.Count - 1].Bottom;


            AddsElements.Location = new Point(X, Y + 30);
            SubmitButton.Location = new Point(X, Y + 120);
        }

    }
}
