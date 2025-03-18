using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deepFake.Elements
{
    internal class AddElement : Panel
    {
        public Button ajouterTexteBtn;
        public Button ajouterImageBtn;

        public AddElement()
        {
            this.Location = new Point(0, 0);
            this.Size = new Size(140, 80); 
            this.BorderStyle = BorderStyle.FixedSingle;

            InitializeCompenents();
        }

        private void InitializeCompenents()
        {
            ajouterTexteBtn = new Button();
            ajouterImageBtn = new Button();

            ajouterImageBtn.Text = "Add a Image";
            ajouterTexteBtn.Text = "Add Texte";

            ajouterImageBtn.Font = new Font("Candara", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ajouterTexteBtn.Font = new Font("Candara", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);


            ajouterImageBtn.Size = new Size(140, 40);
            ajouterTexteBtn.Size = new Size(140, 40);

            ajouterImageBtn.Location = new Point(0, 0);
            ajouterTexteBtn.Location = new Point(0, 40);

            this.Controls.Add(ajouterTexteBtn);
            this.Controls.Add(ajouterImageBtn);

        }
    }
}
