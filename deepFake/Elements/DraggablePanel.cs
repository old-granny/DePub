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

        public DraggablePanel()
        {
            
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
            if (IsOnBorder(e.Location))
            {
                isDragging = true;
                dragStartPoint = e.Location;
                this.Cursor = Cursors.SizeAll; // Change cursor to indicate dragging
            }
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calculate new panel position
                if(this.Left + e.X - dragStartPoint.X > 0 && this.Right + e.X - dragStartPoint.X + 5 < Parent.Size.Width) 
                    this.Left += e.X - dragStartPoint.X;
                else if (!(this.Top + e.Y - dragStartPoint.Y > 0 && this.Bottom + e.Y - dragStartPoint.Y + 5 < Parent.Size.Height))
                {
                    this.Cursor = Cursors.Default;
                    isDragging = false;
                }
                if (this.Top + e.Y - dragStartPoint.Y > 0 && this.Bottom + e.Y - dragStartPoint.Y + 5 < Parent.Size.Height)
                    this.Top += e.Y - dragStartPoint.Y;
                else if(!(this.Left + e.X - dragStartPoint.X > 0 && this.Right + e.X - dragStartPoint.X + 5 < Parent.Size.Width))
                {
                    this.Cursor = Cursors.Default;
                    isDragging = false;
                }


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
