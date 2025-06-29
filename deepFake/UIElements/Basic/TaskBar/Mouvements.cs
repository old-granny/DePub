using deepFake.ModelConception.Observateur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace deepFake.UIElements.Basic.TaskBar
{
    public partial class TaskBar : Panel, AbonneUser
    {

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern nint SendMessage(nint hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        private const int WM_NCHITTEST = 0x84;
        private const int HTTOP = 12;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTCAPTION1 = 2;

        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;


        private void Mouvements()
        {
            MouseDown += TaskBar_MouseDown;
            MouseMove += Taskbar_MouseMove;
            MouseLeave += (s, e) => Cursor = Cursors.Default;
        }

        private void TaskBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var form = FindForm();
                if (form == null) return;

                int grip = 8; // thickness to consider "border"

                bool left = e.X <= grip;
                bool right = e.X >= Width - grip;
                bool top = e.Y <= grip;

                if (top && left)
                    SendMessage(form.Handle, WM_NCLBUTTONDOWN, HTTOPLEFT, 0);
                else if (top && right)
                    SendMessage(form.Handle, WM_NCLBUTTONDOWN, HTTOPRIGHT, 0);
                else if (top)
                    SendMessage(form.Handle, WM_NCLBUTTONDOWN, HTTOPRIGHT, 0);

                else if (left)
                    SendMessage(form.Handle, WM_NCLBUTTONDOWN, HTTOPRIGHT, 0);

                else if (right)
                    SendMessage(form.Handle, WM_NCLBUTTONDOWN, HTTOPRIGHT, 0);

                else
                {
                    // drag window normally
                    ReleaseCapture();
                    SendMessage(form.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                    BtnMaximize.BackgroundImage = form.WindowState == FormWindowState.Maximized
                    ? Properties.Resources.screenNormal
                    : Properties.Resources.maximize;
                }
            }
        }


        private void Taskbar_MouseMove(object sender, MouseEventArgs e)
        {
            int edgeTolerance = 5;
            var panel = (Panel)sender;

            bool left = e.X <= edgeTolerance;
            bool right = e.X >= panel.Width - edgeTolerance;
            bool top = e.Y <= edgeTolerance;

            // Corners
            if (top && left)
                panel.Cursor = Cursors.SizeNWSE; // Top-left
            else if (top && right)
                panel.Cursor = Cursors.SizeNESW; // Top-right

            // Edges
            else if (left || right)
                panel.Cursor = Cursors.SizeWE; // Left or Right edge
            else if (top)
                panel.Cursor = Cursors.SizeNS; // Top or Bottom edge

            // Elsewhere
            else
                panel.Cursor = Cursors.Default;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;

            if (m.Msg == WM_NCHITTEST)
            {
                m.Result = (IntPtr)1; // HTCLIENT → lets parent (form) handle it
                return;
            }
            base.WndProc(ref m);
        }
    }
}
