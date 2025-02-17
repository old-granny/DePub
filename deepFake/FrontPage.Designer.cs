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
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContenuePublication
            // 
            PanelContenuePublication.AutoScroll = true;
            PanelContenuePublication.Location = new Point(350, 93);
            PanelContenuePublication.Margin = new Padding(3, 4, 3, 4);
            PanelContenuePublication.Name = "PanelContenuePublication";
            PanelContenuePublication.Size = new Size(1203, 892);
            PanelContenuePublication.TabIndex = 3;
            // 
            // boutonPagePost
            // 
            boutonPagePost.Location = new Point(3, 848);
            boutonPagePost.Margin = new Padding(3, 4, 3, 4);
            boutonPagePost.Name = "boutonPagePost";
            boutonPagePost.Size = new Size(240, 40);
            boutonPagePost.TabIndex = 4;
            boutonPagePost.Text = "Nouvelle publication";
            boutonPagePost.UseVisualStyleBackColor = true;
            boutonPagePost.Click += boutonPagePost_Click;
            // 
            // BTNSignin
            // 
            BTNSignin.Location = new Point(62, 279);
            BTNSignin.Margin = new Padding(3, 4, 3, 4);
            BTNSignin.Name = "BTNSignin";
            BTNSignin.Size = new Size(114, 31);
            BTNSignin.TabIndex = 1;
            BTNSignin.Text = "Signing";
            BTNSignin.UseVisualStyleBackColor = true;
            BTNSignin.Click += BTNSignin_Click;
            // 
            // BTNSignup
            // 
            BTNSignup.Location = new Point(62, 317);
            BTNSignup.Margin = new Padding(3, 4, 3, 4);
            BTNSignup.Name = "BTNSignup";
            BTNSignup.Size = new Size(114, 31);
            BTNSignup.TabIndex = 6;
            BTNSignup.Text = "SignUp";
            BTNSignup.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(boutonPagePost);
            panel1.Controls.Add(BTNSignup);
            panel1.Controls.Add(BTNSignin);
            panel1.Location = new Point(75, 93);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(247, 892);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 59);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 7;
            label1.Text = "Not Sign in";
            // 
            // FrontPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1567, 1055);
            Controls.Add(panel1);
            Controls.Add(PanelContenuePublication);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrontPage";
            Text = "FrontPage";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Label label1;
    }
}