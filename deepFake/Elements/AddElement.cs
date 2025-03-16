using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deepFake.Elements
{
    internal class AddElement : Panel
    {
        public AddElement()
        {
            this.Location = new Point(0, 0);
            this.Size = new Size(100, 200); 
            this.BorderStyle = BorderStyle.FixedSingle;
            InitializeCompenents();
        }

        private void InitializeCompenents()
        {
            Button ajouterTexte = new Button();
            Button ajouterImage = new Button();

            ajouterImage.Text = "Add a Image";
            ajouterTexte.Text = "Add Texte";

            ajouterImage.Size = new Size(100,100);
            ajouterTexte.Size = new Size(100, 100);

            ajouterImage.Location = new Point(0, 0);
            ajouterTexte.Location = new Point(0, 100);

            this.Controls.Add(ajouterTexte);
            this.Controls.Add(ajouterImage);

        }
    }
}
