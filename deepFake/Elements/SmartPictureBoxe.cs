using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace deepFake.Elements
{
    internal class SmartPictureBoxe : DraggablePanel
    {
        private Image Default_image;
        public byte[] Current_Image_Data;
        private bool Already_Has_Image = false;


        private PictureBox Picture;
        private Button ModifyBTN;
        private Button DeleteBTN;

        public SmartPictureBoxe(string nom, Point pt, Size size, int[] x_s, int[] y_s) : base(x_s, y_s)
        {
            // this
            {
                Name = nom;
                Location = pt;
                Size = size;
                BorderStyle = BorderStyle.FixedSingle;
                Draggable = true;
            }; Set_Draggable();

            ModifyBTN = new Button()
            {
                Location = new Point(10, size.Height - 40),
                Size = new Size(60, 30),
                Text = "Modify"
            };
            DeleteBTN = new Button()
            {
                Location = new Point(10, size.Height - 40),
                Size = new Size(60, 30),
                Text = "Remove"
            };


            Picture = new PictureBox()
            {
                Location = new Point(4, 4),
                Size = new Size(size.Width - 10, size.Height - 10),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle,
            }; SetDefaultImage();

            this.Controls.Add(Picture);
            Picture.Controls.Add(DeleteBTN);

            Picture.Click += Picture_Click;
            ModifyBTN.Click += ModifyBTN_Click;
            DeleteBTN.Click += DeleteBTN_Click;
        }

        public SmartPictureBoxe(Point pt, Size size, int[] x_s, int[] y_s) : base(x_s, y_s)
        {
            // this
            {
                Location = pt;
                Size = size;
                BorderStyle = BorderStyle.FixedSingle;
                Draggable = true;
            }; Set_Draggable();

            ModifyBTN = new Button()
            {
                Location = new Point(10, size.Height-40),
                Size = new Size(60, 30),
                Text = "Modify"
            };
            DeleteBTN = new Button()
            {
                Location = new Point(10, size.Height - 40),
                Size = new Size(60, 30),
                Text = "Remove"
            };
            

            Picture = new PictureBox()
            {
                Location = new Point(4, 4),
                Size = new Size(size.Width-10, size.Height-10),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle,
            }; SetDefaultImage();
            
            this.Controls.Add(Picture);
            Picture.Controls.Add(DeleteBTN);

            Picture.Click += Picture_Click;
            ModifyBTN.Click += ModifyBTN_Click;
            DeleteBTN.Click += DeleteBTN_Click;
        }
        private void Picture_Click(object? sender, EventArgs e)
        {
            if (!Already_Has_Image)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.CheckFileExists = true;
                ofd.AddExtension = true;
                ofd.Multiselect = false;
                ofd.Filter = "All Files|*.png;*.jpeg;*.jpg;";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    SetPicture(ofd.FileName);
                    Already_Has_Image = true;
                    Picture.Controls.Add(ModifyBTN); // Show the buttons
                    DeleteBTN.Location = new Point(DeleteBTN.Location.X + 70, DeleteBTN.Location.Y);
                }
            }
        }
        private void ModifyBTN_Click(object? sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.AddExtension = true;
            ofd.Multiselect = false;
            ofd.Filter = "All Files|*.png;*.jpeg;*.jpg;";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SetPicture(ofd.FileName);
            }
        }

        public void SetPicture(string filename)
        {
            byte[] img_bytes = File.ReadAllBytes(filename);
            Current_Image_Data = img_bytes;
            Image img = (Bitmap)((new ImageConverter()).ConvertFrom(img_bytes));
            Picture.Image = img ?? Picture.Image; // si image null remet l'image original dedans

        }

        public void SetPicture(byte[] images)
        {
            Current_Image_Data = images;
            Image img = (Bitmap)((new ImageConverter()).ConvertFrom(images));
            Picture.Image = img ?? Picture.Image; // si image null remet l'image original dedans
        }

        private void SetDefaultImage()
        {
            Default_image = Properties.Resources.AddImage;
            Picture.Image = Default_image;
        }

        public byte[] GetCurrentImage() => Current_Image_Data;

        private void DeleteBTN_Click(object? sender, EventArgs e)
        {
            RemoveSmartBoxe();
        }

        public void RemoveSmartBoxe() 
        {
            if(this.FindForm().GetType() == typeof(PublierPost))
            {
                
                PublierPost par = this.FindForm() as PublierPost;
                Remove_Draggable_Panel(par.ActivePanelsDraggables);
                par?.ElementRemoved(this);
            }
            

        }

        
    }
}
