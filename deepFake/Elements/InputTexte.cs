using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace deepFake.Elements
{
    internal class InputTexte : DraggablePanel
    {
        private Label EditableLabel;
        private TextBox EditTextBox;
        private bool Multined;

        public int MaxChar;
        public bool IsDraggable = false;
        

        public InputTexte(string texte, Size size, int maxChar, bool multiline, bool draggable)
        {
            this.Size = size;
            MaxChar = maxChar;
            Multined = multiline;
            Create_InputText(texte, size, multiline);
            if (draggable)
            {
                IsDraggable = true;
                this.Set_Draggable();
            }
        }

        private void Create_InputText(string contenue, Size size, bool multiline)
        {
            // Create and set up Label
            EditableLabel = new Label
            {
                Text = contenue,
                AutoSize = true,
                Location = new Point(2, 2),
                MaximumSize = new Size(size.Width, 0),
                Size = size,
                BorderStyle = BorderStyle.None,
                Font = new Font("Candara", 24F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };

            // Create and set up TextBox (initially hidden)
            EditTextBox = new TextBox
            {
                Visible = false,
                Location = new Point(2, 2),
                Multiline = multiline,
                Size = size,
                MaxLength = MaxChar,
                AutoSize = false,
                Font = new Font("Candara", 24F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };
            EditTextBox.Width = Size.Width;
            Console.WriteLine(Size.Width);
            this.Controls.Add(EditableLabel);
            this.Controls.Add(EditTextBox);

            // Events
            EditableLabel.Click += EditableLabel_Click;
            EditTextBox.KeyDown += EditTextBox_KeyDown;
            EditTextBox.LostFocus += EditTextBox_LostFocus;
            EditTextBox.TextChanged += EditTextBox_TextChanged;
        }

        // When label is clicked, swap to TextBox
        private void EditableLabel_Click(object sender, EventArgs e)
        {
            EditTextBox.Text = EditableLabel.Text;
            //EditTextBox.Width = EditableLabel.Width;
            EditTextBox.Visible = true;
            EditableLabel.Visible = false;
            EditTextBox.Focus();
        }

        
        private void EditTextBox_KeyDown(object sender, KeyEventArgs e)
        {  
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true; // couper le son windows
                SaveEdit();
            }   
        }

        // When focus is lost, apply the change
        private void EditTextBox_LostFocus(object sender, EventArgs e)
        {
            SaveEdit();
        }

        // Save changes and swap back to Label
        private void SaveEdit()
        {
            if(Multined)
                EditableLabel.Text = Algorithme.StringToLinedString(EditTextBox.Text, MaxChar);
            else
                EditableLabel.Text = EditTextBox.Text;

            EditTextBox.Visible = false;
            EditableLabel.Visible = true;
        }

        private void EditTextBox_TextChanged(object sender, EventArgs e)
        {
            ResizeTextBoxToFitText();
        }

        // Resize logic
        private void ResizeTextBoxToFitText()
        {
            var text = EditTextBox.Text;
            Size textSize = TextRenderer.MeasureText(text + " ", EditTextBox.Font); // " " for padding
            int newWidth = Math.Max(50, textSize.Width);
            newWidth = Math.Min(this.Width, newWidth); // Optional: max width limit

            EditTextBox.Width = 800;
        }
    } 
}
