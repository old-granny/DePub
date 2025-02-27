namespace deepFake
{
    partial class FrontPage
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
            PanelContenuePublication = new Panel();
            boutonPagePost = new Button();
            BTNSignin = new Button();
            BTNSignup = new Button();
            panel1 = new Panel();
            panelSignin = new Panel();
            SignoutBTN = new Button();
            Username = new Label();
            panelSign = new Panel();
            ProfilTitle = new Label();
            panel1.SuspendLayout();
            panelSignin.SuspendLayout();
            panelSign.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContenuePublication
            // 
            PanelContenuePublication.AutoScroll = true;
            PanelContenuePublication.Location = new Point(247, 12);
            PanelContenuePublication.Name = "PanelContenuePublication";
            PanelContenuePublication.Size = new Size(1112, 767);
            PanelContenuePublication.TabIndex = 3;
            // 
            // boutonPagePost
            // 
            boutonPagePost.Location = new Point(13, 561);
            boutonPagePost.Name = "boutonPagePost";
            boutonPagePost.Size = new Size(201, 30);
            boutonPagePost.TabIndex = 4;
            boutonPagePost.Text = "Nouvelle publication";
            boutonPagePost.UseVisualStyleBackColor = true;
            boutonPagePost.Click += boutonPagePost_Click;
            // 
            // BTNSignin
            // 
            BTNSignin.Location = new Point(51, 3);
            BTNSignin.Name = "BTNSignin";
            BTNSignin.Size = new Size(100, 23);
            BTNSignin.TabIndex = 1;
            BTNSignin.Text = "Signing";
            BTNSignin.UseVisualStyleBackColor = true;
            BTNSignin.Click += BTNSignin_Click;
            // 
            // BTNSignup
            // 
            BTNSignup.Location = new Point(51, 32);
            BTNSignup.Name = "BTNSignup";
            BTNSignup.Size = new Size(100, 23);
            BTNSignup.TabIndex = 6;
            BTNSignup.Text = "SignUp";
            BTNSignup.UseVisualStyleBackColor = true;
            BTNSignup.Click += BTNSignup_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panelSign);
            panel1.Controls.Add(ProfilTitle);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(229, 767);
            panel1.TabIndex = 0;
            // 
            // panelSignin
            // 
            panelSignin.Controls.Add(SignoutBTN);
            panelSignin.Controls.Add(Username);
            panelSignin.Controls.Add(boutonPagePost);
            panelSignin.Location = new Point(12, 55);
            panelSignin.Name = "panelSignin";
            panelSignin.Size = new Size(229, 624);
            panelSignin.TabIndex = 8;
            // 
            // SignoutBTN
            // 
            SignoutBTN.Location = new Point(55, 601);
            SignoutBTN.Name = "SignoutBTN";
            SignoutBTN.Size = new Size(100, 23);
            SignoutBTN.TabIndex = 6;
            SignoutBTN.Text = "Sign out";
            SignoutBTN.UseVisualStyleBackColor = true;
            SignoutBTN.Click += SignoutBTN_Click;
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.Location = new Point(95, 18);
            Username.Name = "Username";
            Username.Size = new Size(38, 15);
            Username.TabIndex = 5;
            Username.Text = "label1";
            // 
            // panelSign
            // 
            panelSign.Controls.Add(BTNSignin);
            panelSign.Controls.Add(BTNSignup);
            panelSign.Location = new Point(3, 606);
            panelSign.Name = "panelSign";
            panelSign.Size = new Size(210, 60);
            panelSign.TabIndex = 0;
            // 
            // ProfilTitle
            // 
            ProfilTitle.Anchor = AnchorStyles.Right;
            ProfilTitle.AutoSize = true;
            ProfilTitle.Location = new Point(79, 15);
            ProfilTitle.Name = "ProfilTitle";
            ProfilTitle.Size = new Size(66, 15);
            ProfilTitle.TabIndex = 7;
            ProfilTitle.Text = "Not Sign in";
            // 
            // FrontPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 791);
            Controls.Add(panelSignin);
            Controls.Add(panel1);
            Controls.Add(PanelContenuePublication);
            Name = "FrontPage";
            Text = "FrontPage";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelSignin.ResumeLayout(false);
            panelSignin.PerformLayout();
            panelSign.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContenuePublication;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button boutonPagePost;
        private TableLayoutPanel tableLayoutPanel1;
        private Button BTNSignin;
        private Button BTNSignup;
        private Panel panel1;
        private Label ProfilTitle;
        private Panel panelSignin;
        private Panel panelSign;
        private Label Username;
        private Button SignoutBTN;
    }
}