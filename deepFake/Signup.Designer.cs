using System.Windows.Forms;

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
            pictureBox2 = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            LabelTitre = new Label();
            UsernameTBX = new TextBox();
            NameTXB = new TextBox();
            PrenomTXB = new TextBox();
            dateTXB = new TextBox();
            emailTXB = new TextBox();
            passwordTXB = new TextBox();
            pictureBox1 = new PictureBox();
            ErrorListLB = new Label();
            SignupButton = new Button();
            GoBackLBL = new Label();
            pictureBox3 = new PictureBox();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox3);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1282, 728);
            panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(12, 30);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(641, 582);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(UsernameTBX);
            flowLayoutPanel1.Controls.Add(NameTXB);
            flowLayoutPanel1.Controls.Add(PrenomTXB);
            flowLayoutPanel1.Controls.Add(dateTXB);
            flowLayoutPanel1.Controls.Add(emailTXB);
            flowLayoutPanel1.Controls.Add(passwordTXB);
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.Controls.Add(ErrorListLB);
            flowLayoutPanel1.Controls.Add(SignupButton);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(19, 90);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(510, 442);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // LabelTitre
            // 
            LabelTitre.AutoSize = true;
            LabelTitre.BorderStyle = BorderStyle.FixedSingle;
            LabelTitre.Font = new Font("Segoe UI Variable Display", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelTitre.Location = new Point(208, 34);
            LabelTitre.Name = "LabelTitre";
            LabelTitre.Size = new Size(106, 39);
            LabelTitre.TabIndex = 1;
            LabelTitre.Text = "Signup";
            // 
            // UsernameTBX
            // 
            UsernameTBX.Location = new Point(3, 4);
            UsernameTBX.Margin = new Padding(3, 4, 3, 4);
            UsernameTBX.Name = "UsernameTBX";
            UsernameTBX.Size = new Size(466, 27);
            UsernameTBX.TabIndex = 0;
            UsernameTBX.Text = "Username";
            // 
            // NameTXB
            // 
            NameTXB.Location = new Point(3, 39);
            NameTXB.Margin = new Padding(3, 4, 3, 4);
            NameTXB.Name = "NameTXB";
            NameTXB.Size = new Size(466, 27);
            NameTXB.TabIndex = 2;
            NameTXB.Text = "Name";
            // 
            // PrenomTXB
            // 
            PrenomTXB.Location = new Point(3, 74);
            PrenomTXB.Margin = new Padding(3, 4, 3, 4);
            PrenomTXB.Name = "PrenomTXB";
            PrenomTXB.Size = new Size(465, 27);
            PrenomTXB.TabIndex = 3;
            PrenomTXB.Text = "Prenom";
            // 
            // dateTXB
            // 
            dateTXB.Location = new Point(3, 108);
            dateTXB.Name = "dateTXB";
            dateTXB.Size = new Size(465, 27);
            dateTXB.TabIndex = 8;
            dateTXB.Text = "Date";
            // 
            // emailTXB
            // 
            emailTXB.Location = new Point(3, 141);
            emailTXB.Name = "emailTXB";
            emailTXB.Size = new Size(465, 27);
            emailTXB.TabIndex = 7;
            emailTXB.Text = "Email";
            // 
            // passwordTXB
            // 
            passwordTXB.Location = new Point(3, 174);
            passwordTXB.Name = "passwordTXB";
            passwordTXB.Size = new Size(466, 27);
            passwordTXB.TabIndex = 6;
            passwordTXB.Text = "Password";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 208);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(466, 105);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // ErrorListLB
            // 
            ErrorListLB.AutoSize = true;
            ErrorListLB.Location = new Point(3, 317);
            ErrorListLB.Name = "ErrorListLB";
            ErrorListLB.Size = new Size(0, 20);
            ErrorListLB.TabIndex = 9;
            // 
            // SignupButton
            // 
            SignupButton.Location = new Point(3, 340);
            SignupButton.Name = "SignupButton";
            SignupButton.Size = new Size(94, 29);
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
            GoBackLBL.Location = new Point(208, 571);
            GoBackLBL.Name = "GoBackLBL";
            GoBackLBL.Size = new Size(83, 28);
            GoBackLBL.TabIndex = 6;
            GoBackLBL.Text = "Go Back";
            GoBackLBL.Click += GoBackLBL_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.White;
            pictureBox3.Location = new Point(652, 30);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(598, 654);
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Controls.Add(LabelTitre);
            panel2.Controls.Add(GoBackLBL);
            panel2.Location = new Point(670, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(550, 606);
            panel2.TabIndex = 9;
            // 
            // Signup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1282, 728);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Signup";
            Text = "Signup";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Label ErrorListLB;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Panel panel2;
    }
}