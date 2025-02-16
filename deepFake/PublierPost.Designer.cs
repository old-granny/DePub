namespace deepFake
{
    partial class PublierPost
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
            panelContenuePost = new Panel();
            boutonPost = new Button();
            Titre = new TextBox();
            Contenue = new TextBox();
            panel1 = new Panel();
            button1 = new Button();
            panelContenuePost.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenuePost
            // 
            panelContenuePost.Controls.Add(button1);
            panelContenuePost.Controls.Add(boutonPost);
            panelContenuePost.Controls.Add(Titre);
            panelContenuePost.Controls.Add(Contenue);
            panelContenuePost.Location = new Point(334, 65);
            panelContenuePost.Name = "panelContenuePost";
            panelContenuePost.Size = new Size(608, 505);
            panelContenuePost.TabIndex = 4;
            // 
            // boutonPost
            // 
            boutonPost.Location = new Point(293, 453);
            boutonPost.Name = "boutonPost";
            boutonPost.Size = new Size(312, 23);
            boutonPost.TabIndex = 2;
            boutonPost.Text = "publier";
            boutonPost.UseVisualStyleBackColor = true;
            boutonPost.Click += boutonPost_Click;
            // 
            // Titre
            // 
            Titre.Location = new Point(3, 32);
            Titre.Name = "Titre";
            Titre.Size = new Size(287, 23);
            Titre.TabIndex = 1;
            Titre.Text = "Titre";
            // 
            // Contenue
            // 
            Contenue.Location = new Point(3, 61);
            Contenue.Multiline = true;
            Contenue.Name = "Contenue";
            Contenue.Size = new Size(287, 441);
            Contenue.TabIndex = 0;
            Contenue.Text = "Contenue";
            // 
            // panel1
            // 
            panel1.Controls.Add(panelContenuePost);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1176, 676);
            panel1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(293, 479);
            button1.Name = "button1";
            button1.Size = new Size(312, 23);
            button1.TabIndex = 3;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            // 
            // PublierPost
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(panel1);
            Name = "PublierPost";
            Text = "PublierPost";
            panelContenuePost.ResumeLayout(false);
            panelContenuePost.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContenuePost;
        private Button boutonPost;
        private TextBox Titre;
        private TextBox Contenue;
        private Panel panel1;
        private Button button1;
    }
}