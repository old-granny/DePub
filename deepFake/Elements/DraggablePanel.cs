using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deepFake.Elements
{
    public class DraggablePanel : Panel
    {
        private bool isDragging = false;
        private Point dragStartPoint;
        private Point dragElementStartPoint;
        private int borderThickness = 5; // Border area for dragging
        private int Max_X, Min_X, Max_Y, Min_Y;

        public bool Draggable = true;

        public static List<DraggablePanel> ActiveDraggablePanels = new List<DraggablePanel>();

        public DraggablePanel(int[] x_s, int [] y_s)
        {
            Min_X = x_s[0];
            Max_X = x_s[1];
            Min_Y = y_s[0];
            Max_Y = y_s[1];
        }

        /// <summary>
        /// Quand on est oubliger de rendre le truc draggable car inputTexte est draggable mais on veut pas qui soit draggable
        /// Un peu contre intuitif mais fonction HAHAHAHAHA!!!
        /// </summary>
        public DraggablePanel() 
        {
            Draggable = false;
        }

        /// <summary>
        /// Peut rendre un panel Dragable 
        /// </summary>
        public void Set_Draggable()
        {
            this.BorderStyle = BorderStyle.FixedSingle;

            // Events for dragging
            this.MouseDown += Panel_MouseDown;
            this.MouseMove += Panel_MouseMove;
            this.MouseUp += Panel_MouseUp;
        }

        public void Remove_Draggable_Panel()
        {
            ActiveDraggablePanels.Remove(this);
        }
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Draggable) return;

            if (IsOnBorder(e.Location))
            {
                isDragging = true;
                dragStartPoint = e.Location;
                dragElementStartPoint = this.Location;
                this.Cursor = Cursors.SizeAll; // Change cursor to indicate dragging
            }
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if(!Draggable) return;
            if (ActiveDraggablePanels.Count <= 1) return; 
           
            if (isDragging)
            {
                // Calculate new panel position
                if(this.Left + e.X - dragStartPoint.X > Min_X && this.Right + e.X - dragStartPoint.X + 5 < Max_X) 
                    this.Left += e.X - dragStartPoint.X;
                if (this.Top + e.Y - dragStartPoint.Y > Min_Y && this.Bottom + e.Y - dragStartPoint.Y + 5 < Max_Y)
                    this.Top += e.Y - dragStartPoint.Y;
            }
            else
            {
                // Change cursor when hovering over border
                this.Cursor = IsOnBorder(e.Location) ? Cursors.SizeAll : Cursors.Default;
            }
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            this.Cursor = Cursors.Default;
            DraggablePanel pan = (DraggablePanel)Algorithme.OverWith(this, ActiveDraggablePanels, 20);
            
            if (pan != null)
            {
                if (pan.Draggable)
                {
                    if (Algorithme.isUnderControl(this, pan))
                    {
                        this.Location = pan.Location;
                        pan.Location = new Point(dragElementStartPoint.X, dragElementStartPoint.Y);   
                    }
                    else
                    {
                        this.Location = pan.Location;
                        pan.Location = new Point(dragElementStartPoint.X, dragElementStartPoint.Y);
                    }
                    PlaceWithList();
                }
            }
            else
            {
                this.Location = dragElementStartPoint;
            }
            
        }

        private bool IsOnBorder(Point mousePos)
        {
            return (mousePos.X <= borderThickness || mousePos.X >= this.Width - borderThickness ||
                    mousePos.Y <= borderThickness || mousePos.Y >= this.Height - borderThickness);
        }


        public void Increase_Y_S(int nb)
        {
            Max_Y += nb; 
        }

        public void Set_Y_S(int[] y_s)
        {
            Max_Y = y_s[1]; Min_Y = y_s[0];
        }
        public void Set_Y_S(int y_max)
        {
            Max_Y = y_max;
        }
        public void Set_X_S(int[] x_s)
        {
            Min_X = x_s[0]; Max_X = x_s[1];
        }

        private void PlaceWithList()
        {
            Point FirstPoint = new Point(10, 100);
            Control lastElement = ActiveDraggablePanels[0];
            ActiveDraggablePanels = Algorithme.OrderListWithLocation(ActiveDraggablePanels);
            Console.WriteLine("Called");
            foreach(DraggablePanel panel in ActiveDraggablePanels)
            {
                if(panel == ActiveDraggablePanels[0])
                {
                    lastElement.Location = FirstPoint;
                    lastElement = panel;
                }
                else
                {
                    panel.Location = new Point(lastElement.Location.X, lastElement.Bottom + 20);
                    lastElement = panel;
                }
                Console.WriteLine(panel.Name);
            }
            Console.WriteLine("end");

        }
    }
}
