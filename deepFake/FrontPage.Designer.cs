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
            PanelTop = new Panel();
            label2 = new Label();
            panelSignin = new Panel();
            panelSign = new Panel();
            SignoutBTN = new Button();
            FrontPagePNL = new Panel();
            PanelTop.SuspendLayout();
            panelSignin.SuspendLayout();
            panelSign.SuspendLayout();
            FrontPagePNL.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContenuePublication
            // 
            PanelContenuePublication.AutoScroll = true;
            PanelContenuePublication.Location = new Point(0, 89);
            PanelContenuePublication.Name = "PanelContenuePublication";
            PanelContenuePublication.Size = new Size(1920, 1080);
            PanelContenuePublication.TabIndex = 3;
            // 
            // boutonPagePost
            // 
            boutonPagePost.Font = new Font("Candara", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            boutonPagePost.Location = new Point(3, 3);
            boutonPagePost.Name = "boutonPagePost";
            boutonPagePost.Size = new Size(388, 54);
            boutonPagePost.TabIndex = 4;
            boutonPagePost.Text = "Nouvelle publication";
            boutonPagePost.UseVisualStyleBackColor = true;
            boutonPagePost.Click += boutonPagePost_Click;
            // 
            // BTNSignin
            // 
            BTNSignin.Font = new Font("Candara", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTNSignin.Location = new Point(3, 4);
            BTNSignin.Name = "BTNSignin";
            BTNSignin.Size = new Size(231, 39);
            BTNSignin.TabIndex = 1;
            BTNSignin.Text = "Login";
            BTNSignin.UseVisualStyleBackColor = true;
            BTNSignin.Click += BTNSignin_Click;
            // 
            // BTNSignup
            // 
            BTNSignup.Font = new Font("Candara", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTNSignup.Location = new Point(239, 6);
            BTNSignup.Name = "BTNSignup";
            BTNSignup.Size = new Size(228, 38);
            BTNSignup.TabIndex = 6;
            BTNSignup.Text = "SignUp";
            BTNSignup.UseVisualStyleBackColor = true;
            BTNSignup.Click += BTNSignup_Click;
            // 
            // PanelTop
            // 
            PanelTop.BackColor = SystemColors.ControlLightLight;
            PanelTop.BorderStyle = BorderStyle.FixedSingle;
            PanelTop.Controls.Add(label2);
            PanelTop.Controls.Add(panelSignin);
            PanelTop.Controls.Add(panelSign);
            PanelTop.Location = new Point(0, 0);
            PanelTop.Name = "PanelTop";
            PanelTop.Size = new Size(1920, 83);
            PanelTop.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Candara", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(500, 32);
            label2.Name = "label2";
            label2.Size = new Size(169, 39);
            label2.TabIndex = 0;
            label2.Text = "Profil Infos";
            // 
            // panelSignin
            // 
            panelSignin.BorderStyle = BorderStyle.FixedSingle;
            panelSignin.Controls.Add(boutonPagePost);
            panelSignin.Location = new Point(21, 11);
            panelSignin.Name = "panelSignin";
            panelSignin.Size = new Size(407, 60);
            panelSignin.TabIndex = 8;
            // 
            // panelSign
            // 
            panelSign.BorderStyle = BorderStyle.FixedSingle;
            panelSign.Controls.Add(SignoutBTN);
            panelSign.Controls.Add(BTNSignin);
            panelSign.Controls.Add(BTNSignup);
            panelSign.Location = new Point(917, 3);
            panelSign.Name = "panelSign";
            panelSign.Size = new Size(692, 49);
            panelSign.TabIndex = 0;
            // 
            // SignoutBTN
            // 
            SignoutBTN.Font = new Font("Candara", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SignoutBTN.Location = new Point(472, 7);
            SignoutBTN.Name = "SignoutBTN";
            SignoutBTN.Size = new Size(216, 38);
            SignoutBTN.TabIndex = 6;
            SignoutBTN.Text = "Sign out";
            SignoutBTN.UseVisualStyleBackColor = true;
            SignoutBTN.Click += SignoutBTN_Click;
            // 
            // FrontPagePNL
            // 
            FrontPagePNL.Controls.Add(PanelContenuePublication);
            FrontPagePNL.Controls.Add(PanelTop);
            FrontPagePNL.Location = new Point(0, 0);
            FrontPagePNL.Margin = new Padding(3, 2, 3, 2);
            FrontPagePNL.Name = "FrontPagePNL";
            FrontPagePNL.Size = new Size(1920, 1080);
            FrontPagePNL.TabIndex = 4;
            // 
            // FrontPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1904, 1041);
            Controls.Add(FrontPagePNL);
            Name = "FrontPage";
            Text = "FrontPage";
            PanelTop.ResumeLayout(false);
            PanelTop.PerformLayout();
            panelSignin.ResumeLayout(false);
            panelSign.ResumeLayout(false);
            FrontPagePNL.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContenuePublication;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button boutonPagePost;
        private TableLayoutPanel tableLayoutPanel1;
        private Button BTNSignin;
        private Button BTNSignup;
        private Panel PanelTop;
        private Panel panelSignin;
        private Panel panelSign;
        private Button SignoutBTN;
        private Panel FrontPagePNL;
        private Label label2;
    }
}