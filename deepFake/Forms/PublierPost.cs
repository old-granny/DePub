using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using deepFake.SQL;
using deepFake.UIElements.Basic;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;



namespace deepFake
{
    public partial class PublierPost : Form
    {
        /*---  Constante  ---*/

        private Point PREMIER_POINT = new Point(10, 100);
        private Point PREMIER_POINT_SCROLLABLE = new Point(3, 15);
        private Point PREMIER_POINT_ELEMENT = new Point(10, 200);

        private const int DISTANCE_ENTRE_2_ELEMENTS = 20;
        private const int MAX_PICTURE = 2, MAX_INPUT = 3;

        /*---  Constante  ---*/


        /* List des element actif dans le form */
        
        private List<InputTexte> InputTexteList = new List<InputTexte>(); // Vas garder en memoire le nombre de TexteList que le form contient
        private List<SmartPictureBoxe> SmartPictureBoxes = new List<SmartPictureBoxe>(); // Garder en memoire les smartPictureBox contenue dans le form
        public List<DraggablePanel> ActivePanelsDraggables = new List<DraggablePanel>();
        
        /* List des element actif dans le form */


        /* Form comme attribut */

        private Acceuil Main;
        private ComPostSQL Handle;

        /* Form comme attribut */



        /* Elements constituant le form */
        
        private InputTexte InputeTitre;
        private AddElement AddsElements;
        private Button SubmitButton;
        private Button CancelButton;


        /* Elements constituant le form */


        /*--- Attribut ---*/
        private const int Y_Max_S = 135, Y_Min_s = 0;
        private int Y_Max = Y_Max_S, Y_Min = Y_Min_s;  // int pour le scrolling



        public PublierPost(Acceuil acceuil)
        {
            InitializeComponent(); // Fonction implement automatique


            Main = acceuil;
            Handle = new ComPostSQL();
            InitializeElement();
            
            Beautefull();
        }
        
        /* Methodes helpers pour le constructeur */
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
            CancelButton = new Button()
            {
                Location = new Point(SubmitButton.Location.X, SubmitButton.Bottom + 30),
                Text = "Cancel",
                Size = new Size(100, 40),
                Font = new Font("Candara", 16F, FontStyle.Regular, GraphicsUnit.Point, 0)

            };


            AddsElements.ajouterImageBtn.Click += AjouterImageBtn_Click;
            AddsElements.ajouterTexteBtn.Click += AjouterTexteBtn_Click;
            SubmitButton.Click += SubmitButton_Click;
            CancelButton.Click += CancelBTN_Click;

            ScrollablePanel.Controls.Add(CancelButton);
            ScrollablePanel.Controls.Add(AddsElements);
            ScrollablePanel.Controls.Add(InputeTitre);
            ScrollablePanel.Controls.Add(SubmitButton);

        }
        /* Methodes helpers pour le constructeur */



