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
    
    public partial class Signup : Form
    {
        private Acceuil Main;
        public Signup(Acceuil acceuil)
        {
            Main = acceuil;
            InitializeComponent();
        }
        
    }
}
