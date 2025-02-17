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
            flowLayoutPanel1 = new FlowLayoutPanel();
            LabelTitre = new Label();
            UsernameTBX = new TextBox();
            NameTXB = new TextBox();
            PrenomTXB = new TextBox();
            pictureBox1 = new PictureBox();
            SignupButton = new Button();
            passwordTXB = new TextBox();
            emailTXB = new TextBox();
            dateTXB = new TextBox();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Location = new Point(14, 16);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1520, 880);
            panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(LabelTitre);
            flowLayoutPanel1.Controls.Add(UsernameTBX);
            flowLayoutPanel1.Controls.Add(NameTXB);
            flowLayoutPanel1.Controls.Add(PrenomTXB);
            flowLayoutPanel1.Controls.Add(dateTXB);
            flowLayoutPanel1.Controls.Add(emailTXB);
            flowLayoutPanel1.Controls.Add(passwordTXB);
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.Controls.Add(SignupButton);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(494, 99);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(480, 503);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // LabelTitre
            // 
            LabelTitre.AutoSize = true;
            LabelTitre.Location = new Point(3, 0);
            LabelTitre.Name = "LabelTitre";
            LabelTitre.Size = new Size(89, 20);
            LabelTitre.TabIndex = 1;
            LabelTitre.Text = "SignupForm";
            // 
            // UsernameTBX
            // 
            UsernameTBX.Location = new Point(3, 24);
            UsernameTBX.Margin = new Padding(3, 4, 3, 4);
            UsernameTBX.Name = "UsernameTBX";
            UsernameTBX.Size = new Size(466, 27);
            UsernameTBX.TabIndex = 0;
            UsernameTBX.Text = "Username";
            // 
            // NameTXB
            // 
            NameTXB.Location = new Point(3, 59);
            NameTXB.Margin = new Padding(3, 4, 3, 4);
            NameTXB.Name = "NameTXB";
            NameTXB.Size = new Size(466, 27);
            NameTXB.TabIndex = 2;
            NameTXB.Text = "Name";
            // 
            // PrenomTXB
            // 
            PrenomTXB.Location = new Point(3, 94);
            PrenomTXB.Margin = new Padding(3, 4, 3, 4);
            PrenomTXB.Name = "PrenomTXB";
            PrenomTXB.Size = new Size(465, 27);
            PrenomTXB.TabIndex = 3;
            PrenomTXB.Text = "Prenom";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 228);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(466, 129);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // SignupButton
            // 
            SignupButton.Location = new Point(3, 364);
            SignupButton.Name = "SignupButton";
            SignupButton.Size = new Size(94, 29);
            SignupButton.TabIndex = 5;
            SignupButton.Text = "Signup";
            SignupButton.UseVisualStyleBackColor = true;
            SignupButton.Click += button1_Click;
            // 
            // passwordTXB
            // 
            passwordTXB.Location = new Point(3, 194);
            passwordTXB.Name = "passwordTXB";
            passwordTXB.Size = new Size(466, 27);
            passwordTXB.TabIndex = 6;
            passwordTXB.Text = "Password";
            // 
            // emailTXB
            // 
            emailTXB.Location = new Point(3, 161);
            emailTXB.Name = "emailTXB";
            emailTXB.Size = new Size(465, 27);
            emailTXB.TabIndex = 7;
            emailTXB.Text = "Email";
            // 
            // dateTXB
            // 
            dateTXB.Location = new Point(3, 128);
            dateTXB.Name = "dateTXB";
            dateTXB.Size = new Size(465, 27);
            dateTXB.TabIndex = 8;
            dateTXB.Text = "Date";
            // 
            // Signup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1585, 973);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Signup";
            Text = "Signup";
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Button SignupButton;
        private TextBox emailTXB;
        private TextBox passwordTXB;
        private TextBox dateTXB;
    }
}