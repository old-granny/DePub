using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deepFake.Elements
{
    internal class InputTexte : Panel
    {
        private Label editableLabel;
        private TextBox editTextBox;

        private int minTextBoxWidth = 50;
        private int maxTextBoxWidth;

        private int minTextBoxHeight = 50;
        private int maxTextBoxHeight = 150;

        public InputTexte(string str, Point pt, Size size, int maxChar, int maxWidth)
        {
            this.Location = pt;
            this.Size = size;
            maxTextBoxWidth = maxWidth;
            // Create and set up Label
            editableLabel = new Label
            {
                Text = str,
                AutoSize = true,
                Location = new Point(0,0),
                Size =  size,

                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Candara", 24F, FontStyle.Regular, GraphicsUnit.Point, 0)

            };
            this.Controls.Add(editableLabel);

            // Create and set up TextBox (initially hidden)
            editTextBox = new TextBox
            {
                Visible = false,
                Location = editableLabel.Location,
                Width = 150,
                Multiline = true,
                Font = new Font("Candara", 24F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };
            this.Controls.Add(editTextBox);
            editTextBox.MaxLength = maxChar;

            // Events
            editableLabel.Click += EditableLabel_Click;
            editTextBox.KeyDown += EditTextBox_KeyDown;
            editTextBox.LostFocus += EditTextBox_LostFocus;
            editTextBox.TextChanged += EditTextBox_TextChanged; // Auto-resize on text change
        }

        // When label is clicked, swap to TextBox
        private void EditableLabel_Click(object sender, EventArgs e)
        {
            editTextBox.Text = editableLabel.Text;
            editTextBox.Location = editableLabel.Location;
            editTextBox.Width = editableLabel.Width;
            editTextBox.Visible = true;
            editableLabel.Visible = false;
            editTextBox.Focus();
            editTextBox.SelectAll(); // Optional: Select all text for easy editing
        }

        
        private void EditTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Escape)
            {
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
            editableLabel.Text = editTextBox.Text;
            editTextBox.Visible = false;
            editableLabel.Visible = true;
        }

        // Cancel editing (keep original text)
        private void CancelEdit()
        {
            editTextBox.Visible = false;
            editableLabel.Visible = true;
        }

        private void EditTextBox_TextChanged(object sender, EventArgs e)
        {
            ResizeTextBoxToFitText();
        }

        // Resize logic
        private void ResizeTextBoxToFitText()
        {
            var text = editTextBox.Text;
            Size textSize = TextRenderer.MeasureText(text + " ", editTextBox.Font); // " " for padding
            int newWidth = Math.Max(minTextBoxWidth, textSize.Width);
            newWidth = Math.Min(maxTextBoxWidth, newWidth); // Optional: max width limit

            editTextBox.Width = newWidth;
            this.Width = newWidth;
            
            int newHeight = Math.Max(minTextBoxWidth, textSize.Width);
            newWidth = Math.Min(maxTextBoxWidth, newWidth); // Optional: max width limit

            editTextBox.Width = newWidth;
            this.Width = newWidth;

        }
    } 
}
