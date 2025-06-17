using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;

            if (m.Msg == WM_NCHITTEST)
            {
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

                int grip = 5;

                // Top edge
                if (clientPoint.Y <= grip)
                {
                    m.Result = (IntPtr)HTTOP;
                    return;
                }

                // Left edge
                if (clientPoint.X <= grip)
                {
                    m.Result = (IntPtr)HTLEFT;
                    return;
                }

                // Right edge
                if (clientPoint.X >= this.ClientSize.Width - grip)
                {
                    m.Result = (IntPtr)HTRIGHT;
                    return;
                }

                m.Result = (IntPtr)HTCLIENT; // Default
                return;
            }

            base.WndProc(ref m);
        }
    }
}
