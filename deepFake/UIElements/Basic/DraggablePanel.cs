using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deepFake.UIElements.Basic
{
    public class DraggablePanel : Panel
    {
        private bool isDragging = false;
        private Point dragStartPoint;
        private Point dragElementStartPoint;
        private int borderThickness = 5; // Border area for dragging
        private int Max_X, Min_X, Max_Y, Min_Y;

        public bool Draggable = true;

        //public List<DraggablePanel> ActiveDraggablePanels = new List<DraggablePanel>();

        public DraggablePanel(int[] x_s, int[] y_s)
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
            BorderStyle = BorderStyle.FixedSingle;

            // Events for dragging
            MouseDown += Panel_MouseDown;
            MouseMove += Panel_MouseMove;
            MouseUp += Panel_MouseUp;
        }

        public void Remove_Draggable_Panel(List<DraggablePanel> panelsDraggable)
        {
            panelsDraggable.Remove(this);
        }
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Draggable) return;

            if (IsOnBorder(e.Location))
            {
                isDragging = true;
                dragStartPoint = e.Location;
                dragElementStartPoint = Location;
                Cursor = Cursors.SizeAll; // Change cursor to indicate dragging
            }
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Draggable) return;
            if (isDragging)
            {
                // Calculate new panel position
                if (Left + e.X - dragStartPoint.X > Min_X && Right + e.X - dragStartPoint.X + 5 < Max_X)
                    Left += e.X - dragStartPoint.X;
                if (Top + e.Y - dragStartPoint.Y > Min_Y && Bottom + e.Y - dragStartPoint.Y + 5 < Max_Y)
                    Top += e.Y - dragStartPoint.Y;
            }
            else
            {
                // Change cursor when hovering over border
                Cursor = IsOnBorder(e.Location) ? Cursors.SizeAll : Cursors.Default;
            }
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {

            if (FindForm().GetType() == typeof(PublierPost))
            {
                isDragging = false;
                Cursor = Cursors.Default;
                DraggablePanel pan = (DraggablePanel)Algorithme.OverWith(this, ((PublierPost)FindForm()).ActivePanelsDraggables, 20);

                if (pan != null)
                {
                    if (pan.Draggable)
                    {
                        if (Algorithme.isUnderControl(this, pan))
                        {
                            Location = pan.Location;
                            pan.Location = new Point(dragElementStartPoint.X, dragElementStartPoint.Y);
                        }
                        else
                        {
                            Location = pan.Location;
                            pan.Location = new Point(dragElementStartPoint.X, dragElementStartPoint.Y);
                        }
                        PlaceWithList(((PublierPost)FindForm()).ActivePanelsDraggables);
                    }
                }
                else
                {
                    Location = dragElementStartPoint;
                }

            }

            else
            {
                Location = dragElementStartPoint;
            }


        }

        private bool IsOnBorder(Point mousePos)
        {
            return mousePos.X <= borderThickness || mousePos.X >= Width - borderThickness ||
                    mousePos.Y <= borderThickness || mousePos.Y >= Height - borderThickness;
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

        static public void PlaceWithList(List<DraggablePanel> panelsDraggable)
        {
            Point FirstPoint = new Point(10, 100);
            Control lastElement = panelsDraggable[0];
            Algorithme.OrderListWithLocation(ref panelsDraggable);
            foreach (DraggablePanel panel in panelsDraggable)
            {
                if (panel == panelsDraggable[0])
                {
                    lastElement.Location = FirstPoint;
                    lastElement = panel;
                }
                else
                {
                    panel.Location = new Point(lastElement.Location.X, lastElement.Bottom + 20);
                    lastElement = panel;
                }
            }
        }
    }
}
