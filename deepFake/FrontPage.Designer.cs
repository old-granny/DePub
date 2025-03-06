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
            panel2 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            panelSignin.SuspendLayout();
            panelSign.SuspendLayout();
            FrontPagePNL.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContenuePublication
            // 
            PanelContenuePublication.AutoScroll = true;
            PanelContenuePublication.Location = new Point(341, 234);
            PanelContenuePublication.Margin = new Padding(3, 4, 3, 4);
            PanelContenuePublication.Name = "PanelContenuePublication";
            PanelContenuePublication.Size = new Size(1291, 734);
            PanelContenuePublication.TabIndex = 3;
            // 
            // boutonPagePost
            // 
            boutonPagePost.Font = new Font("Candara", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            boutonPagePost.Location = new Point(3, -1);
            boutonPagePost.Margin = new Padding(3, 4, 3, 4);
            boutonPagePost.Name = "boutonPagePost";
            boutonPagePost.Size = new Size(458, 78);
            boutonPagePost.TabIndex = 4;
            boutonPagePost.Text = "Nouvelle publication";
            boutonPagePost.UseVisualStyleBackColor = true;
            boutonPagePost.Click += boutonPagePost_Click;
            // 
            // BTNSignin
            // 
            BTNSignin.Font = new Font("Candara", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTNSignin.Location = new Point(3, 6);
            BTNSignin.Margin = new Padding(3, 4, 3, 4);
            BTNSignin.Name = "BTNSignin";
            BTNSignin.Size = new Size(264, 52);
            BTNSignin.TabIndex = 1;
            BTNSignin.Text = "Login";
            BTNSignin.UseVisualStyleBackColor = true;
            BTNSignin.Click += BTNSignin_Click;
            // 
            // BTNSignup
            // 
            BTNSignup.Font = new Font("Candara", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTNSignup.Location = new Point(273, 8);
            BTNSignup.Margin = new Padding(3, 4, 3, 4);
            BTNSignup.Name = "BTNSignup";
            BTNSignup.Size = new Size(260, 50);
            BTNSignup.TabIndex = 6;
            BTNSignup.Text = "SignUp";
            BTNSignup.UseVisualStyleBackColor = true;
            BTNSignup.Click += BTNSignup_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panelSignin);
            panel1.Controls.Add(panelSign);
            panel1.Location = new Point(3, 4);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1976, 222);
            panel1.TabIndex = 0;
            // 
            // panelSignin
            // 
            panelSignin.BorderStyle = BorderStyle.FixedSingle;
            panelSignin.Controls.Add(boutonPagePost);
            panelSignin.Location = new Point(24, 15);
            panelSignin.Margin = new Padding(3, 4, 3, 4);
            panelSignin.Name = "panelSignin";
            panelSignin.Size = new Size(745, 145);
            panelSignin.TabIndex = 8;
            // 
            // panelSign
            // 
            panelSign.BorderStyle = BorderStyle.FixedSingle;
            panelSign.Controls.Add(SignoutBTN);
            panelSign.Controls.Add(BTNSignin);
            panelSign.Controls.Add(BTNSignup);
            panelSign.Location = new Point(1180, 148);
            panelSign.Margin = new Padding(3, 4, 3, 4);
            panelSign.Name = "panelSign";
            panelSign.Size = new Size(791, 65);
            panelSign.TabIndex = 0;
            // 
            // SignoutBTN
            // 
            SignoutBTN.Font = new Font("Candara", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SignoutBTN.Location = new Point(539, 9);
            SignoutBTN.Margin = new Padding(3, 4, 3, 4);
            SignoutBTN.Name = "SignoutBTN";
            SignoutBTN.Size = new Size(247, 50);
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
            FrontPagePNL.Location = new Point(12, 12);
            FrontPagePNL.Name = "FrontPagePNL";
            FrontPagePNL.Size = new Size(1982, 975);
            FrontPagePNL.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label2);
            panel2.Location = new Point(3, 233);
            panel2.Name = "panel2";
            panel2.Size = new Size(332, 735);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label1);
            panel3.Location = new Point(1638, 234);
            panel3.Name = "panel3";
            panel3.Size = new Size(333, 734);
            panel3.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Candara", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 15);
            label1.Name = "label1";
            label1.Size = new Size(315, 45);
            label1.TabIndex = 0;
            label1.Text = "You have no friend";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Candara", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(59, 31);
            label2.Name = "label2";
            label2.Size = new Size(209, 49);
            label2.TabIndex = 0;
            label2.Text = "Profil Infos";
            // 
            // FrontPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(2011, 1148);
            Controls.Add(FrontPagePNL);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrontPage";
            Text = "FrontPage";
            panel1.ResumeLayout(false);
            panelSignin.ResumeLayout(false);
            panelSign.ResumeLayout(false);
            FrontPagePNL.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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