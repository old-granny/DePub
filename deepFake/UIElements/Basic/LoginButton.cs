using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace deepFake.UIElements.Basic
{
    public class LoginButton : Panel
    {
        private Color _borderColor = Color.Black;
        private int _cornerRadius = 12;

        public LoginButton(Color foreColor, Color backColor, string Content)
        {
            this.ForeColor = foreColor;
            this.BackColor = backColor;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Height = 40;
            this.Width = 200;
            this.Text = Content;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = this.ClientRectangle;
            rect.Inflate(-1, -1);

            using (GraphicsPath path = RoundedRect(rect, _cornerRadius))
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            using (Pen pen = new Pen(_borderColor, 1))
            using (StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                pevent.Graphics.FillPath(brush, path);
                pevent.Graphics.DrawPath(pen, path);
                pevent.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), rect, sf);
            }
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            var path = new GraphicsPath();

            path.StartFigure();
            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
