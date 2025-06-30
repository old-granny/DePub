using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace deepFake.UIElements.Basic
{
    public class LoginInputs : Panel
    {
        private Label label;
        private TextBox textBox;

        public string LabelText
        {
            get => label.Text;
            set => label.Text = value;
        }

        public string PlaceholderText
        {
            get => textBox.PlaceholderText;
            set => textBox.PlaceholderText = value;
        }

        public string TextValue
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public LoginInputs(string labelText)
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
            this.Size = new Size(300, 60); // Adjustable

            label = new Label
            {
                Text = labelText,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(0, 0)
            };

            textBox = new TextBox
            {
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                PlaceholderText = labelText,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                ForeColor = Color.Black,
                Location = new Point(10, 25),
                Width = this.Width - 20,
            };

            this.Controls.Add(label);
            this.Controls.Add(textBox);

            // Padding and border drawing
            this.Paint += LoginInputs_Paint;
        }

        private void LoginInputs_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int cornerRadius = 12;
            int borderWidth = 1;
            Rectangle rect = new Rectangle(0, 22, this.Width - 1, 34);

            using (Pen borderPen = new Pen(Color.LightGray, borderWidth))
            using (SolidBrush bgBrush = new SolidBrush(Color.White))
            {
                using (GraphicsPath path = RoundedRect(rect, cornerRadius))
                {
                    g.FillPath(bgBrush, path);
                    g.DrawPath(borderPen, path);
                }
            }
        }

        private System.Drawing.Drawing2D.GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(bounds.Left, bounds.Top, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Top, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            return path;
        }
    }
}
