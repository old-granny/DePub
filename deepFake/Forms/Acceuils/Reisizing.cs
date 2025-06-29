using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace deepFake
{
    public partial class Acceuil : Form
    {
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;
        private const int HTCLIENT = 1;
        private const int WM_NCHITTEST = 0x84;

        private int resizeBorderThickness = 8;


        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;

            if (m.Msg == WM_NCHITTEST)
            {
                var form = FindForm();

                if (form.WindowState == FormWindowState.Maximized) return;

                // Get screen coordinates from message
                int x = (short)((m.LParam.ToInt32()) & 0xFFFF);
                int y = (short)((m.LParam.ToInt32() >> 16) & 0xFFFF);
                Point screenPoint = new Point(x, y);
                Point clientPoint = this.PointToClient(screenPoint);

                int grip = 8; // Thickness of the resize area

                if (clientPoint.X <= grip)
                {
                    if (clientPoint.Y <= grip)
                        m.Result = (IntPtr)13; // HTTOPLEFT
                    else if (clientPoint.Y >= this.ClientSize.Height - grip)
                        m.Result = (IntPtr)16; // HTBOTTOMLEFT
                    else
                        m.Result = (IntPtr)10; // HTLEFT
                    return;
                }
                else if (clientPoint.X >= this.ClientSize.Width - grip)
                {
                    if (clientPoint.Y <= grip)
                        m.Result = (IntPtr)14; // HTTOPRIGHT
                    else if (clientPoint.Y >= this.ClientSize.Height - grip)
                        m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    else
                        m.Result = (IntPtr)11; // HTRIGHT
                    return;
                }
                else if (clientPoint.Y <= grip)
                {
                    m.Result = (IntPtr)12; // HTTOP
                    return;
                }
                else if (clientPoint.Y >= this.ClientSize.Height - grip)
                {
                    m.Result = (IntPtr)15; // HTBOTTOM
                    return;
                }
            }
            base.WndProc(ref m);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen borderPen = new Pen(ColorTranslator.FromHtml("#0A3241"), 3))
            {
                Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                e.Graphics.DrawRectangle(borderPen, rect);
            }
        }

    }
}
