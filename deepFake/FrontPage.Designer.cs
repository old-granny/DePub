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
            panelSign = new Panel();
            SignoutBTN = new Button();
            FrontPagePNL = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            panel1.SuspendLayout();
            panelSignin.SuspendLayout();
            panelSign.SuspendLayout();
            FrontPagePNL.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContenuePublication
            // 
            PanelContenuePublication.AutoScroll = true;
            PanelContenuePublication.Location = new Point(191, 88);
            PanelContenuePublication.Name = "PanelContenuePublication";
            PanelContenuePublication.Size = new Size(1128, 638);
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
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panelSignin);
            panel1.Controls.Add(panelSign);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1614, 80);
            panel1.TabIndex = 0;
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
            FrontPagePNL.Controls.Add(panel3);
            FrontPagePNL.Controls.Add(panel2);
            FrontPagePNL.Controls.Add(PanelContenuePublication);
            FrontPagePNL.Controls.Add(panel1);
            FrontPagePNL.Location = new Point(10, 9);
            FrontPagePNL.Margin = new Padding(3, 2, 3, 2);
            FrontPagePNL.Name = "FrontPagePNL";
            FrontPagePNL.Size = new Size(1665, 731);
            FrontPagePNL.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label1);
            panel3.Location = new Point(1324, 88);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(292, 638);
            panel3.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Candara", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 11);
            label1.Name = "label1";
            label1.Size = new Size(262, 37);
            label1.TabIndex = 0;
            label1.Text = "You have no friend";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(3, 683);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(184, 43);
            panel2.TabIndex = 4;
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
            // FrontPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1760, 888);
            Controls.Add(FrontPagePNL);
            Name = "FrontPage";
            Text = "FrontPage";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelSignin.ResumeLayout(false);
            panelSign.ResumeLayout(false);
            FrontPagePNL.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
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
        private Panel panelSignin;
        private Panel panelSign;
        private Button SignoutBTN;
        private Panel FrontPagePNL;
        private Panel panel3;
        private Label label1;
        private Panel panel2;
        private Label label2;
    }
}