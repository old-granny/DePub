namespace deepFake
{
    partial class Signup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            LabelTitre = new Label();
            UsernameTBX = new TextBox();
            NameTXB = new TextBox();
            PrenomTXB = new TextBox();
            pictureBox1 = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1330, 660);
            panel1.TabIndex = 0;
            // 
            // LabelTitre
            // 
            LabelTitre.AutoSize = true;
            LabelTitre.Location = new Point(3, 0);
            LabelTitre.Name = "LabelTitre";
            LabelTitre.Size = new Size(72, 15);
            LabelTitre.TabIndex = 1;
            LabelTitre.Text = "SignupForm";
            // 
            // UsernameTBX
            // 
            UsernameTBX.Location = new Point(3, 18);
            UsernameTBX.Name = "UsernameTBX";
            UsernameTBX.Size = new Size(408, 23);
            UsernameTBX.TabIndex = 0;
            UsernameTBX.Text = "Username";
            // 
            // NameTXB
            // 
            NameTXB.Location = new Point(3, 47);
            NameTXB.Name = "NameTXB";
            NameTXB.Size = new Size(408, 23);
            NameTXB.TabIndex = 2;
            NameTXB.Text = "Name";
            // 
            // PrenomTXB
            // 
            PrenomTXB.Location = new Point(3, 76);
            PrenomTXB.Name = "PrenomTXB";
            PrenomTXB.Size = new Size(407, 23);
            PrenomTXB.TabIndex = 3;
            PrenomTXB.Text = "Prenom";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 105);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(408, 97);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(LabelTitre);
            flowLayoutPanel1.Controls.Add(UsernameTBX);
            flowLayoutPanel1.Controls.Add(NameTXB);
            flowLayoutPanel1.Controls.Add(PrenomTXB);
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(432, 74);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(420, 377);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // Signup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1387, 730);
            Controls.Add(panel1);
            Name = "Signup";
            Text = "Signup";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label LabelTitre;
        private TextBox UsernameTBX;
        private PictureBox pictureBox1;
        private TextBox PrenomTXB;
        private TextBox NameTXB;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}