using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deepFake
{
    public partial class PublierPost : Form
    {
        FileHandler handler;
        public PublierPost(FileHandler handle)
        {
            handler = handle;
            InitializeComponent();
        }

        private void boutonPost_Click(object sender, EventArgs e)
        {
            string content = Contenue.Text;
            string title = Titre.Text;
            handler.insertIntoData(title, content);

        }
    }
}
