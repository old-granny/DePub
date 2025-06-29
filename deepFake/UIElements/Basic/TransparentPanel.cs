using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deepFake.UIElements.Basic
{
    public class TransparentPanel : Panel
    {
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            Console.WriteLine("easdas");
            if (m.Msg == WM_NCHITTEST)
            {
                // Convert mouse position to screen coordinates
                Point screenPoint = new Point((int)m.LParam);
                // Convert to parent (form) client area
                Point clientPoint = this.Parent.PointToClient(screenPoint);

                // Recreate the hit test message for the form
                Message forwarded = Message.Create(this.Parent.Handle, WM_NCHITTEST, m.WParam, (IntPtr)((clientPoint.Y << 16) | (clientPoint.X & 0xFFFF)));

                // Send to parent form
                DefWndProc(ref forwarded);

                m.Result = forwarded.Result;
                return;
            }

            base.WndProc(ref m);
        }
    }
}
