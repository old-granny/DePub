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


                // drag window normally
                ReleaseCapture();
                SendMessage(form.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                BtnMaximize.BackgroundImage = form.WindowState == FormWindowState.Maximized
                ? Properties.Resources.screenNormal
                : Properties.Resources.maximize;

            }
        }

    }
}
