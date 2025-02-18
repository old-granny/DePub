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
            dateTXB = new TextBox();
            emailTXB = new TextBox();
            passwordTXB = new TextBox();
            pictureBox1 = new PictureBox();
            SignupButton = new Button();
            GoBackLBL = new Label();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(GoBackLBL);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1330, 660);
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
            flowLayoutPanel1.Location = new Point(432, 74);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(420, 377);
            flowLayoutPanel1.TabIndex = 5;
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
            // dateTXB
            // 
            dateTXB.Location = new Point(3, 104);
            dateTXB.Margin = new Padding(3, 2, 3, 2);
            dateTXB.Name = "dateTXB";
            dateTXB.Size = new Size(407, 23);
            dateTXB.TabIndex = 8;
            dateTXB.Text = "Date";
            // 
            // emailTXB
            // 
            emailTXB.Location = new Point(3, 131);
            emailTXB.Margin = new Padding(3, 2, 3, 2);
            emailTXB.Name = "emailTXB";
            emailTXB.Size = new Size(407, 23);
            emailTXB.TabIndex = 7;
            emailTXB.Text = "Email";
            // 
            // passwordTXB
            // 
            passwordTXB.Location = new Point(3, 158);
            passwordTXB.Margin = new Padding(3, 2, 3, 2);
            passwordTXB.Name = "passwordTXB";
            passwordTXB.Size = new Size(408, 23);
            passwordTXB.TabIndex = 6;
            passwordTXB.Text = "Password";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 186);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(408, 97);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // SignupButton
            // 
            SignupButton.Location = new Point(3, 288);
            SignupButton.Margin = new Padding(3, 2, 3, 2);
            SignupButton.Name = "SignupButton";
            SignupButton.Size = new Size(82, 22);
            SignupButton.TabIndex = 5;
            SignupButton.Text = "Signup";
            SignupButton.UseVisualStyleBackColor = true;
            SignupButton.Click += button1_Click;
            // 
            // GoBackLBL
            // 
            GoBackLBL.AutoSize = true;
            GoBackLBL.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GoBackLBL.ForeColor = Color.Blue;
            GoBackLBL.Location = new Point(606, 471);
            GoBackLBL.Name = "GoBackLBL";
            GoBackLBL.Size = new Size(66, 21);
            GoBackLBL.TabIndex = 6;
            GoBackLBL.Text = "Go Back";
            GoBackLBL.Click += GoBackLBL_Click;
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
            panel1.PerformLayout();
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
        private Label GoBackLBL;
    }
}