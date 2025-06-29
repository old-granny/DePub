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
            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);

                var screenPoint = new Point(m.LParam.ToInt32());
                var clientPoint = this.PointToClient(screenPoint);
                int grip = 8;

                // Check edges
                if (clientPoint.X <= grip && clientPoint.Y <= grip)
                {
                    m.Result = (IntPtr)HTTOPLEFT;
                    return;
                }
                if (clientPoint.X >= this.ClientSize.Width - grip && clientPoint.Y <= grip)
                {
                    m.Result = (IntPtr)HTTOPRIGHT;
                    return;
                }
                if (clientPoint.X <= grip && clientPoint.Y >= this.ClientSize.Height - grip)
                {
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                    return;
                }
                if (clientPoint.X >= this.ClientSize.Width - grip && clientPoint.Y >= this.ClientSize.Height - grip)
                {
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                    return;
                }
                if (clientPoint.Y <= grip)
                {
                    m.Result = (IntPtr)HTTOP;
                    return;
                }
                if (clientPoint.Y >= this.ClientSize.Height - grip)
                {
                    m.Result = (IntPtr)HTBOTTOM;
                    return;
                }
                if (clientPoint.X <= grip)
                {
                    m.Result = (IntPtr)HTLEFT;
                    return;
                }
                if (clientPoint.X >= this.ClientSize.Width - grip)
                {
                    m.Result = (IntPtr)HTRIGHT;
                    return;
                }

                return;
            }

            base.WndProc(ref m);
        }


        public void ChangeLeftSize()
        {
            this.Width = this.Width - 5;
            this.Left = this.Left + 5;
        }

        public void ChangeRightSize()
        {
            this.Width = this.Width - 5;
        }

        public void ChangeTopSize()
        {
            this.Height = this.Height - 5;
            this.Top = this.Top + 5;
        }
    }

}