        /* Methodes de publier posts */
        public void ElementRemoved(Control element)
        {
            if (element == null) return;
            int toMove = 0;   

            if(element is InputTexte input)
            {
                InputTexteList.Remove(input);
                ActivePanelsDraggables.Remove(input);
                input.Parent.Controls.Remove(input);
                toMove = 300;
            }

            if (element is SmartPictureBoxe smartPictureBoxe)
            {
                SmartPictureBoxes.Remove(smartPictureBoxe);
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
            
            if (SmartPictureBoxes.Count > MAX_PICTURE-1) return; // si execed le nombre de picture

            Point p = new Point(PREMIER_POINT.X, PREMIER_POINT.Y);
            if (ActivePanelsDraggables.Count > 0)
            {
                Control lastElement = ActivePanelsDraggables[ActivePanelsDraggables.Count - 1];
                p = new Point(lastElement.Location.X, lastElement.Bottom + DISTANCE_ENTRE_2_ELEMENTS);
            }
            SmartPictureBoxe smart = new SmartPictureBoxe($"Image {SmartPictureBoxes.Count}", p, new Size(800, 400), [200, 1000], [InputeTitre.Bottom + 20, 1000]);

            ActivePanelsDraggables.Add(smart);
            ScrollablePanel.Controls.Add(smart);
            SmartPictureBoxes.Add(smart);

            SetLocationElementSubmit();

            if (ActivePanelsDraggables.Count != 1) Y_Min -= 400;
            SetNewY_S();

        }

        private void AjouterTexteBtn_Click(object? sender, EventArgs e)
        {

            if (InputTexteList.Count > MAX_INPUT-1) return;

            Algorithme.OrderListWithLocation(ref ActivePanelsDraggables);

            Point p = new Point(PREMIER_POINT.X, PREMIER_POINT.Y);
            if (ActivePanelsDraggables.Count > 0)
            {
                Control lastElement = ActivePanelsDraggables[ActivePanelsDraggables.Count - 1];
                p = new Point(lastElement.Location.X, lastElement.Bottom + DISTANCE_ENTRE_2_ELEMENTS);
            }
            InputTexte inputT = new InputTexte($"Input {InputTexteList.Count}", p, $"input{InputTexteList.Count}", new Size(800, 200), 1000, true, true, [200, 1000], [InputeTitre.Bottom + 20, 1000], true);

            ActivePanelsDraggables.Add(inputT);
            InputTexteList.Add(inputT);
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

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Main.LoadFrontPage();
        }
        /* Methodes de publier posts */


        /* Methode helpers pour obtenir les infos des contenues du publier post */
        private List<string> GetStringContentOfPage()
        {
            List<string> contents = new List<string>();
            foreach (InputTexte inp in InputTexteList)
            {
                contents.Add(inp.GetContentOfInput());
            }
            return contents;   
        }
        private List<byte[]> GetPictureBoxContent()
        {
            List<byte[]> images = new List<byte[]>();
            foreach (SmartPictureBoxe pic in SmartPictureBoxes)
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
        /* Methode helpers pour obtenir les infos des contenues du publier post */



        /* Methode de deplacement */
        private void SetNewY_S()
        {
            foreach (DraggablePanel draggableElement in ActivePanelsDraggables)
            {
                draggableElement.Set_Y_S(AddsElements.Location.Y);
            }
        }

        private void SetLocationElementSubmit()
        {
            int X = 0;
            int Y = 0;
            
            if (ActivePanelsDraggables.Count == 0) 
            {
                X = PREMIER_POINT_ELEMENT.X;
                Y = PREMIER_POINT_ELEMENT.Y;
            }
            else
            {
                X = ActivePanelsDraggables[ActivePanelsDraggables.Count - 1].Location.X;
                Y = ActivePanelsDraggables[ActivePanelsDraggables.Count - 1].Bottom;
            }

            AddsElements.Location = new Point(X, Y + 30);
            SubmitButton.Location = new Point(X, AddsElements.Bottom + 30);
            CancelButton.Location = new Point(X, SubmitButton.Bottom + 30);
        }
        /* Methode de deplacement */

        public bool Cleanup()
        {
            var itemsPicutre = new List<SmartPictureBoxe>();
            foreach (SmartPictureBoxe picture in SmartPictureBoxes)
            {
                itemsPicutre.Add(picture);
            }
            foreach (var item in itemsPicutre)
            {
                ActivePanelsDraggables.Remove(item);
                ScrollablePanel.Controls.Remove(item);
            }


            var itemsInput = new List<InputTexte>();
            foreach (InputTexte inp in InputTexteList)
            {
                itemsInput.Add(inp);
            }
            foreach (var item in itemsInput)
            {
                ActivePanelsDraggables.Remove(item);
                ScrollablePanel.Controls.Remove(item);
            }


            SmartPictureBoxes.Clear();
            InputTexteList.Clear();

            var itemsToRemove = new List<DraggablePanel>();
            foreach (DraggablePanel dragganle in ActivePanelsDraggables)
            {
                itemsToRemove.Add(dragganle);
            }
            foreach (var item in itemsToRemove)
            {
                ActivePanelsDraggables.Remove(item);
            }

            Y_Max = Y_Max_S;
            Y_Min = Y_Min_s;

            SetNewY_S();
            ScrollablePanel.Location = new Point(PREMIER_POINT_SCROLLABLE.X, PREMIER_POINT_SCROLLABLE.Y);
            SetLocationElementSubmit();
            InputeTitre.ResetContent();

            return true;
        }


    }
}
