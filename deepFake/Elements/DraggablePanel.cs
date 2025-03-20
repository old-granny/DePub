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
        private int borderThickness = 5; // Border area for dragging
        int Max_X, Min_X, Max_Y, Min_Y;

        public bool Draggable = true;

        public DraggablePanel(int[] x_s, int [] y_s)
        {
            Min_X = x_s[0];
            Max_X = x_s[1];

            Min_Y = y_s[0];
            Max_Y = y_s[1];
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

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Draggable) return;

            if (IsOnBorder(e.Location))
            {
                isDragging = true;
                dragStartPoint = e.Location;
                this.Cursor = Cursors.SizeAll; // Change cursor to indicate dragging
            }
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if(!Draggable) return;
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
        }

        private bool IsOnBorder(Point mousePos)
        {
            return (mousePos.X <= borderThickness || mousePos.X >= this.Width - borderThickness ||
                    mousePos.Y <= borderThickness || mousePos.Y >= this.Height - borderThickness);
        }
    }
}
