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
            panelContenuePost.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenuePost
            // 
            panelContenuePost.Controls.Add(boutonPost);
            panelContenuePost.Controls.Add(Titre);
            panelContenuePost.Controls.Add(Contenue);
            panelContenuePost.Location = new Point(416, 48);
            panelContenuePost.Name = "panelContenuePost";
            panelContenuePost.Size = new Size(333, 254);
            panelContenuePost.TabIndex = 4;
            // 
            // boutonPost
            // 
            boutonPost.Location = new Point(0, 224);
            boutonPost.Name = "boutonPost";
            boutonPost.Size = new Size(75, 23);
            boutonPost.TabIndex = 2;
            boutonPost.Text = "publier";
            boutonPost.UseVisualStyleBackColor = true;
            boutonPost.Click += boutonPost_Click;
            // 
            // Titre
            // 
            Titre.Location = new Point(0, 3);
            Titre.Name = "Titre";
            Titre.Size = new Size(100, 23);
            Titre.TabIndex = 1;
            Titre.Text = "Titre";
            // 
            // Contenue
            // 
            Contenue.Location = new Point(0, 32);
            Contenue.Multiline = true;
            Contenue.Name = "Contenue";
            Contenue.Size = new Size(325, 186);
            Contenue.TabIndex = 0;
            Contenue.Text = "Contenue";
            // 
            // PublierPost
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(panelContenuePost);
            Name = "PublierPost";
            Text = "PublierPost";
            panelContenuePost.ResumeLayout(false);
            panelContenuePost.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContenuePost;
        private Button boutonPost;
        private TextBox Titre;
        private TextBox Contenue;
    }
}